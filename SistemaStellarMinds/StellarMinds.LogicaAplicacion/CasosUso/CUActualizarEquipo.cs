using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUActualizarEquipo : ICUActualizarEquipo
    {
        private readonly IRepositorioEquipo _repoEquipo;

        public CUActualizarEquipo(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public DTOActualizarEquipo ObtenerEquipoAActualizar(int id)
        {
            var equipo = _repoEquipo.FindById(id);
            if (equipo == null)
                throw new ArgumentException("No existe un equipo con ese Id.");

            return EquipoMapper.FromEquipoToDtoActualizar(equipo);
        }

        public void ActualizarEquipo(DTOActualizarEquipo dto)
        {
            if (dto == null)
                throw new ArgumentException("Los datos del equipo son obligatorios.");

            var existente = _repoEquipo.FindById(dto.Id);
            if (existente == null)
                throw new ArgumentException("No existe un equipo con ese Id.");

            var actualizado = EquipoMapper.FromDtoActualizarToEquipo(dto, existente);
            _repoEquipo.Update(actualizado);
        }
    }
}
