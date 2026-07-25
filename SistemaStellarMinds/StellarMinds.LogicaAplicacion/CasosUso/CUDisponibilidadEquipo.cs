using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUDisponibilidadEquipo : ICUDisponibilidadEquipo
    {
        private readonly IRepositorioEquipo _repoEquipo;

        public CUDisponibilidadEquipo(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public DTODisponibilidadEquipo ObtenerDisponibilidad(string tipoEquipo, int equipoId)
        {
            if (string.IsNullOrWhiteSpace(tipoEquipo))
                throw new ArgumentException("El tipo de equipo es obligatorio.");

            var equipo = _repoEquipo.FindById(equipoId);
            if (equipo == null)
                throw new ArgumentException("No existe un equipo con ese Id.");

            var tipoEsperado = tipoEquipo.Trim().ToLowerInvariant();
            var tipoReal = equipo.GetType().Name.ToLowerInvariant();
            if (tipoReal != tipoEsperado)
                throw new ArgumentException("El tipo de equipo no coincide con el Id indicado.");

            var disponible = equipo.CantidadDisponible > 0;

            return new DTODisponibilidadEquipo
            {
                EquipoId = equipo.Id,
                TipoEquipo = equipo.GetType().Name,
                CantidadDisponible = equipo.CantidadDisponible,
                Disponible = disponible,
                Mensaje = disponible ? "Equipo disponible" : "Equipo sin disponibilidad"
            };
        }
    }
}
