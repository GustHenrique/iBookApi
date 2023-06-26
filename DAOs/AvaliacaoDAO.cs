using Dapper;
using Dapper.Contrib.Extensions;
using mysqlAPI.DTOs;
using MySqlConnector;
using System.Data.SqlClient;

namespace iBookApi.DAOs
{
    public class AvaliacaoDAO : BaseDAO
    {
        public AvaliacaoDAO() : base()
        {
        }

        public avaliacaoDTO ConsultarAvaliacaoPorObraEUsu(int obid, int usuid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<avaliacaoDTO>("Select * from AVALIACOES Where obid = @obid AND usuid = @usuid", new { obid = obid, usuid = usuid }).FirstOrDefault();
            }
        }

        public List<avaliacaoDTO> ConsultarAllAvaliacoesPorObra(int obid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<avaliacaoDTO>("Select * from AVALIACOES Where obid = @obid", new { obid = obid }).ToList();
            }
        }

        public long InserirAvaliacao(avaliacaoDTO obra)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Insert(obra);
            }
        }

        public void AtualizarAvaObra(int usuid, int obraId, float avarageRating)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Execute("UPDATE AVALIACOES SET AVALIACAO = @avarageRating WHERE obid = @obraId AND usuid = @usuid;", new { obraId = obraId, avarageRating = avarageRating, usuid = usuid });
            }
        }
    }
}
