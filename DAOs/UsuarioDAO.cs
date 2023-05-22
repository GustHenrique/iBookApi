using mysqlAPI.DTOs;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Data.SqlClient;

namespace iBookApi.DAOs
{
    public class UsuarioDAO : BaseDAO
    {
        public UsuarioDAO() : base()
        {
        }

        public long InserirUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Insert(usuario);
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                conn.Update(usuario);
            }
        }

        public Usuario ConsultarUsuario(decimal UsuarioId)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Query<Usuario>("Select * from USUARIO with(nolock) Where USUID = @usuId", new { usuId = UsuarioId }).FirstOrDefault();
            }
        }

        public Usuario ConsultarUsuarioPorEmail(string Email)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Query<Usuario>("Select * from USUARIO with(nolock) Where USUEMAIL = @email", new { email = Email }).FirstOrDefault();
            }
        }

        public Usuario AutenticarUsuario(string UsuLogin, string UsuSenha)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Query<Usuario>("Select * from USUARIO with(nolock) Where USULOGIN = @UsuLogin And USUSENHA=@UsuSenha", new { UsuLogin, UsuSenha }).FirstOrDefault();
            }
        }
        public Usuario RecuperarUsuario(string UsuLogin, string UsuSenha)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Query<Usuario>("update USUARIO set USUSENHA=@UsuSenha Where USUEMAIL = @UsuLogin And USUATIVO = 1", new { UsuLogin, UsuSenha }).FirstOrDefault();

            }
        }

        public Usuario AlterarSenhaUsuario(string UsuId, string UsuSenha, string UsuSenhaNova)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Query<Usuario>("update USUARIO set USUSENHA=@UsuSenhaNova Where USUSENHA= @UsuSenha And usuId = @usuId And USUATIVO = 1", new { UsuId, UsuSenha, UsuSenhaNova }).FirstOrDefault();

            }
        }
    }
}
