using Sawlux.Data.Base;
using Sawlux.Data.Contexto;
using Sawluz.Model;

namespace Sawlux.Data.Repositorios
{
    public class PratoRepositorio : RepositorioBase<Prato>
    {
        public PratoRepositorio(SawluxContexto repo)
            : base(repo)
        {
        }
    }
}