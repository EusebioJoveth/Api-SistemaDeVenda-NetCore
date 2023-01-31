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
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<MarcaDTO>>();
            try
            {
                response.status = true;
                response.valor = await _marcaService.Lista();

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
        public async Task<IActionResult> Criar([FromBody] MarcaDTO marca)
        {
            var response = new Response<MarcaDTO>();
            try
            {
                response.status = true;
                response.valor = await _marcaService.Criar(marca);

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
        public async Task<IActionResult> Editar([FromBody] MarcaDTO marca)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.valor = await _marcaService.Editar(marca);

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
                response.valor = await _marcaService.Eliminar(id);

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
