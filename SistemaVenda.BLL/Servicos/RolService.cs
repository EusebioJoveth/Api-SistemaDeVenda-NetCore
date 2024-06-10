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
    public class RolService: IRoleService
    {
        private readonly IGenericRepository<Rol> _rolRepositorio;
        private readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> rolRepositorio, IMapper mapper)
        {
            _rolRepositorio = rolRepositorio;
            _mapper = mapper;
        }

        public async Task<List<RolDTO>> Lista()
        {
            try
            {
                var listaRoles = await _rolRepositorio.Consultar();
                return _mapper.Map<List<RolDTO>>(listaRoles.ToList());

            }
            catch
            {
                throw;

            }
        }

        public async Task<RolDTO> Criar(RolDTO modelo)
        {
            try
            {
                var rolCriado = await _rolRepositorio.Criar(_mapper.Map<Rol>(modelo));
                if (rolCriado.IdRol == 0)
                    throw new TaskCanceledException("Não foi possível Criar");

                return _mapper.Map<RolDTO>(rolCriado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(RolDTO modelo)
        {
            try
            {
                var rolModelo = _mapper.Map<Rol>(modelo);
                var rolEncontrado = await _rolRepositorio.Listar(menu => menu.IdRol == rolModelo.IdRol);

                if (rolEncontrado == null)
                    throw new TaskCanceledException("Rol não existe");

                rolEncontrado.Nome = rolModelo.Nome;
               
                bool resposta = await _rolRepositorio.Editar(rolEncontrado);

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
                var menuEncontrado = await _rolRepositorio.Listar(menu => menu.IdRol == id);
                if (menuEncontrado == null)
                    throw new TaskCanceledException("Não Existe o Menu");

                bool resposta = await _rolRepositorio.Eliminar(menuEncontrado);

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
