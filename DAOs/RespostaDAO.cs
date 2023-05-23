using Dapper;
using Dapper.Contrib.Extensions;
using mysqlAPI.DTOs;
using MySqlConnector;
using System.Data.SqlClient;

namespace iBookApi.DAOs
{
    public class RespostaDAO : BaseDAO
    {
        public RespostaDAO() : base()
        {
        }

        public List<respostaDTO> ConsultarAllRespostasPorComentario(int comid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<respostaDTO>("Select * from RESPOSTAS Where comid = @comid", new { comid = comid }).ToList();
            }
        }

        public List<respostaDTO> ConsultarAllRespostasPorUsu(int usuid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<respostaDTO>("Select * from RESPOSTAS Where usuid = @usuid", new { usuid = usuid }).ToList();
            }
        }
        public long InserirResposta(respostaDTO resposta)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Insert(resposta);
            }
        }

        public void AtualizarResposta(respostaDTO resposta)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Update(resposta);
            }
        }

        public void DeletarResposta(respostaDTO resposta)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Delete<respostaDTO>(resposta);
            }
        }


    }
}
