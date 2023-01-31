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
    public class MarcaService : IMarcaService
    {
        private readonly IGenericRepository<Marca> _marcaRepositorio;
        private readonly IMapper _mapper;

        public MarcaService(IGenericRepository<Marca> marcaRepositorio, IMapper maper)
        {
            _marcaRepositorio = marcaRepositorio;
            _mapper = maper;
        }

        public async Task<List<MarcaDTO>> Lista()
        {
            try
            {
                var listaMarca = await _marcaRepositorio.Consultar();
                return _mapper.Map<List<MarcaDTO>>(listaMarca.ToList());

            }
            catch
            {
                throw;

            }
        }

        public async Task<MarcaDTO> Criar(MarcaDTO modelo)
        {
            try
            {
                var marcaCriada = await _marcaRepositorio.Criar(_mapper.Map<Marca>(modelo));
                if (marcaCriada.IdMarca == 0)
                    throw new TaskCanceledException("Não foi possível Criar");

                return _mapper.Map<MarcaDTO>(marcaCriada);

            }
            catch
            {
                throw;
            }                         
        }

        public async Task<bool> Editar(MarcaDTO modelo)
        {
            try
            {
                var marcaModelo = _mapper.Map<Marca>(modelo);
                var marcaEncontrada = await _marcaRepositorio.Listar(marc => marc.IdMarca == marcaModelo.IdMarca);

                if (marcaEncontrada == null)
                    throw new TaskCanceledException("Marca não existe");

                marcaEncontrada.Nome = marcaModelo.Nome;
                marcaEncontrada.Descricao = marcaModelo.Descricao;
                marcaEncontrada.IsActivo = marcaModelo.IsActivo;

                bool resposta = await _marcaRepositorio.Editar(marcaEncontrada);

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
                var marcaEncontrada = await _marcaRepositorio.Listar(marc => marc.IdMarca == id);
                if (marcaEncontrada == null)
                    throw new TaskCanceledException("Não Existe Marca");

                bool resposta = await _marcaRepositorio.Eliminar(marcaEncontrada);

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
