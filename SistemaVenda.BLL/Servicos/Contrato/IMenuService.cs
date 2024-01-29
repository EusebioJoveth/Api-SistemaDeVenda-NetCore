using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DTO;

namespace SistemaVenda.BLL.Servicos.Contrato
{
    public interface IMenuService
    {
        Task<List<MenuDTO>> Lista(int idUsuario);
        Task<List<MenuDTO>> Menus();
        Task<MenuDTO> Criar(MenuDTO modelo);
        Task<bool> Editar(MenuDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
