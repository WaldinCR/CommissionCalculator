using System.ComponentModel.DataAnnotations;

namespace CommissionCalculator.Models.Requests;


/// DTO de login de usuario

public class LoginRequest
{
    [Required(ErrorMessage = "Debe ingresar su correo.")]
    [EmailAddress(ErrorMessage = "Correo inválido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe ingresar su contraseña.")]
    [MinLength(4, ErrorMessage = "Contraseña mínima de 4 caracteres.")]
    public string Password { get; set; } = string.Empty;
}
