using MinimalApiSociosPeliculas.Models;

namespace MinimalApiSociosPeliculas.Repositories
{
    public interface ISocioRepository
    {
        IEnumerable<Socio> GetAllSocios();
        Socio GetSocioById(int id);
        void AddSocio(Socio socio);
        void UpdateSocio(Socio socio);
        void DeleteSocio(int id);
    }
}
