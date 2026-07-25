using StellarMinds.LogicaNegocio.Enums;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class AuditoriaPrestamo
    {
        public int Id { get; private set; }
        public DateTime Fecha { get; private set; }
        public AccionPrestamo Accion { get; private set; }
        public Prestamo Prestamo { get; private set; } = null!;
        public Usuario Coordinador { get; private set; } = null!;

        private AuditoriaPrestamo()
        {
        }

        public AuditoriaPrestamo(
            AccionPrestamo accion,
            Prestamo prestamo,
            Usuario coordinador)
        {
            Fecha = DateTime.Now;
            Accion = accion;
            Prestamo = prestamo ?? throw new ArgumentNullException(nameof(prestamo));
            Coordinador = coordinador ?? throw new ArgumentNullException(nameof(coordinador));
        }
    }
}
