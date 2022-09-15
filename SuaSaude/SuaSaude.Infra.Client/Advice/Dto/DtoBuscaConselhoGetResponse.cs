using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuaSaude.Infra.Client.Advice.Dto
{
    public class DtoBuscaConselhoGetResponse
    {
        public Slip slip { get; set; }
        public class Slip
        {
            public int id { get; set; }
            public string advice { get; set; }
        }
    }
}
