using Sawlux.Data.Contexto;
using Sawlux.Data.Repositorios;
using Sawlux.Service.Services;
using Sawlux.ViewModel;
using Sawluz.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sawlux.Web.Controllers
{
    public class RestauranteController : Controller
    {
        readonly SawluxContexto contexto;
        readonly IRestauranteService restauranteService;

        public RestauranteController()
        {
            //TODO: Implementar Unity para DI
            contexto = new SawluxContexto();
            var repo = new RestauranteRepositorio(contexto);
            restauranteService = new RestauranteService(repo);
        }
        // GET: Restaurante
        public ActionResult Index(string restaurante)
        {
            var restaurantes = new List<Restaurante>();
            if (!string.IsNullOrEmpty(restaurante))
                restaurantes = restauranteService.Get(x => x.Nome.ToLower().Contains(restaurante.ToLower())).ToList();
            else
                restaurantes = restauranteService.GetAll().ToList();

            var restaurantesVM = new List<RestauranteVM>();
            foreach (var restauranteModel in restaurantes)
            {
                //TODO: Implmentar auto mapper
                restaurantesVM.Add(new RestauranteVM
                {
                    Nome = restauranteModel.Nome,
                    Id = restauranteModel.Id
                });
            }
            return View(restaurantesVM);
        }

        public ActionResult Cadastro(int id = 0)
        {
            var restaurante = new Restaurante();
            if (id > 0)
                restaurante = restauranteService.Get(x => x.Id == id).FirstOrDefault();

            //TODO: Implmentar auto mapper
            var restauranteVM = new RestauranteVM { Nome = restaurante.Nome, Id = restaurante.Id };
            return View(restauranteVM);
        }

        [HttpPost]
        public ActionResult Cadastro(RestauranteVM restauranteVM)
        {
            if (ModelState.IsValid)
            {
                //TODO: Implmentar auto mapper
                var restaurante = new Restaurante();
                restaurante.Nome = restauranteVM.Nome;
                restaurante.Id = restauranteVM.Id;

                restauranteService.Cadastro(restaurante);

                return RedirectToAction("Index");
            }
            return View(restauranteVM);
        }

        public ActionResult Delete(int id)
        {
            restauranteService.Delete(x => x.Id == id);
            restauranteService.Save();
            return RedirectToAction("Index");
        }
    }
}