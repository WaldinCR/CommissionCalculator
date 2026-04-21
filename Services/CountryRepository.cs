using CommissionCalculator.Models;
using CommissionCalculator.Services.Interfaces;

namespace CommissionCalculator.Services;

/// Implementación del repositorio de países
/// Capa: Datos — Almacena y gestiona los datos de países con tasas de comisión
/// Usa almacenamiento en memoria (simulando base de datos)

public class CountryRepository : ICountryRepository
{
    private readonly List<Country> _countries = new()
    {
        new Country
        {
            Code = "IN", Name = "India", Flag = "🇮🇳",
            Currency = "INR", CurrencySymbol = "₹",
            CommissionRate = 0.10m,
            BonusRate = 0.02m, BonusThreshold = 100000m
        },
        new Country
        {
            Code = "US", Name = "Estados Unidos", Flag = "🇺🇸",
            Currency = "USD", CurrencySymbol = "$",
            CommissionRate = 0.15m,
            BonusRate = 0.03m, BonusThreshold = 50000m
        },
        new Country
        {
            Code = "UK", Name = "Reino Unido", Flag = "🇬🇧",
            Currency = "GBP", CurrencySymbol = "£",
            CommissionRate = 0.12m,
            BonusRate = 0.025m, BonusThreshold = 40000m
        },
        new Country
        {
            Code = "DE", Name = "Alemania", Flag = "🇩🇪",
            Currency = "EUR", CurrencySymbol = "€",
            CommissionRate = 0.11m,
            BonusRate = 0.02m, BonusThreshold = 45000m
        },
        new Country
        {
            Code = "MX", Name = "México", Flag = "🇲🇽",
            Currency = "MXN", CurrencySymbol = "$",
            CommissionRate = 0.13m,
            BonusRate = 0.03m, BonusThreshold = 500000m
        },
        new Country
        {
            Code = "DO", Name = "República Dominicana", Flag = "🇩🇴",
            Currency = "DOP", CurrencySymbol = "RD$",
            CommissionRate = 0.14m,
            BonusRate = 0.035m, BonusThreshold = 300000m
        }
    };

    public List<Country> GetAll() => _countries.ToList();

    public Country? GetByCode(string code) =>
        _countries.FirstOrDefault(c => c.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

    public void Add(Country country)
    {
        if (_countries.Any(c => c.Code == country.Code))
            throw new InvalidOperationException($"El país con código '{country.Code}' ya existe.");
        _countries.Add(country);
    }

    public void Update(Country country)
    {
        var existing = GetByCode(country.Code);
        if (existing == null)
            throw new InvalidOperationException($"País no encontrado: {country.Code}");

        existing.Name = country.Name;
        existing.Flag = country.Flag;
        existing.Currency = country.Currency;
        existing.CurrencySymbol = country.CurrencySymbol;
        existing.CommissionRate = country.CommissionRate;
        existing.BonusRate = country.BonusRate;
        existing.BonusThreshold = country.BonusThreshold;
    }

    public bool Delete(string code)
    {
        var country = GetByCode(code);
        if (country == null) return false;
        return _countries.Remove(country);
    }
}
