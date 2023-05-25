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


        [HttpPost]
        [Route("CadastrarUsuario")]
        public void PostObra([FromQuery] UsuarioDTO usuario)
        {
            new UsuarioDAO().InserirUsuario(usuario);
        }

        [HttpPost]
        [Route("Autenticar")]
        public UsuarioDTO AutenticarUsuario([FromQuery] string email, string senha)
        {
            return new UsuarioDAO().AutenticarUsuario(email, senha);
        }

        [HttpPut]
        [Route("AtualizarUsuario")]
        public void PutObra([FromQuery] UsuarioDTO usuario)
        {
            new UsuarioDAO().AtualizarUsuario(usuario);
        }

        [HttpPost]
        [Route("AlterarSenha/{email}")]
        public void RecuperarUsuario([FromQuery] string email)
        {
            new UsuarioDAO().RecuperarUsuario(email);
        }

        [HttpDelete]
        [Route("DeleteUsuario/{usuid}")]
        public void RecuperarUsuario([FromQuery] UsuarioDTO usuario)
        {
            new UsuarioDAO().BanirUsuario(usuario);
        }


    }

}
