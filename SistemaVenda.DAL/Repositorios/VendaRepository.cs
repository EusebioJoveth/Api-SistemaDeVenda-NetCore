using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DAL.DBContext;
using SistemaVenda.DAL.Repositorios.Contrato;
using SistemaVenda.Model;

namespace SistemaVenda.DAL.Repositorios
{
    public class VendaRepository:GenericRepository<Venda>, IVendaRepository
    {
        private readonly DbvendaContext _dbContext;

        public VendaRepository(DbvendaContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venda>Registar(Venda modelo)
        {
            Venda vendaGerada = new Venda();

            using(var transation = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach(DetalheVenda dv in modelo.DetalheVenda)
                    {
                        Produto produto_encontrado = _dbContext.Produtos.Where(p => p.IdProduto == dv.IdProduto).First();

                        produto_encontrado.Stock = produto_encontrado.Stock - dv.Quantidade;
                        _dbContext.Produtos.Update(produto_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();

                    NumeroDocumento provisiorio = _dbContext.NumeroDocumentos.First();
                    provisiorio.UltimoNumero = provisiorio.UltimoNumero + 1;
                    provisiorio.DataActualizacao = DateTime.Now;

                    _dbContext.NumeroDocumentos.Update(provisiorio);
                    await _dbContext.SaveChangesAsync();

                    int quantidadeDigitos = 4;
                    string zeros = string.Concat(Enumerable.Repeat("0", quantidadeDigitos));
                    string numeroVenda = zeros + provisiorio.UltimoNumero.ToString();
                    
                    //00001
                    numeroVenda = numeroVenda.Substring(numeroVenda.Length - quantidadeDigitos, quantidadeDigitos);

                    modelo.NumeroDocumento = numeroVenda;

                    await _dbContext.Venda.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    vendaGerada = modelo;

                    transation.Commit();

                }
                catch
                {
                    transation.Rollback();
                    throw;

                }

                return vendaGerada;
            }
        }
    }
}
