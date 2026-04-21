using System.ComponentModel.DataAnnotations;

namespace CommissionCalculator.Models.Requests;


/// DTO de solicitud para calcular comisins
/// Capa: Presentación → Lógica de Negocio

public class CommissionRequest
{
    [Required(ErrorMessage = "Debe seleccionar un país.")]
    public string CountryCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe ingresar el nombre del vendedor.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string VendorName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe ingresar las ventas totales.")]
    [Range(0.01, 99999999.99, ErrorMessage = "Las ventas deben ser entre $0.01 y $99,999,999.99.")]
    public decimal TotalSales { get; set; }

    [Required(ErrorMessage = "Debe ingresar los descuentos.")]
    [Range(0, 99999999.99, ErrorMessage = "Los descuentos no pueden ser negativos.")]
    public decimal Discounts { get; set; }

    [Required(ErrorMessage = "Debe seleccionar el mes.")]
    [Range(1, 12, ErrorMessage = "Mes inválido.")]
    public int Month { get; set; } = DateTime.Now.Month;

    [Required(ErrorMessage = "Debe seleccionar el año.")]
    [Range(2020, 2030, ErrorMessage = "Año inválido.")]
    public int Year { get; set; } = DateTime.Now.Year;
}
