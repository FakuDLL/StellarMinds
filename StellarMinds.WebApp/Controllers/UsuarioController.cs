using Microsoft.AspNetCore.Mvc;
using StellarMinds.WebApp.Models;
using StellarMinds.WebApp.Services.Api;

namespace StellarMinds.WebApp.Controllers;

public class UsuarioController : Controller
{
    private readonly IAuthApiService _authApiService;

    public UsuarioController(IAuthApiService authApiService)
    {
        _authApiService = authApiService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var loginResponse = await _authApiService.LoginAsync(model.NombreUsuario ?? string.Empty, model.Password ?? string.Empty);
        if (!loginResponse.Success || loginResponse.Data?.Token is null)
        {
            model.ErrorMessage = loginResponse.ErrorMessage ?? "Credenciales inválidas.";
            return View(model);
        }

        HttpContext.Session.SetString("Token", loginResponse.Data.Token);
        HttpContext.Session.SetString("UsuarioId", loginResponse.Data.Usuario.Id.ToString());
        HttpContext.Session.SetString("NombreUsuario", loginResponse.Data.Usuario.NombreUsuario ?? string.Empty);
        HttpContext.Session.SetString("Rol", loginResponse.Data.Usuario.Rol ?? string.Empty);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Usuario");
    }
}
