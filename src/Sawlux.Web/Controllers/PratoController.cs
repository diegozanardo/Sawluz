using Sawlux.Data.Contexto;
using Sawlux.Data.Repositorios;
using Sawlux.Service.Services;
using Sawlux.ViewModel;
using Sawluz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sawlux.Web.Controllers
{
    public class PratoController : Controller
    {
        readonly SawluxContexto contexto;
        readonly IPratoService pratoService;
        readonly IRestauranteService restauranteService;

        public PratoController()
        {
            //TODO: Implementar Unity para DI
            contexto = new SawluxContexto();
            var repo = new PratoRepositorio(contexto);
            var repoRestaurante = new RestauranteRepositorio(contexto);
            restauranteService = new RestauranteService(repoRestaurante);

            pratoService = new PratoService(repo, restauranteService);
        }
        // GET: Prato
        public ActionResult Index()
        {
            var pratos = pratoService.GetAll().ToList();
            var pratosVM = new List<PratoVM>();
            //TODO: Implmentar auto mapper
            foreach (var prato in pratos)
            {
                pratosVM.Add(
                    new PratoVM
                    {
                        Id = prato.Id,
                        Nome = prato.Nome,
                        Preco = prato.Preco,
                        Restaurante = prato.Restaurante.Nome
                    });
            }
            return View(pratosVM);
        }

        public ActionResult Cadastro(int id = 0)
        {
            var prato = new Prato();
            var pratoVM = new PratoCadastroVM();
            if (id > 0)
            {
                prato = pratoService.Get(x => x.Id == id).FirstOrDefault();
                //TODO: Implmentar auto mapper
                pratoVM = new PratoCadastroVM
                {
                    Nome = prato.Nome,
                    Id = prato.Id,
                    Preco = prato.Preco,
                    Restaurante = prato.Restaurante.Nome
                };
            }

            var restaurantes = restauranteService.GetAll()
                      .Select(x => new SelectListItem
                      {
                          Value = x.Id.ToString(),
                          Text = x.Nome,
                          Selected = pratoVM.Restaurante == x.Nome
                      })
                      .ToList();

            pratoVM.Restaurantes = restaurantes;

            return View(pratoVM);
        }

        [HttpPost]
        public ActionResult Cadastro(PratoCadastroVM pratoVM)
        {
            if (ModelState.IsValid)
            {
                var prato = new Prato();
                int restauranteId;
                int.TryParse(pratoVM.Restaurante, out restauranteId);
                //TODO: Implmentar auto mapper
                prato.Nome = pratoVM.Nome;
                prato.Preco = pratoVM.Preco;
                prato.Id = pratoVM.Id;

                pratoService.Cadastro(prato, restauranteId);

                return RedirectToAction("Index");
            }
            return View(pratoVM);
        }

        public ActionResult Delete(int id)
        {
            pratoService.Delete(x => x.Id == id);
            pratoService.Save();
            return RedirectToAction("Index");
        }
    }
}