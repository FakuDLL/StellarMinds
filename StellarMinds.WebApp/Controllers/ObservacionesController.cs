using Microsoft.AspNetCore.Mvc;
using StellarMinds.WebApp.Services.Api;
using StellarMinds.WebApp.ViewModels;

namespace StellarMinds.WebApp.Controllers;

public class ObservacionesController : Controller
{
    private readonly IObservacionesApiService _observacionesApiService;

    public ObservacionesController(IObservacionesApiService observacionesApiService)
    {
        _observacionesApiService = observacionesApiService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        if (!RequireRole("Socio")) return RedirectToAction("Login", "Usuario");
        return View(await Cargar(new AltaObservacionViewModel()));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AltaObservacionViewModel model)
    {
        if (!RequireRole("Socio")) return RedirectToAction("Login", "Usuario");
        if (!model.EvaluacionVigente || string.IsNullOrWhiteSpace(model.Indicador) || string.IsNullOrWhiteSpace(model.Detalle))
            ModelState.AddModelError(string.Empty, "Debe evaluar la observación antes de confirmarla.");

        if (!ModelState.IsValid) return View(await Cargar(model));

        var result = await _observacionesApiService.AltaAsync(new ApiAltaObservacion
        {
            PrestamoId = model.PrestamoId,
            ObjetoCelesteId = model.ObjetoCelesteId,
            Fecha = model.Fecha,
            Indicador = model.Indicador,
            Detalle = model.Detalle
        });

        if (!result.Success)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "No se pudo crear la observación.");
            return View(await Cargar(model));
        }

        TempData["Mensaje"] = "Observación creada correctamente.";
        return RedirectToAction(nameof(Create));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Evaluar([FromBody] ApiEvaluarObservacion dto)
    {
        if (!RequireRole("Socio")) return Unauthorized();
        var result = await _observacionesApiService.EvaluarAsync(dto);
        if (!result.Success) return BadRequest(new { mensaje = result.ErrorMessage });
        return Json(result.Data);
    }

    private async Task<AltaObservacionViewModel> Cargar(AltaObservacionViewModel model)
    {
        var prestamos = await _observacionesApiService.ListarPrestamosVigentesAsync();
        var objetos = await _observacionesApiService.ListarObjetosCelestesAsync();
        model.Prestamos = prestamos.Data ?? [];
        model.ObjetosCelestes = objetos.Data ?? [];
        ViewBag.Error = prestamos.ErrorMessage ?? objetos.ErrorMessage;
        return model;
    }

    private bool RequireRole(string role) => HttpContext.Session.GetString("Rol") == role;
}
