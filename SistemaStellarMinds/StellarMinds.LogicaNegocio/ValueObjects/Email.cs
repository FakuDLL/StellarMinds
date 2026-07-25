using StellarMinds.LogicaNegocio.CustomException;
using System.Text.RegularExpressions;

namespace StellarMinds.LogicaNegocio.ValueObjects
{
    public record Email
    {
        public string Valor { get; init; }

        public Email(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new UsuarioInvalidoException("El email es obligatorio.");

            valor = valor.Trim();

            if (!Regex.IsMatch(valor, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new UsuarioInvalidoException("El formato del email no es válido.");

            Valor = valor;
        }

        private Email()
        {
            Valor = string.Empty;
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}