using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUListadoAuditoriaPrestamos : ICUListadoAuditoriaPrestamos
    {
        private readonly IRepositorioAuditoriaPrestamo _repositorioAuditoria;

        public CUListadoAuditoriaPrestamos(IRepositorioAuditoriaPrestamo repositorioAuditoria)
        {
            _repositorioAuditoria = repositorioAuditoria;
        }

        public List<DTOAuditoriaPrestamo> Listar()
        {
            var auditorias = _repositorioAuditoria.FindAll();
            return AuditoriaPrestamoMapper.ToDtoList(auditorias);
        }

        public List<DTOAuditoriaPrestamo> ListarPorCoordinador(int coordinadorId)
        {
            if (coordinadorId <= 0)
                throw new ArgumentException("El coordinador es obligatorio.");

            var auditorias = _repositorioAuditoria.FindByCoordinadorId(coordinadorId);
            return AuditoriaPrestamoMapper.ToDtoList(auditorias);
        }

        public List<DTOAuditoriaPrestamo> ListarPorPrestamo(int prestamoId)
        {
            if (prestamoId <= 0)
                throw new ArgumentException("El préstamo es obligatorio.");

            var auditorias = _repositorioAuditoria.FindByPrestamoId(prestamoId);
            return AuditoriaPrestamoMapper.ToDtoList(auditorias);
        }
    }
}
