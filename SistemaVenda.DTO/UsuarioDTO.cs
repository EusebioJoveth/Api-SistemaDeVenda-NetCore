using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.DTO
{
    public  class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string? Nome { get; set; }

        public string? Sobrenome { get; set; }

        public string? Email { get; set; }

        public int? IdRol { get; set; }

        public string? RolDescricao { get; set; }

        public string? Telefone { get; set; }

        public string? Genero { get; set; }

        public string? Foto { get; set; }

        public string? Pasword { get; set; }

        public int? IsActivo { get; set; }
    }
}
