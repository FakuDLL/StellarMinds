using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.ICasosUso;

namespace StellarMinds.WebApi.Controllers
{
    [ApiController]
    [Route("api/objetos-celestes")]
    public class ObjetosCelestesController : ControllerBase
    {
        private readonly ICUAltaObservacion _cuAltaObservacion;
        private readonly ICURankingObjetosCelestes _cuRankingObjetosCelestes;

        public ObjetosCelestesController(
            ICUAltaObservacion cuAltaObservacion,
            ICURankingObjetosCelestes cuRankingObjetosCelestes)
        {
            _cuAltaObservacion = cuAltaObservacion;
            _cuRankingObjetosCelestes = cuRankingObjetosCelestes;
        }

        [Authorize(Roles = "Socio")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_cuAltaObservacion.ListarObjetosCelestes());
        }

        [Authorize]
        [HttpGet("ranking")]
        public IActionResult GetRanking()
        {
            var ranking = _cuRankingObjetosCelestes.ObtenerRanking();
            if (!ranking.Any())
                return NotFound(new { mensaje = "No hay objetos celestes observados." });

            return Ok(ranking);
        }
    }
}
