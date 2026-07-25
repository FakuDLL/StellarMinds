using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.Enums;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUBajaEquipo : ICUBajaEquipo
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioPrestamo _repoPrestamo;

        public CUBajaEquipo(IRepositorioEquipo repoEquipo, IRepositorioPrestamo repoPrestamo)
        {
            _repoEquipo = repoEquipo;
            _repoPrestamo = repoPrestamo;
        }

        public void BajaEquipo(int id)
        {
            var equipo = _repoEquipo.FindById(id);
            if (equipo == null)
                throw new ArgumentException("No existe un equipo con ese Id.");

            if (_repoPrestamo.ExistePrestamoActivoPorEquipo(id))
                throw new InvalidOperationException("No se puede eliminar un equipo con préstamos en curso.");

            _repoEquipo.Remove(equipo);
        }
    }
}
