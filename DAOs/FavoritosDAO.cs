using Dapper;
using Dapper.Contrib.Extensions;
using mysqlAPI.DTOs;
using MySqlConnector;
using System.Data.SqlClient;

namespace iBookApi.DAOs
{
    public class FavoritosDAO : BaseDAO
    {
        public FavoritosDAO() : base()
        {
        }

        public favoritosDTO ConsultarFavoritosPorObraEUsu(int obid, int usuid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<favoritosDTO>("Select * from OBRAS_FAVORITAS Where obid = @obid AND usuid = @usuid", new { obid = obid, usuid = usuid }).FirstOrDefault();
            }
        }

        public List<favoritosDTO> ConsultarAllFavoritosPorUsu(int usuid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<favoritosDTO>("Select * from OBRAS_FAVORITAS Where usuid = @usuid", new { usuid = usuid }).ToList();
            }
        }

        public List<favoritosDTO> ConsultarAllFavoritosPorObra(int obid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<favoritosDTO>("Select * from OBRAS_FAVORITAS Where obid = @obid", new { obid = obid }).ToList();
            }
        }

        public long InserirFavorito(favoritosDTO obra)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Insert(obra);
            }
        }
        public void DeletarFavorito(favoritoDTO favorito)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Query<favoritoDTO>("DELETE FROM OBRAS_FAVORITAS Where obid = @obid AND usuid = @usuid", new { obid = favorito.obid, usuid = favorito.usuid}).FirstOrDefault();
            }
        }
    }
}
