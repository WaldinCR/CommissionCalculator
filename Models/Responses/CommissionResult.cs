namespace CommissionCalculator.Models.Responses;

/// <summary>
/// DTO de respuesta con el resultado del cálculo de comisión.
/// Capa: Lógica de Negocio → Presentación
/// </summary>
public class CommissionResult
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string VendorName { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string CountryFlag { get; set; } = string.Empty;
    public string CurrencySymbol { get; set; } = "$";
    public decimal TotalSales { get; set; }
    public decimal Discounts { get; set; }
    public decimal NetSales { get; set; }
    public decimal CommissionRate { get; set; }
    public decimal CommissionAmount { get; set; }
    public decimal BonusAmount { get; set; }
    public decimal TotalEarnings { get; set; }
    public string Period { get; set; } = string.Empty;
    public DateTime CalculatedAt { get; set; } = DateTime.Now;
    public bool HasBonus { get; set; }
    public string Tier { get; set; } = "Standard";
}
