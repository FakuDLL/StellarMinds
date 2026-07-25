using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using StellarMinds.LogicaNegocio.CustomException;

namespace StellarMinds.LogicaNegocio.ValueObjects
{
    public record PasswordPlano
    {
        public string Valor { get; init; }

        public PasswordPlano(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new UsuarioInvalidoException("La contraseña es obligatoria.");

            if (valor.Length < 8)
                throw new UsuarioInvalidoException("La contraseña debe tener al menos 8 caracteres.");

            if (!Regex.IsMatch(valor, @"[A-Z]"))
                throw new UsuarioInvalidoException("La contraseña debe incluir al menos una mayúscula.");

            if (!Regex.IsMatch(valor, @"[a-z]"))
                throw new UsuarioInvalidoException("La contraseña debe incluir al menos una minúscula.");
            
            if (!Regex.IsMatch(valor, @"\d"))
                throw new UsuarioInvalidoException("La contraseña debe incluir al menos un número.");

            if (!Regex.IsMatch(valor, @"[^a-zA-Z0-9]"))
                throw new UsuarioInvalidoException("La contraseña debe incluir al menos un carácter especial.");

            Valor = valor;
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}
