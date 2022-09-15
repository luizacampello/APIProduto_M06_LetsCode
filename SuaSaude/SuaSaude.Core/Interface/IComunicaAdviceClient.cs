using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuaSaude.Core.Interface
{
    public interface IComunicaAdviceClient
    {
        Task<string> BuscarConselhoAsync();
    }
}
