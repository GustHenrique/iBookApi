using iBookApi.DAOs;
using Microsoft.AspNetCore.Mvc;
using mysqlAPI.DTOs;

namespace iBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaController : Controller
    {
        [HttpGet]
        [Route("TodosRespostasComentario/{comid}")]
        public List<respostaDTO> GetRespostasPorComentario(int comid)
        {
            return new RespostaDAO().ConsultarAllRespostasPorComentario(comid);
        }


        [HttpGet]
        [Route("TodosRespostas")]
        public List<respostaDTO> GetAllRespostas()
        {
            return new RespostaDAO().ConsultarAllRespostas();
        }


        [HttpGet]
        [Route("TodosRespostasUsu/{usuid}")]
        public List<respostaDTO> GetRespostasPorUsu(int usuid)
        {
            return new RespostaDAO().ConsultarAllRespostasPorUsu(usuid);
        }

        [HttpPost]
        [Route("AdicionarComentario")]
        public void PostAddComentario([FromBody] respostaDTO comentario)
        {
            new RespostaDAO().InserirResposta(comentario);
        }

        [HttpPut]
        [Route("AtualizarComentario")]
        public void PutAttComentario([FromBody] respostaDTO comentario)
        {
            new RespostaDAO().AtualizarResposta(comentario);
        }

        [HttpDelete]
        [Route("DeletarComentario")]
        public void DeleteComentario([FromBody] respostaDTO comentario)
        {
            new RespostaDAO().DeletarResposta(comentario);
        }
    }
}
