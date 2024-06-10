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
    public class RolController : ControllerBase
    {
        private readonly IRoleService _rolService;

        public RolController(IRoleService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<RolDTO>>();

            try
            {
                response.status = true;
                response.valor = await _rolService.Lista();

            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg= ex.Message;

            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar([FromBody] RolDTO rol)
        {
            var response = new Response<RolDTO>();
            try
            {
                response.status = true;
                response.valor = await _rolService.Criar(rol);

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
        public async Task<IActionResult> Editar([FromBody] RolDTO rol)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.valor = await _rolService.Editar(rol);

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
                response.valor = await _rolService.Eliminar(id);

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
