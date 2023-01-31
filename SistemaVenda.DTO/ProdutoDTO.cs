using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public class ProdutoDTO
    {
        public int IdProduto { get; set; }

        public string? Nome { get; set; }

        public int? Tipo { get; set; }

        public string? Unidade { get; set; }

        public int? IdCategoria { get; set; }
        public string? DescricaoCategoria { get; set; }

        public int? IdMarca { get; set; }
        public string? DescricaoMarca { get; set; }

        public int? IdImposto { get; set; }
        public string? DescricaoImposto { get; set; }

        public int? Stock { get; set; }

        public string? Preco { get; set; }

        public int? IsActico { get; set; }

        public string? Foto { get; set; }

        public string? DataActualizacao { get; set; }
    }
}
