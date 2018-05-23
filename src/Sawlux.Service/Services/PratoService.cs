using Sawlux.Data.Contexto;
using Sawlux.Data.Repositorios;
using Sawlux.Service.Base;
using Sawluz.Model;

namespace Sawlux.Service.Services
{
    public class PratoService : ServiceBase<Prato>
    {
        public PratoService(SawluxContexto repo)
            : base(new PratoRepositorio(repo))
        {
        }
    }
}