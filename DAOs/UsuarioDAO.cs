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

        public long InserirUsuario(Usuario usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Insert(usuario);
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                connection.Update(usuario);
            }
        }

        public Usuario ConsultarUsuario(decimal UsuarioId)
        {

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<Usuario>("Select * from USUARIO Where USUID = @usuId", new { usuId = UsuarioId }).FirstOrDefault();
            }
        }

        public Usuario ConsultarUsuarioPorEmail(string Email)
        {

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<Usuario>("Select * from USUARIO with(nolock) Where USUEMAIL = @email", new { email = Email }).FirstOrDefault();
            }
        }

        public Usuario AutenticarUsuario(string UsuLogin, string UsuSenha)
        {

            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<Usuario>("Select * from USUARIO with(nolock) Where USULOGIN = @UsuLogin And USUSENHA=@UsuSenha", new { UsuLogin, UsuSenha }).FirstOrDefault();
            }
        }
        public Usuario RecuperarUsuario(string UsuLogin, string UsuSenha)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<Usuario>("update USUARIO set USUSENHA=@UsuSenha Where USUEMAIL = @UsuLogin And USUATIVO = 1", new { UsuLogin, UsuSenha }).FirstOrDefault();

            }
        }

        public Usuario AlterarSenhaUsuario(string UsuId, string UsuSenha, string UsuSenhaNova)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection.Query<Usuario>("update USUARIO set USUSENHA=@UsuSenhaNova Where USUSENHA= @UsuSenha And usuId = @usuId And USUATIVO = 1", new { UsuId, UsuSenha, UsuSenhaNova }).FirstOrDefault();

            }
        }
    }
}
