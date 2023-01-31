using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DTO;

namespace SistemaVenda.BLL.Servicos.Contrato
{
    public interface IImpostoService
    {
        Task<List<ImpostoDTO>> Lista();
        Task<ImpostoDTO> Criar(ImpostoDTO modelo);
        Task<bool> Editar(ImpostoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
