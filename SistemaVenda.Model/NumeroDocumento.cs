using System;
using System.Collections.Generic;

namespace SistemaVenda.Model;

public partial class NumeroDocumento
{
    public int IdNumeroDocumento { get; set; }

    public int UltimoNumero { get; set; }

    public DateTime? DataRegisto { get; set; }

    public DateTime? DataActualizacao { get; set; }
}
