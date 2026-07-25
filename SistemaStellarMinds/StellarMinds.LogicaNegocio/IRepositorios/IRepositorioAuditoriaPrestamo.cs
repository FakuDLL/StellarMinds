using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.IRepositorios
{
    public interface IRepositorioAuditoriaPrestamo
    {
        void Add(AuditoriaPrestamo auditoria);
        List<AuditoriaPrestamo> FindAll();
        List<AuditoriaPrestamo> FindByCoordinadorId(int coordinadorId);
        List<AuditoriaPrestamo> FindByPrestamoId(int prestamoId);
        AuditoriaPrestamo? FindById(int id);
    }
}
