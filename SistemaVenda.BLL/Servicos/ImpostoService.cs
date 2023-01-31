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
    public class ImpostoService : IImpostoService
    {
        private readonly IGenericRepository<Imposto> _impostoRepositorio;
        private readonly IMapper _mapper;

        public ImpostoService(IGenericRepository<Imposto> impostoRepositorio, IMapper maper)
        {
            _impostoRepositorio = impostoRepositorio;
            _mapper = maper;
        }

        public async Task<List<ImpostoDTO>> Lista()
        {
            try
            {
                var listaImposto = await _impostoRepositorio.Consultar();
                return _mapper.Map<List<ImpostoDTO>>(listaImposto.ToList());

            }
            catch
            {
                throw;

            }
        }

        public async Task<ImpostoDTO> Criar(ImpostoDTO modelo)
        {
            try
            {
                var impostoCriado = await _impostoRepositorio.Criar(_mapper.Map<Imposto>(modelo));
                if (impostoCriado.IdImposto == 0)
                    throw new TaskCanceledException("Não foi possível Criar");

                return _mapper.Map<ImpostoDTO>(impostoCriado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ImpostoDTO modelo)
        {
            try
            {
                var impostoModelo = _mapper.Map<Imposto>(modelo);
                var impostoEncontrada = await _impostoRepositorio.Listar(impo => impo.IdImposto == impostoModelo.IdImposto);

                if (impostoEncontrada == null)
                    throw new TaskCanceledException("Imposto não existe");

                impostoEncontrada.Nome = impostoModelo.Nome;
                impostoEncontrada.Descricao = impostoModelo.Descricao;
                impostoEncontrada.Taxa = impostoModelo.Taxa;

                bool resposta = await _impostoRepositorio.Editar(impostoEncontrada);

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
                var impostoEncontrado = await _impostoRepositorio.Listar(imp => imp.IdImposto == id);
                if (impostoEncontrado == null)
                    throw new TaskCanceledException("Não Existe Imposto");

                bool resposta = await _impostoRepositorio.Eliminar(impostoEncontrado);

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
