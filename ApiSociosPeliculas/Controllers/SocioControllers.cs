using ApiSociosPeliculas.Models;
using ApiSociosPeliculas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSociosPeliculas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SocioControllers : ControllerBase
    {
        private readonly ISocioRepository _Sociorepository;

        public SocioControllers(ISocioRepository Sociorepository)
        {
            _Sociorepository = Sociorepository;
        }

        // GET: PeliculaControllers
        [HttpGet]
        public ActionResult Get()
        {
            var socio = _Sociorepository.GetAllSocios();
            return Ok(socio);
        }

        // GET: PeliculaControllers/Pelicula/id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var socio = _Sociorepository.GetSocioById(id);
            if (socio == null)
            {
                return NotFound();
            }
            return Ok(socio);
        }

        // POST: PeliculaControllers/Pelicula
        [HttpPost]
        public IActionResult Post(Socio socio)
        {
            _Sociorepository.AddSocio(socio);
            return CreatedAtAction(nameof(Get), new { id = socio.Id }, socio);
        }

        // PUT: PeliculaControllers/Pelicula
        [HttpPut("{id}")]
        public IActionResult Put(int id, Socio updatedSocio)
        {
            var socio = _Sociorepository.GetSocioById(id);
            if (socio == null)
            {
                return NotFound();
            }
            socio.Nombre = updatedSocio.Nombre;
            socio.Apellido = updatedSocio.Apellido;
            socio.Dirección = updatedSocio.Dirección;
            _Sociorepository.UpdateSocio(socio);
            return NoContent();
        }

        // DELETE: PeliculaControllers/Pelicula
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var socio = _Sociorepository.GetSocioById(id);
            if (socio == null)
            {
                return NotFound();
            }
            _Sociorepository.DeleteSocio(id);
            return NoContent();
        }
    }
}
