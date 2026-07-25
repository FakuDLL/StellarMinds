using Microsoft.AspNetCore.Mvc;
using StellarMinds.WebApp.Services.Api;
using StellarMinds.WebApp.ViewModels;

namespace StellarMinds.WebApp.Controllers;

public class EquiposController : Controller
{
    private readonly IEquiposApiService _equiposApiService;

    public EquiposController(IEquiposApiService equiposApiService)
    {
        _equiposApiService = equiposApiService;
    }

    public async Task<IActionResult> Index(string? tipo)
    {
        var result = await _equiposApiService.ListarAsync(tipo);
        if (!result.Success) ViewBag.Error = result.ErrorMessage;
        return View(new EquipoListadoViewModel { Tipo = tipo, Equipos = result.Data ?? [] });
    }

    [HttpGet]
    public async Task<IActionResult> SociosPorTelescopio(int? telescopioId)
    {
        if (!RequireAnyRole("Administrador", "Coordinador")) return RedirectToAction("Login", "Usuario");

        var telescopios = await _equiposApiService.ListarAsync("telescopio");
        var model = new SociosPorTelescopioViewModel
        {
            TelescopioId = telescopioId ?? 0,
            Telescopios = telescopios.Data ?? [],
            Mensaje = telescopios.Success ? null : telescopios.ErrorMessage
        };

        if (!telescopioId.HasValue || telescopioId.Value <= 0)
            return View(model);

        var result = await _equiposApiService.ListarSociosPorTelescopioAsync(telescopioId.Value);
        model.Socios = result.Data ?? [];
        model.Mensaje = result.Success
            ? (model.Socios.Count == 0 ? "No se encontraron socios para el telescopio indicado." : model.Mensaje)
            : result.ErrorMessage;

        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        if (!RequireRole("Administrador")) return RedirectToAction("Login", "Usuario");
        return View(new EquipoFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EquipoFormViewModel model)
    {
        if (!RequireRole("Administrador")) return RedirectToAction("Login", "Usuario");
        if (!ModelState.IsValid) return View(model);

        var result = await _equiposApiService.AltaAsync(model.ToDto());
        if (!result.Success)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "No se pudo crear el equipo.");
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (!RequireRole("Administrador")) return RedirectToAction("Login", "Usuario");
        var result = await _equiposApiService.ObtenerAsync(id);
        if (!result.Success || result.Data == null)
        {
            TempData["Error"] = result.ErrorMessage ?? "Equipo no encontrado.";
            return RedirectToAction(nameof(Index));
        }

        return View(EquipoFormViewModel.FromDto(result.Data));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EquipoFormViewModel model)
    {
        if (!RequireRole("Administrador")) return RedirectToAction("Login", "Usuario");
        if (!ModelState.IsValid) return View(model);

        var result = await _equiposApiService.ActualizarAsync(model.ToDto());
        if (!result.Success)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "No se pudo actualizar el equipo.");
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (!RequireRole("Administrador")) return RedirectToAction("Login", "Usuario");
        var result = await _equiposApiService.BajaAsync(id);
        if (!result.Success) TempData["Error"] = result.ErrorMessage;
        return RedirectToAction(nameof(Index));
    }

    private bool RequireRole(string role) => HttpContext.Session.GetString("Rol") == role;
    private bool RequireAnyRole(params string[] roles) => roles.Contains(HttpContext.Session.GetString("Rol"));
}
