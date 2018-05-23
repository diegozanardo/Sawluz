using Sawlux.Data.Contexto;
using Sawlux.Data.Repositorios;
using Sawlux.Service.Base;
using Sawluz.Model;

namespace Sawlux.Service.Services
{
    public class RestauranteService : ServiceBase<Restaurante>
    {
        public RestauranteService(SawluxContexto repo)
            : base(new RestauranteRepositorio(repo))
        {
        }
    }
}
