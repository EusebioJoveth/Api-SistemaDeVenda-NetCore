using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public class DashBoardDTO
    {
        public int TotalVendas { get; set; }
        public string? ToatalRendas { get; set; }
        public int TotalProdutos { get; set; }
        public List<VendaSemanaDTO> VendasUltimaSemana { get; set; }
    }
}
