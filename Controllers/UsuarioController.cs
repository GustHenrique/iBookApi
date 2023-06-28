using iBookApi.DAOs;
using Microsoft.AspNetCore.Mvc;
using mysqlAPI.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace iBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [Route("ConsultarPorId/{UsuId}")]
        [HttpGet]
        public UsuarioDTO Get(int UsuId)
        {
            return new UsuarioDAO().ConsultarUsuario(UsuId);
        }

        [HttpGet]
        [Route("TodosUsuarios")]
        public List<UsuarioDTO> GetAllUsuarios()
        {
            return new UsuarioDAO().ConsultarAllUsuarios();
        }

        [HttpGet]
        [Route("UsuarioPorEmail")]
        public UsuarioDTO GetUsuarioPorEmail(string email)
        {
            return new UsuarioDAO().ConsultarUsuarioPorEmail(email);
        }


        [HttpPost]
        [Route("CadastrarUsuario")]
        public void PostObra([FromBody] UsuarioDTO usuario)
        {
            new UsuarioDAO().InserirUsuario(usuario);
        }

        [HttpPost]
        [Route("Autenticar")]
        public UsuarioDTO AutenticarUsuario(string email, string senha)
        {
            return new UsuarioDAO().AutenticarUsuario(email, senha);
        }

        [HttpPost]
        [Route("AtualizarUsuario")]
        public void PutObra([FromBody] UsuarioDTO usuario)
        {
            new UsuarioDAO().AtualizarUsuario(usuario);
        }

        [HttpPost]
        [Route("AlterarSenha/{email}")]
        public void RecuperarUsuario([FromBody] string email)
        {
            new UsuarioDAO().RecuperarUsuario(email);
        }

        [HttpDelete]
        [Route("DeleteUsuario")]
        public void RecuperarUsuario([FromBody] int usuid)
        {
            new UsuarioDAO().BanirUsuario(usuid);
        }


    }

}
