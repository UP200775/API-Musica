using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMusica.Models;
using APIMusica.Services;

namespace APIMusica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : Controller
    {

        [HttpGet]
        public List<Albumes> LeerAlbumes()
        {
            var albumService = new AlbumService();
            return albumService.LeerAlbumes();
        }

        [HttpGet("{id:int}")]
        public IActionResult BuscarAlbum(int id)
        {
            var albumService = new AlbumService();
            var album = albumService.BuscarAlbum(id);
            if (album == null)
                return NotFound("Álbum no encontrado"); // Return 404 Not Found if the album is not found.

            return Ok(album);
        }

        [HttpPost]
        public IActionResult AgregarAlbum([FromBody] Albumes albumes)
        {
            var albumService = new AlbumService();
            var res = albumService.GuardarAlbum(albumes);
            if (res)
                return Ok("Álbum guardado con éxito");
            else
                return BadRequest("Error al guardar el álbum"); // Return 400 Bad Request if there was an error.
        }

        [HttpDelete("{id:int}")]
        public IActionResult EliminarAlbum(int id)
        {
            var albumService = new AlbumService();
            var success = albumService.EliminarAlbum(id);
            if (success)
                return Ok("Álbum eliminado con éxito");
            else
                return NotFound("Álbum no encontrado"); // Return 404 Not Found if the album to delete is not found.
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarAlbum(int id, [FromBody] Albumes album)
        {
            var albumService = new AlbumService();
            var res = albumService.EditarAlbum(id, album);
            if (res)
                return Ok("Álbum editado con éxito"); // Return 200 OK for successful updates.
            else
                return BadRequest("Error al editar el álbum"); // Return 400 Bad Request if there was an error updating the album.

        }
    }
}
