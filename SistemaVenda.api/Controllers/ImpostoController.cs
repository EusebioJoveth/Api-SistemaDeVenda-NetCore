using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaVenda.BLL.Servicos.Contrato;
using SistemaVenda.DTO;
using SistemaVenda.api.Utilidade;


namespace SistemaVenda.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpostoController : ControllerBase
    {
        private readonly IImpostoService _impostoService;

        public ImpostoController(IImpostoService impostoService)
        {
            _impostoService = impostoService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<ImpostoDTO>>();
            try
            {
                response.status = true;
                response.valor = await _impostoService.Lista();

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
        public async Task<IActionResult> Criar([FromBody] ImpostoDTO imposto)
        {
            var response = new Response<ImpostoDTO>();
            try
            {
                response.status = true;
                response.valor = await _impostoService.Criar(imposto);

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
        public async Task<IActionResult> Editar([FromBody] ImpostoDTO imposto)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.valor = await _impostoService.Editar(imposto);

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
                response.valor = await _impostoService.Eliminar(id);

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
