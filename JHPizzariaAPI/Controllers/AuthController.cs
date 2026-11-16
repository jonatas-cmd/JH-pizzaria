using Microsoft.AspNetCore.Mvc;
using JHPizzariaAPI.Models;
using JHPizzariaAPI.Repositories;
using JHPizzariaAPI.Models;
namespace JHPizzariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _repository = new AuthRepository();

        [HttpPost("cadastro")]
        public IActionResult Cadastrar([FromBody] CadastroRequest dados)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dados.Nome) ||
                    string.IsNullOrWhiteSpace(dados.Email) ||
                    string.IsNullOrWhiteSpace(dados.Senha))
                {
                    return BadRequest("Preencha nome, e-mail e senha.");
                }

                if (dados.Senha.Length < 6)
                {
                    return BadRequest("A senha deve ter pelo menos 6 caracteres.");
                }

                int clienteId = _repository.Cadastrar(dados);

                return Ok(new
                {
                    mensagem = "Cadastro realizado com sucesso!",
                    clienteId = clienteId
                });
            }
            catch (Exception erro)
            {
                return StatusCode(500, new
                {
                    mensagem = "Erro ao realizar cadastro.",
                    detalhe = erro.Message
                });
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest dados)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dados.Email) ||
                    string.IsNullOrWhiteSpace(dados.Senha))
                {
                    return BadRequest("Informe e-mail e senha.");
                }

                bool valido = _repository.ValidarLogin(
                    dados.Email, dados.Senha);

                if (!valido)
                {
                    return Unauthorized(new
                    {
                        mensagem = "E-mail ou senha incorretos."
                    });
                }

                return Ok(new
                {
                    mensagem = "Login realizado com sucesso!"
                });
            }
            catch (Exception erro)
            {
                return StatusCode(500, new
                {
                    mensagem = "Erro ao realizar login.",
                    detalhe = erro.Message
                });
            }
        }
    }
}