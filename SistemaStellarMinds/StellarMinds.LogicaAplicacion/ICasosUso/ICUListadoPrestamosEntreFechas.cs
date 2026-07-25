using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUListadoPrestamosEntreFechas
    {
        List<DTOPrestamoConAtraso> ListarPorSocioMesAnio(int socioId, int mes, int anio);
    }
}
