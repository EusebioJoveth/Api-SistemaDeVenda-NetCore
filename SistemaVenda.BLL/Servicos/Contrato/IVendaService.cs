using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DTO;

namespace SistemaVenda.BLL.Servicos.Contrato
{
    public interface IVendaService
    {
        Task<VendaDTO> Registar(VendaDTO modelo);
        Task<List<VendaDTO>> Historico(string buscarPor, string numeroVenda, string dataInicio, string dataFim);
        Task<List<ReporteDTO>> Reporte(string dataInicio, string dataFim);
    }
}
