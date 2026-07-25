using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.CustomException;
using System.Security.Claims;

namespace StellarMinds.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly ICUAltaPrestamo _cuAltaPrestamo;
        private readonly ICUDevolucionPrestamo _cuDevolucionPrestamo;
        private readonly ICUListadoPrestamosPorSocio _cuListadoPrestamosPorSocio;
        private readonly ICUListadoPrestamosEntreFechas _cuListadoPrestamosEntreFechas;
        private readonly ICUDetallePrestamo _cuDetallePrestamo;

        public PrestamosController(
            ICUAltaPrestamo cuAltaPrestamo,
            ICUDevolucionPrestamo cuDevolucionPrestamo,
            ICUListadoPrestamosPorSocio cuListadoPrestamosPorSocio,
            ICUListadoPrestamosEntreFechas cuListadoPrestamosEntreFechas,
            ICUDetallePrestamo cuDetallePrestamo)
        {
            _cuAltaPrestamo = cuAltaPrestamo;
            _cuDevolucionPrestamo = cuDevolucionPrestamo;
            _cuListadoPrestamosPorSocio = cuListadoPrestamosPorSocio;
            _cuListadoPrestamosEntreFechas = cuListadoPrestamosEntreFechas;
            _cuDetallePrestamo = cuDetallePrestamo;
        }

        [Authorize(Roles = "Coordinador")]
        [HttpPost]
        public IActionResult Post([FromBody] DTOAltaPrestamo dto)
        {
            try
            {
                var coordinadorId = ObtenerCoordinadorId();
                var idPrestamo = _cuAltaPrestamo.AltaPrestamo(dto, coordinadorId);
                return CreatedAtAction(nameof(Post), new { id = idPrestamo }, new { idPrestamo });
            }
            catch (DomainException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error interno." });
            }
        }

        [Authorize(Roles = "Coordinador")]
        [HttpPost("{id:int}/devolver")]
        public IActionResult Devolver(int id)
        {
            try
            {
                var coordinadorId = ObtenerCoordinadorId();
                _cuDevolucionPrestamo.DevolverPrestamo(id, coordinadorId);
                return NoContent();
            }
            catch (PrestamoInvalidoException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (EquipoSinDisponibilidadException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
            catch (CompatibilidadEquiposException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
            catch (DomainException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error interno." });
            }
        }

        [Authorize(Roles = "Coordinador")]
        [HttpGet]
        public IActionResult Get([FromQuery] int socioId, [FromQuery] string estado)
        {
            try
            {
                var prestamos = _cuListadoPrestamosPorSocio.ListarPorSocioYEstado(socioId, estado);
                return Ok(prestamos);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador,Coordinador")]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var prestamo = _cuDetallePrestamo.ObtenerDetalle(id);
                return Ok(prestamo);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Socio")]
        [HttpGet("mis-prestamos")]
        public IActionResult GetMisPrestamosPorMes([FromQuery] int mes, [FromQuery] int anio)
        {
            try
            {
                var socioId = ObtenerUsuarioId("No se pudo obtener el socio autenticado.");
                var prestamos = _cuListadoPrestamosEntreFechas.ListarPorSocioMesAnio(socioId, mes, anio);

                if (!prestamos.Any())
                    return NotFound(new { mensaje = $"No se encontraron préstamos para el mes {mes} del año {anio}." });

                return Ok(prestamos);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (DomainException ex)
            {
                return Unauthorized(new { mensaje = ex.Message });
            }
        }

        private int ObtenerCoordinadorId()
        {
            return ObtenerUsuarioId("No se pudo obtener el coordinador autenticado.");
        }

        private int ObtenerUsuarioId(string mensajeError)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null || !int.TryParse(claim.Value, out var usuarioId))
                throw new DomainException(mensajeError);

            return usuarioId;
        }
    }
}
