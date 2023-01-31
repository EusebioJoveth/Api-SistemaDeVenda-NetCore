using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public class VendaDTO
    {
        public int IdVenda { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? TipoPagamento { get; set; }

        public string? Total { get; set; }

        public string? DataRegisto { get; set; }

        public virtual ICollection<DetalheVendaDTO> DetalheVenda { get; set; }
    }
}
