using ApiSociosPeliculas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSociosPeliculas.Data
{
    public class PeliculaDbContext : DbContext
    {
        public PeliculaDbContext(DbContextOptions<PeliculaDbContext> options) : base(options)
        {
            FillPelicula();
        }

        public DbSet<Pelicula> Peliculas { get; set; }

        private void FillPelicula()
        {
            if (Peliculas.Count() == 0)
            {
                Peliculas.Add(new Pelicula { 
                    Id = 1,
                    Descripción = "Titanic",
                    Género = "Drama",
                    Duración = 90
                });
                Peliculas.Add(new Pelicula
                {
                    Id = 2,
                    Descripción = "Transformer",
                    Género = "Acción",
                    Duración = 120
                });
                Peliculas.Add(new Pelicula
                {
                    Id = 3,
                    Descripción = "Scary Movie",
                    Género = "Comedia",
                    Duración = 75
                });
                this.SaveChanges();
            }
        }
    }
}
