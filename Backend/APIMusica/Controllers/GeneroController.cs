using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMusica.Models;
using APIMusica.Services;

namespace APIMusica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : Controller
    {

        [HttpGet]
        public List<Generos> LeerGeneros()
        {
            var generoService = new GeneroService();
            return generoService.LeerGeneros();
        }

        [HttpPost]
        public IActionResult AgregarGenero([FromBody] Generos generos)
        {
            var generoService = new GeneroService();
            var res = generoService.GuardarGenero(generos);
            if (res)
                return Ok("Genero guardado con éxito");
            else
                return BadRequest("Error al guardar el genero"); // Return 400 Bad Request if there was an error.
        }

        [HttpGet("{id:int}")]
        public IActionResult BuscarGenero(int id)
        {
            var generoService = new GeneroService();
            var genero = generoService.BuscarGenero(id);
            if (genero == null)
                return NotFound("Genero no encontrado"); // Return 404 Not Found if the album is not found.

            return Ok(genero);
        }

       

        [HttpDelete]
        public List<Generos> EliminarGenero(int idGenero)
        {
            var generoService = new GeneroService();
            var res = generoService.EliminarGenero (idGenero);

            return new GeneroService().LeerGeneros();
            // Return 404 Not Found if the album to delete is not found.
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarGenero(int id, [FromBody] Generos genero)
        {
            var generoService = new GeneroService();
            var res = generoService.EditarGenero(id, genero);
            if (res)
                return Ok("Genero editado con éxito"); // Return 200 OK for successful updates.
            else
                return BadRequest("Error al editar el Genero"); // Return 400 Bad Request if there was an error updating the album.

        }
    }
}
