using CommissionCalculator.Models;
using CommissionCalculator.Models.Requests;
using CommissionCalculator.Services.Interfaces;

namespace CommissionCalculator.Services;


/// Implementación del servicio de autenticación
/// Capa: Lógica de Negocio / Manejo de sesión en memoria
/// Usuarios precargados para demostración

public class AuthService : IAuthService
{
    private readonly List<(string Email, string Password, Vendor Vendor)> _users = new()
    {
        ("admin@comisiones.com", "admin123", new Vendor
        {
            Name = "Administrador",
            Email = "admin@comisiones.com",
            CountryCode = "DO",
            Role = "Admin"
        }),
        ("vendedor@comisiones.com", "vend123", new Vendor
        {
            Name = "Carlos Pérez",
            Email = "vendedor@comisiones.com",
            CountryCode = "DO",
            Role = "Vendedor"
        }),
        ("maria@comisiones.com", "maria123", new Vendor
        {
            Name = "María García",
            Email = "maria@comisiones.com",
            CountryCode = "US",
            Role = "Vendedor"
        })
    };

    public Vendor? CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;
    public bool IsAdmin => CurrentUser?.Role == "Admin";

    public event Action? OnAuthStateChanged;

    public bool Login(LoginRequest request)
    {
        var found = _users.FirstOrDefault(u =>
            u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase) &&
            u.Password == request.Password);

        if (found.Vendor != null)
        {
            CurrentUser = found.Vendor;
            OnAuthStateChanged?.Invoke();
            return true;
        }
        return false;
    }

    public void Logout()
    {
        CurrentUser = null;
        OnAuthStateChanged?.Invoke();
    }
}
