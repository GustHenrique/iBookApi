using iBookApi.DAOs;
using Microsoft.AspNetCore.Mvc;
using mysqlAPI.DTOs;

namespace iBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritosController : Controller
    {
        [HttpGet]
        [Route("TodosFavoritosObraUsu")]
        public favoritosDTO GetComentarioPorObra([FromQuery] int obid, [FromQuery] int usuid)
        {
            return new FavoritosDAO().ConsultarFavoritosPorObraEUsu(obid, usuid);
        }

        [HttpGet]
        [Route("TodosFavoritosUsu")]
        public List<favoritosDTO> GetAllFavoritosPorUsu([FromQuery] int usuid)
        {
            return new FavoritosDAO().ConsultarAllFavoritosPorUsu(usuid);
        }

        [HttpGet]
        [Route("TodosFavoritosObra")]
        public List<favoritosDTO> GetFavoritosPorUsu([FromQuery] int usuid)
        {
            return new FavoritosDAO().ConsultarAllFavoritosPorObra(usuid);
        }

        [HttpPost]
        [Route("AdicionarFavorito")]
        public void PostAddFavorito([FromBody] favoritosDTO favorito)
        {
            new FavoritosDAO().InserirFavorito(favorito);
        }

        [HttpDelete]
        [Route("DeletarFavorito")]
        public void DeleteFavorito([FromBody] favoritoDTO favorito)
        {
            new FavoritosDAO().DeletarFavorito(favorito);
        }
    }
}
