using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Enums;

namespace StellarMinds.LogicaNegocio.IRepositorios
{
    public interface IRepositorioPrestamo
    {
        int Add(Prestamo prestamo);
        Prestamo? FindById(int id);
        List<Prestamo> FindBySocioYEstado(int socioId, EstadoPrestamo estado);
        List<Prestamo> FindBySocioYMesAnio(int socioId, int mes, int anio);
        List<Usuario> FindSociosPorTelescopio(int telescopioId);
        bool ExistePrestamoActivoPorEquipo(int equipoId);
        void Update(Prestamo prestamo);
    }
}
