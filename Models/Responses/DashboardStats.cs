namespace CommissionCalculator.Models.Responses;

/// <summary>
/// DTO con métricas agregadas para el dashboard administrativo.
/// </summary>
public class DashboardStats
{
    public int TotalCalculations { get; set; }
    public decimal TotalCommissionsPaid { get; set; }
    public decimal TotalSalesVolume { get; set; }
    public decimal AverageCommission { get; set; }
    public string TopCountry { get; set; } = string.Empty;
    public string TopVendor { get; set; } = string.Empty;
    public decimal TopVendorEarnings { get; set; }
    public List<CountryStats> ByCountry { get; set; } = new();
    public List<MonthlyStats> ByMonth { get; set; } = new();
}

public class CountryStats
{
    public string CountryName { get; set; } = string.Empty;
    public string CountryFlag { get; set; } = string.Empty;
    public int Calculations { get; set; }
    public decimal TotalCommissions { get; set; }
    public decimal TotalSales { get; set; }
}

public class MonthlyStats
{
    public string Month { get; set; } = string.Empty;
    public int Calculations { get; set; }
    public decimal TotalCommissions { get; set; }
}
