using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMusica.Models;
using APIMusica.Services;
namespace APIMusica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CancionController : Controller
    {
       
        [HttpGet]
        public List<Canciones> LeerCanciones()
        {
            var CancionesService = new CancionesService();
            return CancionesService.LeerCanciones();
        }

        [HttpGet("{id:int}")]
        public IActionResult BuscarCancion(int id)
        {
            var CancionesService = new CancionesService();
            var cancion = CancionesService.BuscarCancion(id);
            if (cancion == null)
                return NotFound("Cancion no encontrada"); // Return 404 Not Found if the album is not found.

            return Ok(cancion);
        }

        [HttpPost]
        public IActionResult AgregarCancion([FromBody] Canciones cancion)
        {
            var CancionesService = new CancionesService();
            var res = CancionesService.GuardarCancion(cancion);
            if (res)
                return Ok("Cancion guardada con éxito");
            else
                return BadRequest("Error al guardar la Cancion"); // Return 400 Bad Request if there was an error.
        }

        [HttpDelete("{id:int}")]
        public IActionResult EliminarCancion(int id)
        {
            var CancionesService = new CancionesService();
            var success = CancionesService.EliminarCancion(id);
            if (success)
                return Ok("Cancion eliminada con éxito");
            else
                return NotFound("Cancion no encontrada"); // Return 404 Not Found if the album to delete is not found.
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarCancion(int id, [FromBody] Canciones cancion)
        {
            var CancionesService = new CancionesService();
            var res = CancionesService.EditarCancion(id, cancion);
            if (res)
                return Ok("Cancion editado con éxito"); // Return 200 OK for successful updates.
            else
                return BadRequest("Error al editar el Cancion"); // Return 400 Bad Request if there was an error updating the album.

        }
    }
}
