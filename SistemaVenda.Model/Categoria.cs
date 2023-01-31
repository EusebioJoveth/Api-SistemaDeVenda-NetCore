using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Nome { get; set; }

    public bool? IsActivo { get; set; }

    public string? Descricao { get; set; }

    public DateTime? DataRegisto { get; set; }

    public DateTime? DataActualizacao { get; set; }

    public virtual ICollection<Produto> Produtos { get; } = new List<Produto>();
}
