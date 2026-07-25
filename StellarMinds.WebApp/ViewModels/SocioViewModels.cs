using System.ComponentModel.DataAnnotations;

namespace StellarMinds.WebApp.ViewModels;

public class AltaSocioViewModel
{
    [Required]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required]
    public string Direccion { get; set; } = string.Empty;

    [Required]
    public string Telefono { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
