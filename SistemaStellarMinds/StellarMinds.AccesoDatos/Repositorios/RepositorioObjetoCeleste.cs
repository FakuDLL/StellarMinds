using Microsoft.EntityFrameworkCore;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.AccesoDatos.Repositorios
{
    public class RepositorioObjetoCeleste : IRepositorioObjetoCeleste
    {
        private readonly ApplicationDbContext _context;

        public RepositorioObjetoCeleste(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ObjetoCeleste> FindAll()
        {
            return _context.ObjetosCelestes
                .AsNoTracking()
                .OrderBy(o => o.Nombre)
                .ToList();
        }

        public ObjetoCeleste? FindById(int id)
        {
            return _context.ObjetosCelestes
                .FirstOrDefault(o => o.Id == id);
        }
    }
}
