using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public class ImpostoDTO
    {
        public int IdImposto { get; set; }

        public string? Nome { get; set; }

        public string? Taxa { get; set; }

        public string? Descricao { get; set; }

    }
}
