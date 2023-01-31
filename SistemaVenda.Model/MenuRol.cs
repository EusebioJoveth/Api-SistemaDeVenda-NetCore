using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class MenuRol
{
    public int IdMenuRol { get; set; }

    public int? IdMenu { get; set; }

    public int? IdRol { get; set; }

    public DateTime? DataRegisto { get; set; }

    public DateTime? DataActualizacao { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
