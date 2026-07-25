namespace StellarMinds.LogicaNegocio.CustomException
{
    public class EquipoSinDisponibilidadException : DomainException
    {
        public EquipoSinDisponibilidadException(string mensaje) : base(mensaje)
        {
        }
    }
}
