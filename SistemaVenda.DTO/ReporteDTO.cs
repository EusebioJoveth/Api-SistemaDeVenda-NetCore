using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public class ReporteDTO
    {
        public string? NumeroDocumento { get; set; }
        public string? TipoPagamento { get; set; }
        public string? DataRegisto { get; set; }
        public string? TotalVenda { get; set; }
        public string? Produto { get; set; }
        public int? Quantidade { get; set; }
        public string? Preco { get; set; }
        public string? Total { get; set; }
    }
}
