using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CommissionCalculator;
using CommissionCalculator.Services;
using CommissionCalculator.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Capa de Dts
builder.Services.AddSingleton<ICountryRepository, CountryRepository>();

// capa de Lógica de Negocio 
builder.Services.AddSingleton<ICommissionService, CommissionService>();
builder.Services.AddSingleton<IAuthService, AuthService>();

// Capa de Presentación 
builder.Services.AddSingleton<ToastService>();

await builder.Build().RunAsync();
