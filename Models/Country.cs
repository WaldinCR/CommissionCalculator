namespace CommissionCalculator.Models;

/// <summary>
/// Entidad de dominio que representa un país con su configuración de comisión.
/// Capa: Datos/Dominio
/// </summary>
public class Country
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Flag { get; set; } = string.Empty;
    public string Currency { get; set; } = "USD";
    public string CurrencySymbol { get; set; } = "$";
    public decimal CommissionRate { get; set; }
    public decimal MinSalesThreshold { get; set; } = 0;
    public decimal BonusRate { get; set; } = 0;
    public decimal BonusThreshold { get; set; } = 0;
}
