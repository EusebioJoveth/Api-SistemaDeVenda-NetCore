using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaVenda.BLL.Servicos.Contrato;
using SistemaVenda.DTO;
using SistemaVenda.api.Utilidade;
using SistemaVenda.BLL.Servicos;

namespace SistemaVenda.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idUsuario)
        {
            var response = new Response<List<MenuDTO>>();
            try
            {
                response.status = true;
                response.valor = await _menuService.Lista(idUsuario);

            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;

            }

            return Ok(response);
        }

        [HttpGet]
        [Route("Menus")]
        public async Task<IActionResult> Menus()
        {
            var response = new Response<List<MenuDTO>>();
            try
            {
                response.status = true;
                response.valor = await _menuService.Menus();

            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;

            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar([FromBody] MenuDTO menu)
        {
            var response = new Response<MenuDTO>();
            try
            {
                response.status = true;
                response.valor = await _menuService.Criar(menu);

            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;

            }

            return Ok(response);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] MenuDTO menu)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.valor = await _menuService.Editar(menu);

            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;

            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.valor = await _menuService.Eliminar(id);

            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;

            }

            return Ok(response);
        }
    }
}
