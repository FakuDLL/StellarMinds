using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.CustomException;

namespace StellarMinds.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ICUAltaUsuario _cuAltaUsuario;
        private readonly ICUListadoUsuarios _cuListadoUsuarios;

        public UsuariosController(ICUAltaUsuario cuAltaUsuario, ICUListadoUsuarios cuListadoUsuarios)
        {
            _cuAltaUsuario = cuAltaUsuario;
            _cuListadoUsuarios = cuListadoUsuarios;
        }

        [Authorize(Roles = "Administrador,Coordinador")]
        [HttpGet]
        public IActionResult Get([FromQuery] string? rol)
        {
            try
            {
                return Ok(_cuListadoUsuarios.Listar(rol));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody] DtoAltaUsuario dto)
        {
            try
            {
                var id = _cuAltaUsuario.AltaUsuario(dto).Id;
                return Created(string.Empty, new { id });
            }
            catch (UsuarioInvalidoException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (DomainException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error interno." });
            }
        }
    }
}
