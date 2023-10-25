using MinimalApiSociosPeliculas.Data;
using MinimalApiSociosPeliculas.Models;

namespace MinimalApiSociosPeliculas.Repositories
{
    public class SocioRepository : ISocioRepository
    {
        private readonly SocioDbContext _dbcontext;

        public SocioRepository(SocioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Socio> GetAllSocios()
        {
            return _dbcontext.Socios.ToList();
        }

        public Socio GetSocioById(int id)
        {
            return _dbcontext.Socios.FirstOrDefault(p => p.Id == id);
        }

        public void AddSocio(Socio socio)
        {
            _dbcontext.Socios.Add(socio);
            _dbcontext.SaveChanges();
        }

        public void UpdateSocio(Socio socio)
        {
            _dbcontext.Socios.Update(socio);
            _dbcontext.SaveChanges();
        }

        public void DeleteSocio(int id)
        {
            var socio = _dbcontext.Socios.FirstOrDefault(p => p.Id == id);
            if (socio != null)
            {
                _dbcontext.Socios.Remove(socio);
                _dbcontext.SaveChanges();
            }
        }
    }
}
