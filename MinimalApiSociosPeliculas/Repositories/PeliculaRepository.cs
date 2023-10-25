using MinimalApiSociosPeliculas.Data;
using MinimalApiSociosPeliculas.Models;

namespace MinimalApiSociosPeliculas.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly PeliculaDbContext _dbcontext;

        public PeliculaRepository(PeliculaDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Pelicula> GetAllPeliculas()
        {
            return _dbcontext.Peliculas.ToList();
        }

        public Pelicula GetPeliculaById(int id)
        {
            return _dbcontext.Peliculas.FirstOrDefault(p => p.Id == id);
        }

        public void AddPelicula(Pelicula pelicula)
        {
            _dbcontext.Peliculas.Add(pelicula);
            _dbcontext.SaveChanges();
        }

        public void UpdatePelicula(Pelicula pelicula)
        {
            _dbcontext.Peliculas.Update(pelicula);
            _dbcontext.SaveChanges();
        }

        public void DeletePelicula(int id)
        {
            var pelicula = _dbcontext.Peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula != null)
            {
                _dbcontext.Peliculas.Remove(pelicula);
                _dbcontext.SaveChanges();
            }
        }
    }
}
