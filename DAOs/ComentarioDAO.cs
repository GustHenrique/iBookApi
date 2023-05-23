using Dapper;
using Dapper.Contrib.Extensions;
using mysqlAPI.DTOs;
using MySqlConnector;
using System.Data.SqlClient;

namespace iBookApi.DAOs
{
    public class ComentarioDAO : BaseDAO
    {
        public ComentarioDAO() : base()
        {
        }

        public List<comentarioDTO> ConsultarAllComentariosPorObra(int obid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<comentarioDTO>("Select * from COMENTARIOS Where obid = @obid", new { obid = obid }).ToList();
            }
        }

        public List<comentarioDTO> ConsultarAllComentariosPorUsu(int usuid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<comentarioDTO>("Select * from COMENTARIOS Where usuid = @usuid", new { usuid = usuid }).ToList();
            }
        }

        public List<respostaDTO> ConsultarAllRespostasComentario(int comid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<respostaDTO>("Select * from RESPOSTA Where comid = @comid", new { obcomidid = comid }).ToList();
            }
        }
        public long InserirComentario(comentarioDTO obra)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Insert(obra);
            }
        }

        public void AtualizarComentario(comentarioDTO obra)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Update(obra);
            }
        }

        public void DeletarComentario(comentarioDTO obra)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Delete<comentarioDTO>(obra);
            }
        }


    }
}
