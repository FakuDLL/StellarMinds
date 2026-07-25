using Microsoft.AspNetCore.Mvc;
using StellarMinds.WebApp.Services.Api;
using StellarMinds.WebApp.ViewModels;

namespace StellarMinds.WebApp.Controllers;

public class AuditoriasController : Controller
{
    private readonly IAuditoriasApiService _auditoriasApiService;

    public AuditoriasController(IAuditoriasApiService auditoriasApiService)
    {
        _auditoriasApiService = auditoriasApiService;
    }

    public async Task<IActionResult> Index(int? coordinadorId)
    {
        if (!RequireRole("Administrador")) return RedirectToAction("Login", "Usuario");

        var result = await _auditoriasApiService.ListarAsync(coordinadorId);
        return View(new AuditoriaListadoViewModel
        {
            CoordinadorId = coordinadorId,
            Mensaje = result.Success ? null : result.ErrorMessage,
            Auditorias = result.Data ?? []
        });
    }

    public async Task<IActionResult> Details(int id)
    {
        if (!RequireRole("Administrador")) return RedirectToAction("Login", "Usuario");

        var result = await _auditoriasApiService.ObtenerAsync(id);
        return View(new AuditoriaDetalleViewModel
        {
            Mensaje = result.Success ? null : result.ErrorMessage,
            Auditoria = result.Data
        });
    }

    private bool RequireRole(string role) => HttpContext.Session.GetString("Rol") == role;
}
