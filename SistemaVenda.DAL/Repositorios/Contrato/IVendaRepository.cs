using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenda.Model;

namespace SistemaVenda.DAL.Repositorios.Contrato
{
    public interface IVendaRepository:IGenericRepository<Venda>
    {
        Task<Venda> Registar(Venda modelo);
    }
}
