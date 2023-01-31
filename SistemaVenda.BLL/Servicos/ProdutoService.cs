using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.BLL.Servicos.Contrato;
using SistemaVenda.DAL.Repositorios.Contrato;
using SistemaVenda.DTO;
using SistemaVenda.Model;

namespace SistemaVenda.BLL.Servicos
{
    public class ProdutoService: IProdutoService
    {
        private readonly IGenericRepository<Produto> _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IGenericRepository<Produto> produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProdutoDTO>> Lista()
        {
            try
            {
                var queryProduto = await _produtoRepository.Consultar();
                var listaProdutos = queryProduto.Include(cat => cat.IdCategoriaNavigation)
                    .Include(marca => marca.IdMarcaNavigation)
                    .Include(impo => impo.IdImpostoNavigation).ToList();

                return _mapper.Map<List<ProdutoDTO>>(listaProdutos.ToList());
            }
            catch
            {
                throw;

            }
        }

        public async Task<ProdutoDTO> Criar(ProdutoDTO modelo)
        {
            try
            {
                var produtoCriado =await _produtoRepository.Criar(_mapper.Map<Produto>(modelo));
                if(produtoCriado.IdProduto == 0)
                    throw new TaskCanceledException("Não foi possível Criar");

                return _mapper.Map<ProdutoDTO>(produtoCriado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProdutoDTO modelo)
        {
            try
            {
                var produtoModelo = _mapper.Map<Produto>(modelo);
                var produtoEncontrado = await _produtoRepository.Listar(prod => prod.IdProduto == produtoModelo.IdProduto);

                if (produtoEncontrado == null)
                    throw new TaskCanceledException("Produto não existe");
                
                produtoEncontrado.Nome= produtoModelo.Nome;
                produtoEncontrado.IdCategoria = produtoModelo.IdCategoria;
                produtoEncontrado.IdMarca= produtoModelo.IdMarca;
                produtoEncontrado.IdImposto = produtoModelo.IdImposto;
                produtoEncontrado.Stock = produtoModelo.Stock;
                produtoEncontrado.IsActico= produtoModelo.IsActico;
                produtoEncontrado.Tipo= produtoModelo.Tipo;
                produtoEncontrado.Unidade= produtoModelo.Unidade;   
                produtoEncontrado.Foto= produtoModelo.Foto; 

                bool resposta = await _produtoRepository.Editar(produtoEncontrado);

                if (!resposta)
                    throw new TaskCanceledException("Não é possível actualizar");
                return resposta;


            }
            catch
            {
                throw;

            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var produtoEncontrado = await _produtoRepository.Listar(prod => prod.IdProduto== id);
                if (produtoEncontrado == null)
                    throw new TaskCanceledException("Não Existe Produto");

                bool resposta = await _produtoRepository.Eliminar(produtoEncontrado);

                if (!resposta)
                    throw new TaskCanceledException("Não é possível eliminar");
                return resposta;
            }
            catch {
                throw; 
            }
        }

       
    }
}
