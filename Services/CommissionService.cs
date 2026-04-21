using CommissionCalculator.Models;
using CommissionCalculator.Models.Requests;
using CommissionCalculator.Models.Responses;
using CommissionCalculator.Services.Interfaces;

namespace CommissionCalculator.Services;

/// Implementación del servicio de comisiones.


public class CommissionService : ICommissionService
{
    private readonly ICountryRepository _repository;
    private readonly List<CommissionResult> _history = new();

    private static readonly string[] _months = {
        "", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
        "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
    };

    public CommissionService(ICountryRepository repository)
    {
        _repository = repository;
    }


    /// Calcula la comisión aplicando las reglas de negocio del país.
  
    public CommissionResult Calculate(CommissionRequest request)
    {
        var country = _repository.GetByCode(request.CountryCode)
            ?? throw new ArgumentException($"País no encontrado: {request.CountryCode}");

        // Regla de negocio: ventas netas = ventas - descuentos (mínimo 0)
        var netSales = Math.Max(0, request.TotalSales - request.Discounts);

        // Comisión base según tasa del país
        var commission = netSales * country.CommissionRate;

        // Bonificación por alto rendimiento
        var hasBonus = netSales >= country.BonusThreshold && country.BonusRate > 0;
        var bonusAmount = hasBonus ? netSales * country.BonusRate : 0;

        // Tier basado en ventas netas
        var tier = netSales switch
        {
            >= 100000m => "Platinum",
            >= 50000m => "Gold",
            >= 20000m => "Silver",
            _ => "Standard"
        };

        var totalEarnings = commission + bonusAmount;
        var period = $"{_months[request.Month]} {request.Year}";

        var result = new CommissionResult
        {
            VendorName = request.VendorName,
            CountryName = country.Name,
            CountryCode = country.Code,
            CountryFlag = country.Flag,
            CurrencySymbol = country.CurrencySymbol,
            TotalSales = request.TotalSales,
            Discounts = request.Discounts,
            NetSales = netSales,
            CommissionRate = country.CommissionRate,
            CommissionAmount = commission,
            BonusAmount = bonusAmount,
            TotalEarnings = totalEarnings,
            Period = period,
            HasBonus = hasBonus,
            Tier = tier,
            CalculatedAt = DateTime.Now
        };

        _history.Insert(0, result);
        return result;
    }

    public List<CommissionResult> GetHistory() => _history.ToList();

    public void ClearHistory() => _history.Clear();

    public DashboardStats GetDashboardStats()
    {
        if (!_history.Any())
            return new DashboardStats();

        var byCountry = _history
            .GroupBy(h => h.CountryName)
            .Select(g => new CountryStats
            {
                CountryName = g.Key,
                CountryFlag = g.First().CountryFlag,
                Calculations = g.Count(),
                TotalCommissions = g.Sum(x => x.TotalEarnings),
                TotalSales = g.Sum(x => x.TotalSales)
            })
            .OrderByDescending(x => x.TotalCommissions)
            .ToList();

        var byMonth = _history
            .GroupBy(h => h.Period)
            .Select(g => new MonthlyStats
            {
                Month = g.Key,
                Calculations = g.Count(),
                TotalCommissions = g.Sum(x => x.TotalEarnings)
            })
            .ToList();

        var topVendor = _history
            .GroupBy(h => h.VendorName)
            .OrderByDescending(g => g.Sum(x => x.TotalEarnings))
            .FirstOrDefault();

        return new DashboardStats
        {
            TotalCalculations = _history.Count,
            TotalCommissionsPaid = _history.Sum(x => x.TotalEarnings),
            TotalSalesVolume = _history.Sum(x => x.TotalSales),
            AverageCommission = _history.Average(x => x.TotalEarnings),
            TopCountry = byCountry.FirstOrDefault()?.CountryName ?? "N/A",
            TopVendor = topVendor?.Key ?? "N/A",
            TopVendorEarnings = topVendor?.Sum(x => x.TotalEarnings) ?? 0,
            ByCountry = byCountry,
            ByMonth = byMonth
        };
    }
}
