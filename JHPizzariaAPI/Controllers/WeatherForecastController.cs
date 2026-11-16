
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using JHPizzariaAPI;

namespace JHPizzariaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("TestarBanco")]
        public IActionResult TestarBanco()
        {
            try
            {
                using (MySqlConnection conexao = Conexao.ObterConexao())
                {
                    conexao.Open();
                    return Ok("Conexão com o banco logp realizada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro na conexão: " + ex.Message);
            }
        }
    }
}
