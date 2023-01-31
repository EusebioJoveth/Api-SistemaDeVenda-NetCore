using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaVenda.BLL.Servicos.Contrato;
using SistemaVenda.DAL.Repositorios.Contrato;
using SistemaVenda.DTO;
using SistemaVenda.Model;

namespace SistemaVenda.BLL.Servicos
{
    public class CategoriaService: ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepositorio;
        private readonly IMapper _mapper;

        public CategoriaService(IGenericRepository<Categoria> categoriaRepositorio, IMapper maper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = maper;
        }

        public async Task<List<CategoriaDTO>> Lista()
        {
            try
            {
                var listaCategoria = await _categoriaRepositorio.Consultar();
                return _mapper.Map<List<CategoriaDTO>>(listaCategoria.ToList());

            }
            catch
            {
                throw;

            }
        }

        public async Task<CategoriaDTO> Criar(CategoriaDTO modelo)
        {
            try
            {
                var categoriaCriada = await _categoriaRepositorio.Criar(_mapper.Map<Categoria>(modelo));
                if (categoriaCriada.IdCategoria == 0)
                    throw new TaskCanceledException("Não foi possível Criar");

                return _mapper.Map<CategoriaDTO>(categoriaCriada);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CategoriaDTO modelo)
        {
            try
            {
                var categoriaModelo = _mapper.Map<Categoria>(modelo);
                var categoriaEncontrado = await _categoriaRepositorio.Listar(cat => cat.IdCategoria == categoriaModelo.IdCategoria);

                if (categoriaEncontrado == null)
                    throw new TaskCanceledException("Categoria não existe");

                categoriaEncontrado.Nome = categoriaModelo.Nome;
                categoriaEncontrado.Descricao = categoriaModelo.Descricao;
                categoriaEncontrado.IsActivo = categoriaModelo.IsActivo;

                bool resposta = await _categoriaRepositorio.Editar(categoriaEncontrado);

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
                var categoriaEncontrada = await _categoriaRepositorio.Listar(cat => cat.IdCategoria == id);
                if (categoriaEncontrada == null)
                    throw new TaskCanceledException("Não Existe Categoria");

                bool resposta = await _categoriaRepositorio.Eliminar(categoriaEncontrada);

                if (!resposta)
                    throw new TaskCanceledException("Não é possível eliminar");
                return resposta;
            }
            catch
            {
                throw;
            }
        }

    }
}
