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
        public void PostListObra([FromQuery] List<obraDTO> Obra)
        {
            new ObrasDAO().InserirListObra(Obra);
        }

        [HttpPut]
        [Route("AtualizarObra")]
        public void PutObra([FromQuery] obraDTO Obra)
        {
            new ObrasDAO().AtualizarObra(Obra);
        }

        [HttpDelete]
        [Route("DeletarObra")]
        public void DeleteObra([FromQuery] obraDTO Obra)
        {
            new ObrasDAO().DeletarObra(Obra);
        }
    }
}
