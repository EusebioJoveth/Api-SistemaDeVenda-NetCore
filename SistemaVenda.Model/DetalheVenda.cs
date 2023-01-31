using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class DetalheVenda
{
    public int IdDetalheVenda { get; set; }

    public int? IdVenda { get; set; }

    public int? IdProduto { get; set; }

    public int? Quantidade { get; set; }

    public decimal? Preco { get; set; }

    public decimal? Desconto { get; set; }

    public decimal? Total { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }

    public virtual Venda? IdVendaNavigation { get; set; }
}
