using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class Venda
{
    public int IdVenda { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? TipoPagamento { get; set; }

    public decimal? Total { get; set; }

    public DateTime? DataRegisto { get; set; }

    public DateTime? DataActualizacao { get; set; }

    public virtual ICollection<DetalheVenda> DetalheVenda { get; } = new List<DetalheVenda>();
}
