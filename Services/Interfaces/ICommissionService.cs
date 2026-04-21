using CommissionCalculator.Models.Requests;
using CommissionCalculator.Models.Responses;

namespace CommissionCalculator.Services.Interfaces;

/// Interfaz del servicio de comisiones
/// Capa: Lógica de Negocio — Define el contrato para calculos de comisiiion

public interface ICommissionService
{
    CommissionResult Calculate(CommissionRequest request);
    List<CommissionResult> GetHistory();
    void ClearHistory();
    DashboardStats GetDashboardStats();
}
