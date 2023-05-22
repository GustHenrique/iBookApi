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
        // GET: api/<UsuarioController>
        //[HttpGet]
        //[Route("TodosUsuarios")]
        //public List<Usuario> GetUsu()
        //{
        //    return new UsuarioDAO().ConsultarTodosUsuarios();
        //}
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UsuarioController>/5
        //[Route("ConsultarPorId/{UsuId}")]
        //[HttpGet]
        //public Usuario Get(int UsuId)
        //{
        //    return new UsuarioDAO().ConsultarUsuario(UsuId);
        //}

        //[Route("Autenticar")]
        //[HttpPost]
        //public async Task<ActionResult<Usuario>> Autenticar([FromBody] Usuario usuario)
        //{


        //}

        //[Route("AutenticarIntegracao")]
        //[HttpPost]
        //public async Task<ActionResult<Usuario>> AutenticarIntegracao(int usuid)
        //{
        //}

        //[Route("RecuperarSenha/{email}")]
        //[HttpPost]
        //public async Task<ActionResult<Usuario>> RecuperarUsuario(string email)
        //{

        //}

        //[Route("AlterarSenha/{email}")]
        //[HttpPost]
        //public async Task<ActionResult<Usuario>> AlterarUsuario(string email, string pass)
        //{

        //}

        //[Route("ConsultarPorEmail")]
        //[HttpGet]
        //public Usuario ConsultarUsuarioPorEmail(string Email)
        //{
        //    return new UsuarioDAO().ConsultarUsuarioPorEmail(Email);
        //}

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }

}
