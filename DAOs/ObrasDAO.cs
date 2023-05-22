using Dapper;
using Dapper.Contrib.Extensions;
using mysqlAPI.DTOs;
using MySqlConnector;
using System.Data.SqlClient;

namespace iBookApi.DAOs
{
    public class ObrasDAO : BaseDAO
    {
        public ObrasDAO() : base()
        {
        }

        public long InserirObra(obraDTO obra)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Insert(obra);
            }
        }

        public void AtualizarObra(obraDTO obra)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Update(obra);
            }
        }

        public obraDTO ConsultarObra(int obraId)
        {

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<obraDTO>("Select * from OBRAS Where id = @obraId", new { obraId = obraId }).FirstOrDefault(); ;
            }
        }

        public List<obraDTO> ConsultarAllObras()
        {
            string _sql = "Select * from OBRAS";
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<obraDTO>(_sql).ToList();
            }
        }

        public void DeletarObra(obraDTO obra)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Delete<obraDTO>(obra);
            }
        }

    }
}
