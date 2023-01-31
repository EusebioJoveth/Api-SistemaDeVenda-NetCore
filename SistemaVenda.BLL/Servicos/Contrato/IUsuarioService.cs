using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DTO;

namespace SistemaVenda.BLL.Servicos.Contrato
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>>Lista();
        Task<SessaoDTO>ValidarCredenciais(string email, string password);
        Task<UsuarioDTO> Criar(UsuarioDTO modelo);
        Task<bool> Editar(UsuarioDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
