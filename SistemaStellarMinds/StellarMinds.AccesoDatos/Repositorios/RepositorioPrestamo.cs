using Microsoft.EntityFrameworkCore;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Enums;
using StellarMinds.LogicaNegocio.IRepositorios;
using System.Linq;

namespace StellarMinds.AccesoDatos.Repositorios
{
    public class RepositorioPrestamo : IRepositorioPrestamo
    {
        private readonly ApplicationDbContext _context;

        public RepositorioPrestamo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            _context.SaveChanges();
            return prestamo.Id;
        }

        public Prestamo? FindById(int id)
        {
            return _context.Prestamos
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .Include(p => p.Socio)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Prestamo> FindBySocioYEstado(int socioId, EstadoPrestamo estado)
        {
            return _context.Prestamos
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .Include(p => p.Socio)
                .Where(p => p.Socio.Id == socioId && p.Estado == estado)
                .ToList();
        }

        public List<Prestamo> FindBySocioYMesAnio(int socioId, int mes, int anio)
        {
            return _context.Prestamos
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .Include(p => p.Socio)
                .Where(p => p.Socio.Id == socioId
                    && p.FechaInicio.Month == mes
                    && p.FechaInicio.Year == anio)
                .OrderByDescending(p => p.FechaInicio)
                .ToList();
        }

        public List<Usuario> FindSociosPorTelescopio(int telescopioId)
        {
            return _context.Prestamos
                .Include(p => p.Socio)
                .Include(p => p.Telescopio)
                .Where(p => p.Telescopio.Id == telescopioId)
                .AsEnumerable()
                .Select(p => p.Socio)
                .GroupBy(s => s.Id)
                .Select(g => g.First())
                .OrderByDescending(s => s.NombreCompleto)
                .ToList();
        }

        public bool ExistePrestamoActivoPorEquipo(int equipoId)
        {
            return _context.Prestamos.Any(p => p.Estado == EstadoPrestamo.EN_PRESTAMO
                && (p.Telescopio.Id == equipoId
                    || p.Montura.Id == equipoId
                    || (p.Camara != null && p.Camara.Id == equipoId)
                    || (p.Ocular != null && p.Ocular.Id == equipoId)));
        }

        public void Update(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            _context.SaveChanges();
        }
    }
}
