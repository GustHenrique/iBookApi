using iBookApi.DAOs;
using Microsoft.AspNetCore.Mvc;
using mysqlAPI.DTOs;

namespace iBookApi.Controllers
{
    public class ObrasController : Controller
    {
        [HttpGet]
        [Route("TodasObras")]
        public List<obraDTO> GetObras()
        {
            List<obraDTO> lista = new List<obraDTO>();
            lista = new ObrasDAO().ConsultarAllObras();
            return lista;
        }

        [HttpGet]
        [Route("UmaObra")]
        public obraDTO GetObra([FromQuery] int ObraID)
        {
            return new ObrasDAO().ConsultarObra(ObraID);
        }
    }
}
