using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public class MenuDTO
    {
        public int IdMenu { get; set; }

        public string? Nome { get; set; }

        public string? Icone { get; set; }

        public string? Url { get; set; }
    }
}
