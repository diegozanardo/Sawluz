using Sawlux.Service.Base;
using Sawluz.Model;

namespace Sawlux.Service.Services
{
    public interface IRestauranteService : IServiceBase<Restaurante>
    {
        void Cadastro(Restaurante restaurante);
    }
}
