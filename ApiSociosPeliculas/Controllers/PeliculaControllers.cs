using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiSociosPeliculas.Repositories;
using ApiSociosPeliculas.Models;

namespace ApiSociosPeliculas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PeliculaControllers : ControllerBase
    {
        private readonly IPeliculaRepository _Pelicularepository;

        public PeliculaControllers(IPeliculaRepository Pelicularepository)
        {
            _Pelicularepository = Pelicularepository;
        }

        // GET: PeliculaControllers
        [HttpGet]
        public ActionResult Get()
        {
            var peliculas = _Pelicularepository.GetAllPeliculas();
            return Ok(peliculas);
        }

        // GET: PeliculaControllers/Pelicula/id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var pelicula = _Pelicularepository.GetPeliculaById(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        // POST: PeliculaControllers/Pelicula
        [HttpPost]
        public IActionResult Post(Pelicula pelicula)
        {
            _Pelicularepository.AddPelicula(pelicula);
            return CreatedAtAction(nameof(Get), new {id = pelicula.Id}, pelicula);
        }

        // PUT: PeliculaControllers/Pelicula
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pelicula updatedPelicula)
        {
            var pelicula = _Pelicularepository.GetPeliculaById(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            pelicula.Descripción = updatedPelicula.Descripción;
            pelicula.Género = updatedPelicula.Género;
            _Pelicularepository.UpdatePelicula(pelicula);
            return NoContent();
        }

        // DELETE: PeliculaControllers/Pelicula
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pelicula = _Pelicularepository.GetPeliculaById(id);
            if(pelicula == null)
            {
                return NotFound();
            }
            _Pelicularepository.DeletePelicula(id);
            return NoContent();
        }
    }
}
