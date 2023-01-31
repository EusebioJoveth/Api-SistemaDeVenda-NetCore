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
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioService(IGenericRepository<Usuario> usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> Lista()
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar();
                var listaUsuario = queryUsuario.Include(rol => rol.IdRolNavigation).ToList();

                return _mapper.Map<List<UsuarioDTO>>(listaUsuario);

            }
            catch
            {
                throw;

            }
        }

        public async Task<SessaoDTO> ValidarCredenciais(string email, string password)
        {
            try {
                var queryUsuario = await _usuarioRepositorio.Consultar(user =>
                user.Email == email && user.Pasword == password
                );

                if(queryUsuario.FirstOrDefault() == null)
                    throw new TaskCanceledException("O Usuario não existe");
                Usuario devolverUsrio = queryUsuario.Include(rol => rol.IdRolNavigation).First();

                return _mapper.Map<SessaoDTO>(devolverUsrio);
            } 
            catch {
                throw;
            }
        }

        public async Task<UsuarioDTO> Criar(UsuarioDTO modelo)
        {
            try
            {
                var usuarioCriado = await _usuarioRepositorio.Criar(_mapper.Map<Usuario>(modelo));

                if (usuarioCriado.IdUsuario == 0)
                    throw new TaskCanceledException("Não foi possível Criar Usuário");
                var query = await _usuarioRepositorio.Consultar(user => user.IdUsuario == usuarioCriado.IdUsuario);
                usuarioCriado = query.Include(rol => rol.IdRolNavigation).First();

                return _mapper.Map<UsuarioDTO>(usuarioCriado);

            }
            catch
            {
                throw;

            }
        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var usuarioModelo = _mapper.Map<Usuario>(modelo);
                var usuarioEncontrado = await _usuarioRepositorio.Listar(user => user.IdUsuario == usuarioModelo.IdUsuario);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("Usuario não encontrado");

                usuarioEncontrado.Nome = usuarioModelo.Nome;
                usuarioEncontrado.Sobrenome = usuarioModelo.Sobrenome;
                usuarioEncontrado.IdRol = usuarioModelo.IdRol;
                usuarioEncontrado.Pasword = usuarioModelo.Pasword;
                usuarioEncontrado.Email = usuarioModelo.Email;
                usuarioEncontrado.Telefone= usuarioModelo.Telefone;
                usuarioEncontrado.IsActivo = usuarioModelo.IsActivo;
                usuarioEncontrado.Genero= usuarioModelo.Genero;

                bool resposta = await _usuarioRepositorio.Editar(usuarioEncontrado);

                if (!resposta)
                    throw new TaskCanceledException("Não é possivel Actualizar");
                return resposta;
            }
            catch {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Listar(user => user.IdUsuario== id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("Usuário não existe");
                bool resposta = await _usuarioRepositorio.Eliminar(usuarioEncontrado);

                if (!resposta)
                    throw new TaskCanceledException("Não foi possível eliminar");
                return resposta;

            }
            catch
            {
                throw;

            }
        }

       
    }
}
