using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DTO;

namespace SistemaVenda.BLL.Servicos.Contrato
{
    public interface IRoleService
    {
        Task<List<RolDTO>> Lista();
        Task<RolDTO> Criar(RolDTO modelo);
        Task<bool> Editar(RolDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
