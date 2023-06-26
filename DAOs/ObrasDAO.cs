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


        public obraDTO ConsultarObra(int obraId)
        {

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<obraDTO>("Select * from OBRAS Where id = @obraId", new { obraId = obraId }).FirstOrDefault();
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

        public List<obraDTO> ConsultarObrasMaisComentadasSemana()
        {
            DateTime today = DateTime.Today;
            int daysUntilSunday = (int)today.DayOfWeek - (int)DayOfWeek.Sunday;
            DateTime startOfWeek = today.AddDays(-daysUntilSunday);

            string startOfWeekString = startOfWeek.ToString("yyyy-MM-dd");
            string endOfWeekString = startOfWeek.AddDays(6).ToString("yyyy-MM-dd");

            string _sql = $"SELECT O.*, COUNT(C.obid) AS totalComentarios FROM OBRAS O LEFT JOIN COMENTARIOS C ON O.id = C.obid WHERE C.dataComentario >= '{startOfWeekString}' AND C.dataComentario <= '{endOfWeekString}' GROUP BY O.id ORDER BY totalComentarios DESC;";

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<obraDTO>(_sql).ToList();
            }
        }

        public void AvaliarObra(int obraId, float avarageRating)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Execute("UPDATE OBRAS SET avarageRating = @avarageRating WHERE id = @obraId;", new { obraId = obraId, avarageRating = avarageRating });
            }
        }


        public long InserirObra(obraDTO obra)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Insert(obra);
            }
        }

        public void InserirListObra(List<obraDTO> obras)
        {
            if (obras != null)
            {
                using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
                {
                    foreach (var obra in obras)
                    {
                        connection.Open();
                        connection.Insert(obra);
                    }
                }
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
