using Microsoft.EntityFrameworkCore;
using StellarMinds.LogicaNegocio.Consultas;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.AccesoDatos.Repositorios
{
    public class RepositorioObservacion : IRepositorioObservacion
    {
        private readonly ApplicationDbContext _context;

        public RepositorioObservacion(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Observacion observacion)
        {
            _context.Observaciones.Add(observacion);
            _context.SaveChanges();
            return observacion.Id;
        }

        public Observacion? FindById(int id)
        {
            return _context.Observaciones
                .Include(o => o.Prestamo)
                .Include(o => o.ObjetoCeleste)
                .FirstOrDefault(o => o.Id == id);
        }

        public List<RankingObjetoCeleste> ObtenerRankingObjetosCelestesObservados()
        {
            return _context.Observaciones
                .AsNoTracking()
                .Include(o => o.ObjetoCeleste)
                .GroupBy(o => new
                {
                    o.ObjetoCeleste.Id,
                    o.ObjetoCeleste.Nombre,
                    o.ObjetoCeleste.Tipo
                })
                .Select(g => new RankingObjetoCeleste
                {
                    ObjetoCelesteId = g.Key.Id,
                    Nombre = g.Key.Nombre,
                    Tipo = g.Key.Tipo,
                    CantidadVecesObservado = g.Count()
                })
                .OrderByDescending(r => r.CantidadVecesObservado)
                .ToList();
        }
    }
}
