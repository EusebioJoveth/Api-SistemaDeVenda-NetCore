using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Nome { get; set; }

    public DateTime? DataRegisto { get; set; }

    public DateTime? DataActualizacao { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; } = new List<MenuRol>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
