using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMusica.Models;
using APIMusica.Services;
using System.Collections.Generic;

namespace APIMusica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaController : Controller
    {
        [HttpGet]
        public List<Artistas> LeerArtistas()
        {
            var artistaService = new ArtistaService();
            return artistaService.LeerArtistas();
        }

        [HttpGet("{id:int}")]
        public IActionResult BuscarArtista(int id)
        {
            var artistaService = new ArtistaService();
            var artista = artistaService.BuscarArtista(id);
            if (artista == null)
                return NotFound("Artista no encontrado"); // Return 404 Not Found if the artista is not found.

            return Ok(artista);
        }

        [HttpPost]
        public IActionResult AgregarArtista([FromBody] Artistas artista)
        {
            var artistaService = new ArtistaService();
            var res = artistaService.GuardarArtista(artista);
            if (res)
                return Ok("Artista guardado con éxito");
            else
                return BadRequest("Error al guardar el artista"); // Return 400 Bad Request if there was an error.
        }

        [HttpDelete]
        public List<Artistas> EliminarArtista(int idArtista)
        {
            var artistaService = new ArtistaService();
            var res = artistaService.EliminarArtista(idArtista);
            return new ArtistaService().LeerArtistas(); // Return 404 Not Found if the artista to delete is not found.
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarArtista(int id, [FromBody] Artistas artista)
        {
            var artistaService = new ArtistaService();
            var res = artistaService.EditarArtista(id, artista);
            if (res)
                return Ok("Artista editado con éxito"); // Return 200 OK for successful updates.
            else
                return BadRequest("Error al editar el artista"); // Return 400 Bad Request if there was an error updating the artista.
        }
    }
}
