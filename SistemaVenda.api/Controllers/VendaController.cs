using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaVenda.BLL.Servicos.Contrato;
using SistemaVenda.DTO;
using SistemaVenda.api.Utilidade;

namespace SistemaVenda.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar([FromBody] VendaDTO venda)
        {
            var response = new Response<VendaDTO>();
            try
            {
                response.status = true;
                response.valor = await _vendaService.Registar(venda);

            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;

            }

            return Ok(response);
        }


        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenda, string? dataInicio, string? dataFim)
        {
            var response = new Response<List<VendaDTO>>();
            numeroVenda = numeroVenda is null? "": numeroVenda;
            dataInicio = dataInicio is null ? "" : dataInicio;
            dataFim = dataFim is null ? "" : dataFim;

            try
            {
                response.status = true;
                response.valor = await _vendaService.Historico(buscarPor, numeroVenda, dataInicio, dataFim);

            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;

            }

            return Ok(response);
        }


        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? dataInicio, string? dataFim)
        {
            var response = new Response<List<ReporteDTO>>();
        

            try
            {
                response.status = true;
                response.valor = await _vendaService.Reporte(dataInicio, dataFim);

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
