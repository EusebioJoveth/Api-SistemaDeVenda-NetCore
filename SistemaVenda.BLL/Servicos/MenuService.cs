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
    public class MenuService: IMenuService
    {
        private readonly IGenericRepository<Usuario> _usuariosRepository;
        private readonly IGenericRepository<MenuRol> _menuRolRepository;
        private readonly IGenericRepository<Menu> _menuRepository;
        private readonly IMapper _mapper;

        public MenuService(IGenericRepository<Usuario> usuariosRepository, IGenericRepository<MenuRol> menuRolRepository, IGenericRepository<Menu> menuRepository, IMapper mapper)
        {
            _usuariosRepository = usuariosRepository;
            _menuRolRepository = menuRolRepository;
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<List<MenuDTO>> Lista(int idUsuario)
        {
            IQueryable<Usuario> tbUsuario = await _usuariosRepository.Consultar(user => user.IdUsuario == idUsuario);
            IQueryable<MenuRol> tbMenuRol = await _menuRolRepository.Consultar();
            IQueryable<Menu> tbMenu = await _menuRepository.Consultar();

            try
            {
                IQueryable<Menu> tbResultado = (from user in tbUsuario
                                                join menuR in tbMenuRol on user.IdRol equals menuR.IdRol
                                                join men in tbMenu on menuR.IdMenu equals men.IdMenu
                                                select men).AsQueryable();
                var listaMenus = tbResultado.ToList();
                return _mapper.Map<List<MenuDTO>>(listaMenus);  

            }
            catch
            {
                throw;

            }
        }

        public async Task<List<MenuDTO>> Menus()
        {
            try
            {
                var listaCategoria = await _menuRepository.Consultar();
                return _mapper.Map<List<MenuDTO>>(listaCategoria.ToList());

            }
            catch
            {
                throw;

            }
        }

        public async Task<MenuDTO> Criar(MenuDTO modelo)
        {
            try
            {
                var menuCriado = await _menuRepository.Criar(_mapper.Map<Menu>(modelo));
                if (menuCriado.IdMenu == 0)
                    throw new TaskCanceledException("Não foi possível Criar");

                return _mapper.Map<MenuDTO>(menuCriado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(MenuDTO modelo)
        {
            try
            {
                var menuModelo = _mapper.Map<Menu>(modelo);
                var menuEncontrado = await _menuRepository.Listar(menu => menu.IdMenu == menuModelo.IdMenu);

                if (menuEncontrado == null)
                    throw new TaskCanceledException("Menu não existe");

                menuEncontrado.Nome = menuModelo.Nome;
                menuEncontrado.Icone = menuModelo.Icone;
                menuEncontrado.Url = menuModelo.Url;

                bool resposta = await _menuRepository.Editar(menuEncontrado);

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
                var menuEncontrado = await _menuRepository.Listar(menu => menu.IdMenu == id);
                if (menuEncontrado == null)
                    throw new TaskCanceledException("Não Existe o Menu");

                bool resposta = await _menuRepository.Eliminar(menuEncontrado);

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
