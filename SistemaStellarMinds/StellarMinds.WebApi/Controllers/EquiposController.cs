using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.CustomException;

namespace StellarMinds.WebApi.Controllers
{
    [ApiController]
    [Route("api/equipos")]
    public class EquiposController : ControllerBase
    {
        private readonly ICUAltaEquipo _cuAltaEquipo;
        private readonly ICUObtenerEquipos _cuObtenerEquipos;
        private readonly ICUObtenerEquipo _cuObtenerEquipo;
        private readonly ICUActualizarEquipo _cuActualizarEquipo;
        private readonly ICUBajaEquipo _cuBajaEquipo;
        private readonly ICUDisponibilidadEquipo _cuDisponibilidadEquipo;
        private readonly ICUListadoSociosPorTelescopio _cuListadoSociosPorTelescopio;

        public EquiposController(
            ICUAltaEquipo cuAltaEquipo,
            ICUObtenerEquipos cuObtenerEquipos,
            ICUObtenerEquipo cuObtenerEquipo,
            ICUActualizarEquipo cuActualizarEquipo,
            ICUBajaEquipo cuBajaEquipo,
            ICUDisponibilidadEquipo cuDisponibilidadEquipo,
            ICUListadoSociosPorTelescopio cuListadoSociosPorTelescopio)
        {
            _cuAltaEquipo = cuAltaEquipo;
            _cuObtenerEquipos = cuObtenerEquipos;
            _cuObtenerEquipo = cuObtenerEquipo;
            _cuActualizarEquipo = cuActualizarEquipo;
            _cuBajaEquipo = cuBajaEquipo;
            _cuDisponibilidadEquipo = cuDisponibilidadEquipo;
            _cuListadoSociosPorTelescopio = cuListadoSociosPorTelescopio;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? tipo)
        {
            var equipos = _cuObtenerEquipos.ObtenerEquipos();
            if (!string.IsNullOrWhiteSpace(tipo))
            {
                var tipoFiltro = tipo.Trim().ToLowerInvariant();
                equipos = equipos.Where(e => e.TipoEquipo.ToLowerInvariant() == tipoFiltro).ToList();
            }

            return Ok(equipos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var equipo = _cuObtenerEquipo.ObtenerPorId(id);
                return Ok(equipo);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody] DTOAltaEquipo dto)
        {
            try
            {
                var id = _cuAltaEquipo.AltaEquipo(dto);
                return CreatedAtAction(nameof(GetById), new { id }, new { id });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] DTOActualizarEquipo dto)
        {
            if (dto == null || dto.Id != id)
                return BadRequest(new { mensaje = "El id del equipo no coincide." });

            try
            {
                _cuActualizarEquipo.ActualizarEquipo(dto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _cuBajaEquipo.BajaEquipo(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [HttpGet("{tipo}/{id:int}/disponibilidad")]
        public IActionResult Disponibilidad(string tipo, int id)
        {
            try
            {
                var dto = _cuDisponibilidadEquipo.ObtenerDisponibilidad(tipo, id);
                return Ok(dto);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador,Coordinador")]
        [HttpGet("telescopios/{telescopioId:int}/socios")]
        public IActionResult GetSociosPorTelescopio(int telescopioId)
        {
            try
            {
                var socios = _cuListadoSociosPorTelescopio.ListarSociosPorTelescopio(telescopioId);
                if (!socios.Any())
                    return NotFound(new { mensaje = "No se encontraron socios con préstamos para el telescopio indicado." });

                return Ok(socios);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
