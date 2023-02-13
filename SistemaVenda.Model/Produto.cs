using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string? Nome { get; set; }
    public string? Codigo { get; set; }

    public int? Tipo { get; set; }

    public string? Unidade { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdMarca { get; set; }

    public int? IdImposto { get; set; }

    public int? Stock { get; set; }

    public decimal? Preco { get; set; }

    public bool? IsActivo { get; set; }

    public string? Foto { get; set; }

    public DateTime? DataRegisto { get; set; }

    public DateTime? DataActualizacao { get; set; }

    public virtual ICollection<DetalheVenda> DetalheVenda { get; } = new List<DetalheVenda>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Imposto? IdImpostoNavigation { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}
