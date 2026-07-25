namespace StellarMinds.LogicaNegocio.CustomException
{
    public class ObservacionInvalidaException : DomainException
    {
        public ObservacionInvalidaException(string message)
            : base(message)
        {
        }
    }
}
