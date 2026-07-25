using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Enums;

namespace StellarMinds.DTOs.Mappers
{
    public static class PrestamoMapper
    {
        public static DTOPrestamo ToDto(Prestamo prestamo)
        {
            return new DTOPrestamo
            {
                Id = prestamo.Id,
                SocioId = prestamo.Socio.Id,
                SocioNombre = prestamo.Socio.NombreCompleto,
                TelescopioId = prestamo.Telescopio.Id,
                MonturaId = prestamo.Montura.Id,
                CamaraId = prestamo.Camara?.Id,
                OcularId = prestamo.Ocular?.Id,
                FechaInicio = prestamo.FechaInicio,
                FechaFin = prestamo.FechaFin,
                Estado = prestamo.Estado.ToString()
            };
        }

        public static List<DTOPrestamo> ToDtoList(IEnumerable<Prestamo> prestamos)
        {
            return prestamos.Select(ToDto).ToList();
        }

        public static DTOPrestamoConAtraso ToDtoConAtraso(Prestamo prestamo, DateTime fechaActual)
        {
            return new DTOPrestamoConAtraso
            {
                Id = prestamo.Id,
                SocioId = prestamo.Socio.Id,
                SocioNombre = prestamo.Socio.NombreCompleto,
                TelescopioId = prestamo.Telescopio.Id,
                MonturaId = prestamo.Montura.Id,
                CamaraId = prestamo.Camara?.Id,
                OcularId = prestamo.Ocular?.Id,
                FechaInicio = prestamo.FechaInicio,
                FechaFin = prestamo.FechaFin,
                Estado = prestamo.Estado.ToString(),
                EstaAtrasado = prestamo.Estado == EstadoPrestamo.EN_PRESTAMO
                    && fechaActual.Date > prestamo.FechaFin.Date
            };
        }

        public static List<DTOPrestamoConAtraso> ToDtoConAtrasoList(IEnumerable<Prestamo> prestamos, DateTime fechaActual)
        {
            return prestamos.Select(p => ToDtoConAtraso(p, fechaActual)).ToList();
        }
    }
}
