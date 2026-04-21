using CommissionCalculator.Models;

namespace CommissionCalculator.Services.Interfaces;


/// Interfaz del repositorio de países
/// Capa: Datos — Define el contrato de acceso a datos de países

public interface ICountryRepository
{
    List<Country> GetAll();
    Country? GetByCode(string code);
    void Add(Country country);
    void Update(Country country);
    bool Delete(string code);
}
