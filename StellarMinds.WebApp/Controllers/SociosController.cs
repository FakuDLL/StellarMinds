using Microsoft.AspNetCore.Mvc;
using StellarMinds.WebApp.Services.Api;
using StellarMinds.WebApp.ViewModels;

namespace StellarMinds.WebApp.Controllers;

public class SociosController : Controller
{
    private readonly IUsuariosApiService _usuariosApiService;

    public SociosController(IUsuariosApiService usuariosApiService)
    {
        _usuariosApiService = usuariosApiService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        if (!RequireRole("Administrador")) return RedirectToAction("Login", "Usuario");
        return View(new AltaSocioViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AltaSocioViewModel model)
    {
        if (!RequireRole("Administrador")) return RedirectToAction("Login", "Usuario");
        if (!ModelState.IsValid) return View(model);

        var result = await _usuariosApiService.AltaSocioAsync(new ApiAltaUsuario
        {
            NombreCompleto = model.NombreCompleto,
            Direccion = model.Direccion,
            Telefono = model.Telefono,
            Email = model.Email,
            NombreUsuario = model.NombreUsuario,
            Password = model.Password
        });

        if (!result.Success)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "No se pudo crear el socio.");
            return View(model);
        }

        TempData["Mensaje"] = "Socio creado correctamente.";
        return RedirectToAction(nameof(Create));
    }

    private bool RequireRole(string role) => HttpContext.Session.GetString("Rol") == role;
}
