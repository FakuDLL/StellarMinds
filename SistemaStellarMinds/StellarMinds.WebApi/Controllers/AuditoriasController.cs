using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.ICasosUso;

namespace StellarMinds.WebApi.Controllers
{
    [ApiController]
    [Route("api/auditorias")]
    public class AuditoriasController : ControllerBase
    {
        private readonly ICUListadoAuditoriaPrestamos _cuListado;
        private readonly ICUDetalleAuditoriaPrestamo _cuDetalle;

        public AuditoriasController(
            ICUListadoAuditoriaPrestamos cuListado,
            ICUDetalleAuditoriaPrestamo cuDetalle)
        {
            _cuListado = cuListado;
            _cuDetalle = cuDetalle;
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] int? coordinadorId)
        {
            try
            {
                List<StellarMinds.DTOs.DataTransferObjects.DTOAuditoriaPrestamo> auditorias;

                if (coordinadorId.HasValue)
                {
                    auditorias = _cuListado.ListarPorCoordinador(coordinadorId.Value);
                    if (!auditorias.Any())
                        return NotFound(new { mensaje = $"No hay auditorías registradas para el coordinador {coordinadorId.Value}." });
                }
                else
                {
                    auditorias = _cuListado.Listar();
                    if (!auditorias.Any())
                        return NotFound(new { mensaje = "No hay auditorías registradas." });
                }

                return Ok(auditorias);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var dto = _cuDetalle.ObtenerDetalle(id);
                return Ok(dto);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("prestamo/{prestamoId:int}")]
        public IActionResult GetByPrestamo(int prestamoId)
        {
            try
            {
                var auditorias = _cuListado.ListarPorPrestamo(prestamoId);
                if (!auditorias.Any())
                    return NotFound(new { mensaje = $"El préstamo {prestamoId} no tiene auditorías registradas." });

                return Ok(auditorias);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
