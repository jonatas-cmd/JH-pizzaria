
using MySql.Data.MySqlClient;

namespace JHPizzariaAPI
{
    public class Conexao
    {
        private static string conexao =
            "Server=localhost;Database=logp;Uid=root;Pwd=Jonatas2010@@;";

        public static MySqlConnection ObterConexao()
        {
            return new MySqlConnection(conexao);
        }
    }
}
