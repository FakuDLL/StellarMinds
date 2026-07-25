using Microsoft.AspNetCore.Mvc;
using StellarMinds.WebApp.Services.Api;
using StellarMinds.WebApp.ViewModels;

namespace StellarMinds.WebApp.Controllers;

public class PrestamosController : Controller
{
    private readonly IPrestamosApiService _prestamosApiService;
    private readonly IUsuariosApiService _usuariosApiService;
    private readonly IEquiposApiService _equiposApiService;

    public PrestamosController(
        IPrestamosApiService prestamosApiService,
        IUsuariosApiService usuariosApiService,
        IEquiposApiService equiposApiService)
    {
        _prestamosApiService = prestamosApiService;
        _usuariosApiService = usuariosApiService;
        _equiposApiService = equiposApiService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        if (!RequireRole("Coordinador")) return RedirectToAction("Login", "Usuario");
        return View(await CargarAltaPrestamo(new AltaPrestamoViewModel()));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AltaPrestamoViewModel model)
    {
        if (!RequireRole("Coordinador")) return RedirectToAction("Login", "Usuario");
        if (!ModelState.IsValid) return View(await CargarAltaPrestamo(model));

        var result = await _prestamosApiService.AltaAsync(new ApiAltaPrestamo
        {
            SocioId = model.SocioId,
            TelescopioId = model.TelescopioId,
            MonturaId = model.MonturaId,
            CamaraId = model.CamaraId == 0 ? null : model.CamaraId,
            OcularId = model.OcularId == 0 ? null : model.OcularId,
            FechaInicio = model.FechaInicio,
            FechaFin = model.FechaFin
        });

        if (!result.Success)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "No se pudo crear el préstamo.");
            return View(await CargarAltaPrestamo(model));
        }

        TempData["Mensaje"] = "Préstamo creado correctamente.";
        return RedirectToAction(nameof(Create));
    }

    [HttpGet]
    public async Task<IActionResult> Devolucion(int? socioId)
    {
        if (!RequireRole("Coordinador")) return RedirectToAction("Login", "Usuario");
        var model = new DevolucionPrestamoViewModel { SocioId = socioId ?? 0 };
        await CargarSocios(model);

        if (socioId.HasValue && socioId.Value > 0)
        {
            var prestamos = await _prestamosApiService.ListarPorSocioAsync(socioId.Value, "EN_PRESTAMO");
            if (prestamos.Success) model.Prestamos = prestamos.Data ?? [];
            else ViewBag.Error = prestamos.ErrorMessage;
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> MisPrestamos(int? mes, int? anio)
    {
        if (!RequireRole("Socio")) return RedirectToAction("Login", "Usuario");

        var model = new MisPrestamosViewModel
        {
            Mes = mes ?? DateTime.Today.Month,
            Anio = anio ?? DateTime.Today.Year,
            BusquedaRealizada = mes.HasValue || anio.HasValue
        };

        if (!model.BusquedaRealizada)
            return View(model);

        if (!TryValidateModel(model))
            return View(model);

        var result = await _prestamosApiService.MisPrestamosAsync(model.Mes, model.Anio);
        model.Prestamos = result.Data ?? [];
        model.Mensaje = result.Success
            ? (model.Prestamos.Count == 0 ? "No se encontraron prestamos para el periodo indicado." : null)
            : result.ErrorMessage;

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Devolver(int prestamoId, int socioId)
    {
        if (!RequireRole("Coordinador")) return RedirectToAction("Login", "Usuario");
        var result = await _prestamosApiService.DevolverAsync(prestamoId);
        if (!result.Success) TempData["Error"] = result.ErrorMessage;
        else TempData["Mensaje"] = "Préstamo devuelto correctamente.";

        return RedirectToAction(nameof(Devolucion), new { socioId });
    }

    [HttpGet]
    public async Task<IActionResult> Disponibilidad(string tipo, int id)
    {
        if (!RequireRole("Coordinador")) return Unauthorized();
        var result = await _equiposApiService.DisponibilidadAsync(tipo, id);
        if (!result.Success) return BadRequest(new { disponible = false, mensaje = result.ErrorMessage });
        return Json(new { disponible = result.Data?.Disponible ?? false, mensaje = result.Data?.Mensaje, cantidadDisponible = result.Data?.CantidadDisponible });
    }

    private async Task<AltaPrestamoViewModel> CargarAltaPrestamo(AltaPrestamoViewModel model)
    {
        var socios = await _usuariosApiService.ListarSociosAsync();
        var telescopios = await _equiposApiService.ListarAsync("telescopio");
        var monturas = await _equiposApiService.ListarAsync("montura");
        var camaras = await _equiposApiService.ListarAsync("camara");
        var oculares = await _equiposApiService.ListarAsync("ocular");

        model.Socios = socios.Data ?? [];
        model.Telescopios = telescopios.Data ?? [];
        model.Monturas = monturas.Data ?? [];
        model.Camaras = camaras.Data ?? [];
        model.Oculares = oculares.Data ?? [];
        ViewBag.Error = socios.ErrorMessage ?? telescopios.ErrorMessage ?? monturas.ErrorMessage ?? camaras.ErrorMessage ?? oculares.ErrorMessage;
        return model;
    }

    private async Task CargarSocios(DevolucionPrestamoViewModel model)
    {
        var socios = await _usuariosApiService.ListarSociosAsync();
        model.Socios = socios.Data ?? [];
        if (!socios.Success) ViewBag.Error = socios.ErrorMessage;
    }

    private bool RequireRole(string role) => HttpContext.Session.GetString("Rol") == role;
}
