using Sawlux.Data.Base;
using Sawlux.Data.Contexto;
using Sawluz.Model;

namespace Sawlux.Data.Repositorios
{
    public class PratoRepositorio : RepositorioBase<Prato>, IPratoRepositorio
    {
        public PratoRepositorio(SawluxContexto repo)
            : base(repo)
        {
        }
    }
}