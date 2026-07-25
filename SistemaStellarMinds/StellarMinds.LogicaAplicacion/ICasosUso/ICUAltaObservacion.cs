using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUAltaObservacion
    {
        List<DTOPrestamo> ListarPrestamosVigentes(int socioId);
        List<DTOObjetoCeleste> ListarObjetosCelestes();
        DTOEvaluacionObservacion Evaluar(DTOEvaluarObservacion dto, int socioId);
        DTOObservacion AltaObservacion(DTOAltaObservacion dto, int socioId);
    }
}
