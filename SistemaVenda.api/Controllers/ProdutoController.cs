using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaVenda.BLL.Servicos.Contrato;
using SistemaVenda.DTO;
using SistemaVenda.api.Utilidade;

namespace SistemaVenda.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<ProdutoDTO>>();
            try
            {
                response.status = true;
                response.valor = await _produtoService.Lista();

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
        public async Task<IActionResult> Criar([FromBody] ProdutoDTO produto)
        {
            var response = new Response<ProdutoDTO>();
            try
            {
                response.status = true;
                response.valor = await _produtoService.Criar(produto);

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
        public async Task<IActionResult> Editar([FromBody]ProdutoDTO produto)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.valor = await _produtoService.Editar(produto);

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
                response.valor = await _produtoService.Eliminar(id);

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
