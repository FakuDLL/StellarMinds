using Microsoft.EntityFrameworkCore;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.AccesoDatos.Repositorios
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private readonly ApplicationDbContext _context;

        public RepositorioEquipo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            _context.SaveChanges();
            return equipo.Id;
        }

        public List<Equipo> FindAll()
        {
            return _context.Equipos.AsNoTracking().ToList();
        }

        public Equipo? FindById(int id)
        {
            return _context.Equipos.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Equipo equipo)
        {
            _context.Equipos.Update(equipo);
            _context.SaveChanges();
        }

        public void Remove(Equipo equipo)
        {
            _context.Equipos.Remove(equipo);
            _context.SaveChanges();
        }
    }
}
