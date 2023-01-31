using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class Imposto
{
    public int IdImposto { get; set; }

    public string? Nome { get; set; }

    public decimal? Taxa { get; set; }

    public string? Descricao { get; set; }

    public DateTime? DataRegisto { get; set; }

    public DateTime? DataActualizacao { get; set; }

    public virtual ICollection<Produto> Produtos { get; } = new List<Produto>();
}
