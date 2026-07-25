using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellarMinds.LogicaNegocio.CustomException
{
    public class UsuarioInvalidoException : DomainException
    {
        public UsuarioInvalidoException(string mensaje) : base(mensaje)
        {
        }
    }
}
