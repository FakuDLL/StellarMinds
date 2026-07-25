using StellarMinds.LogicaNegocio.CustomException;
using StellarMinds.LogicaNegocio.Enums;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Prestamo
    {
        private readonly List<AuditoriaPrestamo> _auditorias = new();

        public int Id { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }
        public EstadoPrestamo Estado { get; private set; }
        public Usuario Socio { get; private set; } = null!;
        public Telescopio Telescopio { get; private set; } = null!;
        public Montura Montura { get; private set; } = null!;
        public Camara? Camara { get; private set; }
        public Ocular? Ocular { get; private set; }
        public IReadOnlyCollection<AuditoriaPrestamo> Auditorias => _auditorias.AsReadOnly();

        private Prestamo()
        {
        }

        public Prestamo(
            DateTime fechaInicio,
            DateTime fechaFin,
            Usuario socio,
            Telescopio telescopio,
            Montura montura,
            Camara? camara,
            Ocular? ocular)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Estado = EstadoPrestamo.EN_PRESTAMO;
            Socio = socio ?? throw new ArgumentNullException(nameof(socio));
            Telescopio = telescopio ?? throw new ArgumentNullException(nameof(telescopio));
            Montura = montura ?? throw new ArgumentNullException(nameof(montura));
            Camara = camara;
            Ocular = ocular;
        }

        public void Devolver()
        {
            if (Estado == EstadoPrestamo.DEVUELTO)
                throw new PrestamoInvalidoException("El préstamo ya fue devuelto.");

            Estado = EstadoPrestamo.DEVUELTO;
        }
    }
}
