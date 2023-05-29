using mysqlAPI.DTOs;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Data.SqlClient;
using MySqlConnector;

namespace iBookApi.DAOs
{
    public class UsuarioDAO : BaseDAO
    {
        public UsuarioDAO() : base()
        {
        }

        public UsuarioDTO ConsultarUsuario(int id)
        {

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<UsuarioDTO>("Select * from USUARIO Where id = @id", new { id = id }).FirstOrDefault();
            }
        }

        public List<UsuarioDTO> ConsultarAllUsuarios()
        {

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<UsuarioDTO>("Select * from USUARIO").ToList();
            }
        }

        public UsuarioDTO ConsultarUsuarioPorEmail(string Email)
        {

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<UsuarioDTO>("Select * from USUARIO Where email = @email", new { email = Email }).FirstOrDefault();
            }
        }

        public long InserirUsuario(UsuarioDTO usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Insert(usuario);
            }
        }

        public void AtualizarUsuario(UsuarioDTO usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Update(usuario);
            }
        }

        public UsuarioDTO AutenticarUsuario(string email, string senha)
        {

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<UsuarioDTO>("Select * from USUARIO Where email = @email And senha=@senha", new { email, senha }).FirstOrDefault();
            }
        }
        public UsuarioDTO RecuperarUsuario(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<UsuarioDTO>("update USUARIO set senha=@senha Where email = @email", new { email }).FirstOrDefault();

            }
        }

        public UsuarioDTO AlterarSenhaUsuario(string id, string senha, string senhaNova)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<UsuarioDTO>("update USUARIO set senha=@senhaNova Where senha= @senha And id = @id", new { id, senha, senhaNova }).FirstOrDefault();
            }
        }

        public void BanirUsuario(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Query<UsuarioDTO>("DELETE FROM USUARIO WHERE id = @id", new { id }).FirstOrDefault();
            }
        }
    }
}
