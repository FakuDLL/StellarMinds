namespace StellarMinds.LogicaNegocio.CustomException
{
    public class PrestamoInvalidoException : DomainException
    {
        public PrestamoInvalidoException(string mensaje) : base(mensaje)
        {
        }
    }
}
