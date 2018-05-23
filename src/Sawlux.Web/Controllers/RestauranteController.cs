using Sawlux.Data.Contexto;
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
        readonly RestauranteService restauranteService;

        public RestauranteController()
        {
            contexto = new SawluxContexto();
            restauranteService = new RestauranteService(contexto);
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

            var restauranteVM = new RestauranteVM { Nome = restaurante.Nome, Id = restaurante.Id };
            return View(restauranteVM);
        }

        [HttpPost]
        public ActionResult Cadastro(RestauranteVM restauranteVM)
        {
            if (ModelState.IsValid)
            {
                var restaurante = new Restaurante();
                if (restauranteVM.Id > 0)
                    restaurante = restauranteService.Get(x => x.Id == restauranteVM.Id).FirstOrDefault();

                restaurante.Nome = restauranteVM.Nome;

                if (restauranteVM.Id > 0)
                    restauranteService.Update(restaurante);
                else
                    restauranteService.Add(restaurante);

                restauranteService.Save();
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