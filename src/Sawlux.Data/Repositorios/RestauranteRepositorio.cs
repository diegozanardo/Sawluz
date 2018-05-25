using Sawlux.Data.Base;
using Sawlux.Data.Contexto;
using Sawluz.Model;

namespace Sawlux.Data.Repositorios
{
    public class RestauranteRepositorio : RepositorioBase<Restaurante>, IRestauranteRepositorio
    {
        public RestauranteRepositorio(SawluxContexto repo)
            : base(repo)
        {
        }
    }
}
