using Sawlux.Data.Contexto;
using Sawlux.Data.Repositorios;
using Sawlux.Service.Base;
using Sawluz.Model;
using System.Linq;

namespace Sawlux.Service.Services
{
    public class PratoService : ServiceBase<Prato>, IPratoService
    {
        IRestauranteService restauranteService;

        public PratoService(IPratoRepositorio repo, IRestauranteService restauranteService)
            : base(repo)
        {
            this.restauranteService = restauranteService;
        }

        public void Cadastro(Prato prato, int restauranteId)
        {
            var restaurante = restauranteService.Get(x => x.Id == restauranteId).FirstOrDefault();
            if (restaurante != null)
                prato.Restaurante = restaurante;

            if (prato.Id > 0)
            {
                var pratoBd = Get(x => x.Id == prato.Id).FirstOrDefault();
                pratoBd.Nome = prato.Nome;
                pratoBd.Restaurante = prato.Restaurante;
                pratoBd.Preco = prato.Preco;
                Update(pratoBd);
            }
            else
            {
                Add(prato);
            }

            Save();
        }
    }
}