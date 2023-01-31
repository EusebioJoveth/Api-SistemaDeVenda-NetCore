using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public int? IsActivo { get; set; }
      


    }
}
