namespace CommissionCalculator.Services;

/// Servicio de notificaciones toast.
/// Capa: Presentación — Provee feedback visual al usuario.
/// Patrón Observer con evento OnChange.

public class ToastService
{
    public event Action<ToastMessage>? OnShow;

    public void Success(string message) =>
        OnShow?.Invoke(new ToastMessage("success", message, "bi-check-circle-fill"));

    public void Error(string message) =>
        OnShow?.Invoke(new ToastMessage("error", message, "bi-x-circle-fill"));

    public void Warning(string message) =>
        OnShow?.Invoke(new ToastMessage("warning", message, "bi-exclamation-triangle-fill"));

    public void Info(string message) =>
        OnShow?.Invoke(new ToastMessage("info", message, "bi-info-circle-fill"));
}

public record ToastMessage(string Type, string Message, string Icon);
