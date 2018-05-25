using Sawlux.Service.Base;
using Sawluz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawlux.Service.Services
{
    public interface IPratoService : IServiceBase<Prato>
    {
        void Cadastro(Prato prato, int resturanteId);
    }
}
