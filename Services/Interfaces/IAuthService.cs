using CommissionCalculator.Models;
using CommissionCalculator.Models.Requests;

namespace CommissionCalculator.Services.Interfaces;

/// Interfaz del servicio de autenticación
/// Capa: Lógica de Negocio — Manejo de sesiones y roles

public interface IAuthService
{
    Vendor? CurrentUser { get; }
    bool IsAuthenticated { get; }
    bool IsAdmin { get; }
    bool Login(LoginRequest request);
    void Logout();
    event Action? OnAuthStateChanged;
}
