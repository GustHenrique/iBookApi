using iBookApi.DAOs;
using Microsoft.AspNetCore.Mvc;
using mysqlAPI.DTOs;

namespace iBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : Controller
    {
        [HttpGet]
        [Route("TodosAvaliacoesObraUsu")]
        public avaliacaoDTO GetAvaliacoesPorObraUsu([FromQuery] int obid, [FromQuery] int usuid)
        {
            return new AvaliacaoDAO().ConsultarAvaliacaoPorObraEUsu(obid, usuid);
        }

        [HttpGet]
        [Route("TodosAvaliacoesObra")]
        public List<avaliacaoDTO> GetAllAvaliacoesPorObra([FromQuery] int obid)
        {
            return new AvaliacaoDAO().ConsultarAllAvaliacoesPorObra(obid);
        }

        [HttpPost]
        [Route("AdicionarAvaliacao")]
        public void PostAddFavorito([FromBody] avaliacaoDTO avaliacao)
        {
            new AvaliacaoDAO().InserirAvaliacao(avaliacao);
        }

        [HttpPost]
        [Route("AtualizarAvaObra")]
        public void PutObra([FromQuery] int usuid, [FromQuery] int obid, [FromQuery] float avarageRating)
        {
            new AvaliacaoDAO().AtualizarAvaObra(usuid, obid, avarageRating);
        }
    }
}
