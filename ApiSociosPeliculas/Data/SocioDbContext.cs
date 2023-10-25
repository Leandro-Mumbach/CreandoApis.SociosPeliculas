using ApiSociosPeliculas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSociosPeliculas.Data
{
    public class SocioDbContext : DbContext
    {
        public SocioDbContext(DbContextOptions<SocioDbContext> options) : base(options)
        {
            FillSocio();
        }

        public DbSet<Socio> Socios { get; set; }

        private void FillSocio()
        {
            if (Socios.Count() == 0)
            {
                Socios.Add(new Socio
                {
                    Id = 1,
                    Nombre = "Usuario 1 ",
                    Apellido = "Appelido 1",
                    Dirección = "Al Norte"
                });
                Socios.Add(new Socio
                {
                    Id = 2,
                    Nombre = "Usuario 2 ",
                    Apellido = "Appelido 2",
                    Dirección = "Al Sur"
                });
                Socios.Add(new Socio
                {
                    Id = 3,
                    Nombre = "Usuario 3 ",
                    Apellido = "Appelido 3",
                    Dirección = "Al Este"
                });
                Socios.Add(new Socio
                {
                    Id = 4,
                    Nombre = "Usuario 4 ",
                    Apellido = "Appelido 4",
                    Dirección = "Al Oeste"
                });
                this.SaveChanges();
            }
        }
    }
}
