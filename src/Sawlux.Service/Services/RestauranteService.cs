using Sawlux.Data.Contexto;
using Sawlux.Data.Repositorios;
using Sawlux.Service.Base;
using Sawluz.Model;
using System.Linq;

namespace Sawlux.Service.Services
{
    public class RestauranteService : ServiceBase<Restaurante>, IRestauranteService
    {
        public RestauranteService(IRestauranteRepositorio repo)
            : base(repo)
        {
        }

        public void Cadastro(Restaurante restaurante)
        {
            if (restaurante.Id > 0)
            {
                var restauranteBd = Get(x => x.Id == restaurante.Id).FirstOrDefault();
                restauranteBd.Nome = restaurante.Nome;
                Update(restauranteBd);
            }
            else
            {
                Add(restaurante);
            }

            Save();
        }
    }
}
