﻿using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Nome { get; set; }

    public string? Icone { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; } = new List<MenuRol>();
}
