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


        //public List<avaliacaoDTO> ConsultarAllFavoritosPorUsu(int usuid)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
        //    {
        //        connection.Open();
        //        return connection.Query<avaliacaoDTO>("Select * from AVALIACOES Where usuid = @usuid", new { usuid = usuid }).ToList();
        //    }
        //}

        //public void DeletarFavorito(favoritoDTO favorito)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
        //    {
        //        connection.Open();
        //        connection.Query<favoritoDTO>("DELETE FROM AVALIACOES Where obid = @obid AND usuid = @usuid", new { obid = favorito.obid, usuid = favorito.usuid}).FirstOrDefault();
        //    }
        //}
    }
}
