# 0302 - Web api with conditional filter and middleware

## Setup
- Creazione il worker service `dotnet new webapi -n WebDays2022.WorkerService.HardcodedConfiguration`
- Aggiunta package `dotnet add package Microsoft.FeatureManagement.AspNetCore`
- Avvio applicazione `dotnet run`

## Demo
- Nel file `GlobalUsings.cs` sono state inserite le dipendene della libreria `Microsoft.FeatureManagement.AspNetCore` che verranno utilizzare nel progetto
- Nel `Program.cs` si registra la dipendenza dal flag
  -  `SimulateSlowServer` del filtro `SimulateSlowServerActionFilter`
  -  `LogRequests` del middleware  `LogRequestsMiddleware`
  - registra il servizio specificando la configurazione `services.AddFeatureManagement(configuration);`
- Con la chiamata `curl https://localhost:7042/WeatherForecast` vedremo che in base allo stato del feature flag
  - `SimulateSlowServer` la chiamata avrà uno sleep che la rende lenta
  - `LogRequests` vedremo le loggate dell'endpoint chiamato