using Microsoft.AspNetCore.Mvc;
using StellarMinds.WebApp.Services.Api;
using StellarMinds.WebApp.ViewModels;

namespace StellarMinds.WebApp.Controllers;

public class ObjetosCelestesController : Controller
{
    private readonly IObjetosCelestesApiService _objetosCelestesApiService;

    public ObjetosCelestesController(IObjetosCelestesApiService objetosCelestesApiService)
    {
        _objetosCelestesApiService = objetosCelestesApiService;
    }

    [HttpGet]
    public async Task<IActionResult> Ranking()
    {
        if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("Rol")))
            return RedirectToAction("Login", "Usuario");

        var result = await _objetosCelestesApiService.RankingAsync();
        var ranking = result.Data ?? [];
        return View(new RankingObjetosCelestesViewModel
        {
            Ranking = ranking,
            Mensaje = result.Success
                ? (ranking.Count == 0 ? "No hay objetos celestes observados." : null)
                : result.ErrorMessage
        });
    }
}
