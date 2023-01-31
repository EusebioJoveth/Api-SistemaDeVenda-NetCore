using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public class SessaoDTO
    {
        public int? IdUsuario { get; set; }

        public string? NomeCompleto { get; set; }

        public string? Email { get; set; }

        public int? IdRol { get; set; }

        public string? RolDescricao { get; set; }
    }
}
