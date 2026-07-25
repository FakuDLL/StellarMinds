using Microsoft.EntityFrameworkCore;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.AccesoDatos.Repositorios
{
    public class RepositorioAuditoriaPrestamo : IRepositorioAuditoriaPrestamo
    {
        private readonly ApplicationDbContext _context;

        public RepositorioAuditoriaPrestamo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(AuditoriaPrestamo auditoria)
        {
            _context.AuditoriasPrestamo.Add(auditoria);
            _context.SaveChanges();
        }

        public List<AuditoriaPrestamo> FindAll()
        {
            return _context.AuditoriasPrestamo
                .Include(a => a.Prestamo)
                    .ThenInclude(p => p.Socio)
                .Include(a => a.Coordinador)
                .ToList();
        }

        public List<AuditoriaPrestamo> FindByCoordinadorId(int coordinadorId)
        {
            return _context.AuditoriasPrestamo
                .Include(a => a.Prestamo)
                    .ThenInclude(p => p.Socio)
                .Include(a => a.Coordinador)
                .Where(a => a.Coordinador.Id == coordinadorId)
                .ToList();
        }

        public List<AuditoriaPrestamo> FindByPrestamoId(int prestamoId)
        {
            return _context.AuditoriasPrestamo
                .Include(a => a.Prestamo)
                    .ThenInclude(p => p.Socio)
                .Include(a => a.Coordinador)
                .Where(a => a.Prestamo.Id == prestamoId)
                .ToList();
        }

        public AuditoriaPrestamo? FindById(int id)
        {
            return _context.AuditoriasPrestamo
                .Include(a => a.Prestamo)
                    .ThenInclude(p => p.Socio)
                .Include(a => a.Coordinador)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
