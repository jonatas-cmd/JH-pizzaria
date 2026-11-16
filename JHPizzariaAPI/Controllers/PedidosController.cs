
using Microsoft.AspNetCore.Mvc;
using JHPizzariaAPI.Models;
using JHPizzariaAPI.Repositories;

namespace JHPizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoRepository _repository = new PedidoRepository();

        [HttpGet]
        public IActionResult Testar()
        {
            return Ok("API da JH Pizzaria funcionando!");
        }

        [HttpPost]
        public IActionResult CadastrarPedido([FromBody] PedidoRequest dados)
        {
            try
            {
                if (dados == null ||
                    string.IsNullOrWhiteSpace(dados.Email) ||
                    dados.Itens == null ||
                    dados.Itens.Count == 0)
                {
                    return BadRequest("Informe o e-mail e os produtos do pedido.");
                }

                int pedidoId = _repository.RegistrarPedido(dados);

                return Ok(new
                {
                    mensagem = "Pedido realizado com sucesso!",
                    pedidoId = pedidoId
                });
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = erro.Message
                });
            }
        }

        [HttpGet("historico")]
        public IActionResult Historico([FromQuery] string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest("Informe o e-mail do cliente.");
                }

                var pedidos = _repository.ListarPedidosPorEmail(email);

                return Ok(pedidos);
            }
            catch (Exception erro)
            {
                return StatusCode(500, new
                {
                    mensagem = "Erro ao consultar pedidos.",
                    detalhe = erro.Message
                });
            }
        }

    }
}
