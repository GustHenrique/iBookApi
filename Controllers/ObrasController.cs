using iBookApi.DAOs;
using Microsoft.AspNetCore.Mvc;
using mysqlAPI.DTOs;

namespace iBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasController : Controller
    {
        [HttpGet]
        [Route("TodasObras")]
        public List<obraDTO> GetObras()
        {
            return new ObrasDAO().ConsultarAllObras();
        }

        [HttpGet]
        [Route("UmaObra")]
        public obraDTO GetObra([FromQuery] int ObraID)
        {
            return new ObrasDAO().ConsultarObra(ObraID);
        }

        [HttpPost]
        [Route("AdicionarObra")]
        public void PostObra([FromBody] obraDTO Obra)
        {
            new ObrasDAO().InserirObra(Obra);
        }

        [HttpPost]
        [Route("AdicionarListaObra")]
        public void PostListObra([FromBody] List<obraDTO> Obra)
        {
            new ObrasDAO().InserirListObra(Obra);
        }

        [HttpPut]
        [Route("AtualizarObra")]
        public void PutObra([FromBody] obraDTO Obra)
        {
            new ObrasDAO().AtualizarObra(Obra);
        }

        [HttpPut]
        [Route("AvaliarObra")]
        public void PutObra([FromQuery] int obid, [FromQuery] float avarageRating)
        {
            new ObrasDAO().AvaliarObra(obid,avarageRating);
        }

        [HttpDelete]
        [Route("DeletarObra")]
        public void DeleteObra([FromBody] obraDTO Obra)
        {
            new ObrasDAO().DeletarObra(Obra);
        }
    }
}
