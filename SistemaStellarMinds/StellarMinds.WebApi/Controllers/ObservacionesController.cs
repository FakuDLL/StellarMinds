using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.CustomException;
using System.Security.Claims;

namespace StellarMinds.WebApi.Controllers
{
    [ApiController]
    [Route("api/observaciones")]
    public class ObservacionesController : ControllerBase
    {
        private readonly ICUAltaObservacion _cuAltaObservacion;

        public ObservacionesController(ICUAltaObservacion cuAltaObservacion)
        {
            _cuAltaObservacion = cuAltaObservacion;
        }

        [Authorize(Roles = "Socio")]
        [HttpGet("prestamos-vigentes")]
        public IActionResult GetPrestamosVigentes()
        {
            try
            {
                var socioId = ObtenerSocioId();
                return Ok(_cuAltaObservacion.ListarPrestamosVigentes(socioId));
            }
            catch (DomainException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(503, new { mensaje = ex.Message });
            }
            catch (HttpRequestException)
            {
                return StatusCode(503, new { mensaje = "No se pudo obtener la evaluación de Gemini." });
            }
        }

        [Authorize(Roles = "Socio")]
        [HttpPost("evaluar")]
        public IActionResult Evaluar([FromBody] DTOEvaluarObservacion dto)
        {
            try
            {
                var socioId = ObtenerSocioId();
                return Ok(_cuAltaObservacion.Evaluar(dto, socioId));
            }
            catch (DomainException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(503, new { mensaje = ex.Message });
            }
            catch (HttpRequestException)
            {
                return StatusCode(503, new { mensaje = "No se pudo obtener la evaluación de Gemini." });
            }
        }

        [Authorize(Roles = "Socio")]
        [HttpPost]
        public IActionResult Post([FromBody] DTOAltaObservacion dto)
        {
            try
            {
                var socioId = ObtenerSocioId();
                var observacion = _cuAltaObservacion.AltaObservacion(dto, socioId);
                return StatusCode(201, observacion);
            }
            catch (DomainException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        private int ObtenerSocioId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null || !int.TryParse(claim.Value, out var socioId))
                throw new ObservacionInvalidaException("No se pudo obtener el socio autenticado.");

            return socioId;
        }
    }
}
