using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUAltaUsuario
    {
        DtoUsuarioLogueado AltaUsuario(DtoAltaUsuario dtoAltaUsuario);
    }
}