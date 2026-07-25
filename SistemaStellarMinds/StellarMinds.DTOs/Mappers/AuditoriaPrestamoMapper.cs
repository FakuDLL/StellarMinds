using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.DTOs.Mappers
{
    public static class AuditoriaPrestamoMapper
    {
        public static DTOAuditoriaPrestamo ToDto(AuditoriaPrestamo auditoria)
        {
            return new DTOAuditoriaPrestamo
            {
                Id = auditoria.Id,
                PrestamoId = auditoria.Prestamo.Id,
                Accion = auditoria.Accion.ToString(),
                Fecha = auditoria.Fecha,
                CoordinadorId = auditoria.Coordinador.Id,
                CoordinadorNombre = auditoria.Coordinador.NombreUsuario,
                SocioId = auditoria.Prestamo.Socio.Id,
                SocioNombre = auditoria.Prestamo.Socio.NombreCompleto,
                PrestamoFechaInicio = auditoria.Prestamo.FechaInicio,
                PrestamoFechaFin = auditoria.Prestamo.FechaFin,
                PrestamoEstado = auditoria.Prestamo.Estado.ToString(),
                AuditoriaDetalleUrl = $"/api/auditorias/{auditoria.Id}",
                PrestamoDetalleUrl = $"/api/prestamos/{auditoria.Prestamo.Id}"
            };
        }

        public static List<DTOAuditoriaPrestamo> ToDtoList(IEnumerable<AuditoriaPrestamo> auditorias)
        {
            return auditorias.Select(ToDto).ToList();
        }
    }
}
