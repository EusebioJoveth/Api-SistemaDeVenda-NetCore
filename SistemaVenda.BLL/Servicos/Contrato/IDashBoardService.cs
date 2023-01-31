using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DTO;

namespace SistemaVenda.BLL.Servicos.Contrato
{
    public interface IDashBoardService
    {
        Task<DashBoardDTO> Resumo();  
    }
}
