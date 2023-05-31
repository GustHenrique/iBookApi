using iBookApi.DAOs;
using Microsoft.AspNetCore.Mvc;
using mysqlAPI.DTOs;

namespace iBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : Controller
    {
        [HttpGet]
        [Route("TodosComentariosObra/{obid}")]
        public List<comentarioDTO> GetComentarioPorObra(int obid)
        {
            return new ComentarioDAO().ConsultarAllComentariosPorObra(obid);
        }

        [HttpGet]
        [Route("TodosComentarios")]
        public List<comentarioDTO> GetAllComentarios()
        {
            return new ComentarioDAO().ConsultarAllComentarios();
        }

        [HttpGet]
        [Route("TodosComentariosUsu/{usuid}")]
        public List<comentarioDTO> GetComentarioPorUsu(int usuid)
        {
            return new ComentarioDAO().ConsultarAllComentariosPorUsu(usuid);
        }

        [HttpGet]
        [Route("TodosRespostas/{comid}")]
        public List<respostaDTO> GetRespostaPorComentario(int comid)
        {
            return new ComentarioDAO().ConsultarAllRespostasComentario(comid);
        }

        [HttpPost]
        [Route("AdicionarComentario")]
        public void PostAddComentario([FromBody] comentarioDTO comentario)
        {
            new ComentarioDAO().InserirComentario(comentario);
        }

        [HttpPut]
        [Route("AtualizarComentario")]
        public void PutAttComentario([FromBody] comentarioDTO comentario)
        {
            new ComentarioDAO().AtualizarComentario(comentario);
        }

        [HttpDelete]
        [Route("DeletarComentario")]
        public void DeleteComentario([FromBody] comentarioDTO comentario)
        {
            new ComentarioDAO().DeletarComentario(comentario);
        }
    }
}
