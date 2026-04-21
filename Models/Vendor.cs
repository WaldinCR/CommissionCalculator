namespace CommissionCalculator.Models;

/// <summary>
/// Representa un vendedor del sistema.
/// Capa: Dominio
/// </summary>
public class Vendor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string Role { get; set; } = "Vendedor"; // Vendedor | Admin
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
