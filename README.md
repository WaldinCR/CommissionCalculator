# CommissionCalc — Calculadora de Comisiones de Ventas

Aplicación web desarrollada en **Blazor WebAssembly (.NET 8)** que permite a vendedores calcular de forma rápida la comisión que recibirán en función de sus ventas mensuales y el país en el que operan.

## Arquitectura

El proyecto implementa una **arquitectura en capas** con separación clara de responsabilidades:

```
CommissionCalculator/
├── Models/                          # Capa de Dominio
│   ├── Country.cs                   # Entidad País
│   ├── Vendor.cs                    # Entidad Vendedor
│   ├── Requests/                    # DTOs de entrada
│   │   ├── CommissionRequest.cs     # Solicitud de cálculo
│   │   └── LoginRequest.cs          # Solicitud de login
│   └── Responses/                   # DTOs de salida
│       ├── CommissionResult.cs      # Resultado de comisión
│       └── DashboardStats.cs        # Métricas del dashboard
├── Services/                        # Capa de Lógica de Negocio + Datos
│   ├── Interfaces/                  # Contratos (abstracciones)
│   │   ├── ICountryRepository.cs    # Repositorio de países
│   │   ├── ICommissionService.cs    # Servicio de comisiones
│   │   └── IAuthService.cs          # Servicio de autenticación
│   ├── CountryRepository.cs         # Implementación datos (Capa Datos)
│   ├── CommissionService.cs         # Implementación lógica (Capa Negocio)
│   ├── AuthService.cs               # Implementación auth (Capa Negocio)
│   └── ToastService.cs              # Servicio de notificaciones (Capa UI)
├── Layout/                          # Capa de Presentación - Layout
│   └── MainLayout.razor             # Layout principal con navegación
├── Shared/                          # Componentes reutilizables
│   └── ToastContainer.razor         # Componente de notificaciones
├── Pages/                           # Capa de Presentación - Páginas
│   ├── Index.razor                  # Calculadora principal
│   ├── Historial.razor              # Historial de cálculos
│   ├── Login.razor                  # Inicio de sesión
│   └── Admin/
│       ├── Dashboard.razor          # Dashboard administrativo
│       └── Paises.razor             # CRUD de países
└── Program.cs                       # Composición raíz (DI)
```

### Capas del Sistema

| Capa | Componentes | Responsabilidad |
|------|-------------|-----------------|
| **Presentación** | Pages/, Layout/, Shared/ | UI, formularios, navegación |
| **Lógica de Negocio** | CommissionService, AuthService | Reglas de cálculo, autenticación |
| **Datos** | CountryRepository | Acceso y persistencia de datos |

## Reglas de Negocio

- **Fórmula base**: `Comisión = (Ventas Totales - Descuentos) × Tasa del País`
- **Bonificación**: Si las ventas netas superan el umbral del país, se aplica una tasa bonus adicional
- **Tiers**: Standard, Silver (≥$20K), Gold (≥$50K), Platinum (≥$100K)

### Tasas por País

| País | Tasa Base | Tasa Bonus | Umbral Bonus |
|------|-----------|------------|--------------|
| India 🇮🇳 | 10% | +2% | ₹100,000 |
| Estados Unidos 🇺🇸 | 15% | +3% | $50,000 |
| Reino Unido 🇬🇧 | 12% | +2.5% | £40,000 |
| Alemania 🇩🇪 | 11% | +2% | €45,000 |
| México 🇲🇽 | 13% | +3% | $500,000 |
| Rep. Dominicana 🇩🇴 | 14% | +3.5% | RD$300,000 |

## Funcionalidades

- **Calculadora de comisiones** con formulario validado
- **Sistema de autenticación** con roles (Admin/Vendedor)
- **Historial de cálculos** persistente en sesión
- **Dashboard administrativo** con métricas y estadísticas
- **CRUD de países** (agregar, editar, eliminar)
- **Notificaciones toast** con feedback visual
- **Sistema de tiers** y bonificaciones por rendimiento
- **Diseño glassmorphism** responsive

## Patrones de Diseño Aplicados

- **Dependency Injection** — Inyección de dependencias vía `Program.cs`
- **Repository Pattern** — `ICountryRepository` abstrae el acceso a datos
- **Service Layer** — `ICommissionService` encapsula la lógica de negocio
- **Observer Pattern** — `ToastService` y `AuthService` con eventos
- **DTO Pattern** — Requests y Responses separan contratos de comunicación
- **Interface Segregation** — Interfaces específicas por responsabilidad

## Requisitos

- .NET 8 SDK
- Navegador moderno con soporte WebAssembly

## Ejecución

```bash
dotnet restore
dotnet run
```

La aplicación estará disponible en `http://localhost:5299`

### Credenciales de Prueba

| Rol | Correo | Contraseña |
|-----|--------|------------|
| Admin | admin@comisiones.com | 
| Vendedor | vendedor@comisiones.com |

## Tecnologías

- Blazor WebAssembly (.NET 8)
- C# 12
- CSS3 (Glassmorphism, CSS Variables, Grid, Flexbox)
- Bootstrap Icons
- Google Fonts (DM Sans, Space Mono)
