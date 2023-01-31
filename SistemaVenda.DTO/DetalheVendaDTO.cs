using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public class DetalheVendaDTO
    {
        public int? IdProduto { get; set; }
        public string? DescricaoProduto { get; set; }

        public int? Quantidade { get; set; }

        public string? Preco { get; set; }

        public string? Desconto { get; set; }

        public string? Total { get; set; }
    }
}
