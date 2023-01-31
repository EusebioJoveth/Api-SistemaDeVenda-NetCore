using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DTO;

namespace SistemaVenda.BLL.Servicos.Contrato
{
    public interface IProdutoService
    {
        Task<List<ProdutoDTO>> Lista();
        Task<ProdutoDTO> Criar(ProdutoDTO produtoDTO);
        Task<bool>Editar(ProdutoDTO produtoDTO);
        Task<bool> Eliminar(int id);
    }
}
