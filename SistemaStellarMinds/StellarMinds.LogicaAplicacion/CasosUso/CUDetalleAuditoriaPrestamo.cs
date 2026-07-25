using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUDetalleAuditoriaPrestamo : ICUDetalleAuditoriaPrestamo
    {
        private readonly IRepositorioAuditoriaPrestamo _repositorioAuditoria;

        public CUDetalleAuditoriaPrestamo(IRepositorioAuditoriaPrestamo repositorioAuditoria)
        {
            _repositorioAuditoria = repositorioAuditoria;
        }

        public DTOAuditoriaPrestamo ObtenerDetalle(int auditoriaId)
        {
            if (auditoriaId <= 0)
                throw new ArgumentException("La auditoría es obligatoria.");

            var auditoria = _repositorioAuditoria.FindById(auditoriaId);
            if (auditoria == null)
                throw new ArgumentException("No existe una auditoría con ese Id.");

            return AuditoriaPrestamoMapper.ToDto(auditoria);
        }
    }
}
