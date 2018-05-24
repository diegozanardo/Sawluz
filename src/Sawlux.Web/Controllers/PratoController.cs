using Sawlux.Data.Contexto;
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
        readonly PratoService pratoService;
        readonly RestauranteService restauranteService;

        public PratoController()
        {
            contexto = new SawluxContexto();
            pratoService = new PratoService(contexto);
            restauranteService = new RestauranteService(contexto);
        }
        // GET: Prato
        public ActionResult Index()
        {
            var pratos = pratoService.GetAll().ToList();
            var pratosVM = new List<PratoVM>();
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
                var restaurante = restauranteService.Get(x => x.Id == restauranteId).FirstOrDefault();

                if (pratoVM.Id > 0)
                    prato = pratoService.Get(x => x.Id == pratoVM.Id).FirstOrDefault();

                prato.Nome = pratoVM.Nome;
                prato.Preco = pratoVM.Preco;
                prato.Restaurante = restaurante;

                if (pratoVM.Id > 0)
                    pratoService.Update(prato);
                else
                    pratoService.Add(prato);

                pratoService.Save();
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