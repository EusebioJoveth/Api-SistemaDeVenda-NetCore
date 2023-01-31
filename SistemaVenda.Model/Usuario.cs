using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nome { get; set; }

    public string? Sobrenome { get; set; }

    public string? Email { get; set; }

    public int? IdRol { get; set; }

    public string? Telefone { get; set; }

    public string? Genero { get; set; }

    public string? Foto { get; set; }

    public string? Pasword { get; set; }

    public bool? IsActivo { get; set; }

    public DateTime? DataRegisto { get; set; }

    public DateTime? DataActualizacao { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
