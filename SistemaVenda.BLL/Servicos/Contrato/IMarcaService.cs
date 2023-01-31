using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DTO;

namespace SistemaVenda.BLL.Servicos.Contrato
{
    public interface IMarcaService
    {
        Task<List<MarcaDTO>> Lista(); 
        Task<MarcaDTO> Criar(MarcaDTO modelo);
        Task<bool> Editar(MarcaDTO modelo); 
        Task<bool> Eliminar(int id);
    }
}
