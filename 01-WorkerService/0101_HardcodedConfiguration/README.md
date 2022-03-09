# 0101 - Worker service with in-memory feature flags

## Setup
- Creazione il worker service `dotnet new worker -n WebDays2022.WorkerService.HardcodedConfiguration`
- Aggiunta package `dotnet add package Microsoft.FeatureManagement`
- Avvio applicazione `dotnet run`

## Demo
- Nel file `GlobalUsings.cs` è stata inserita lo using alla libreria `Microsoft.FeatureManagement`
- Nel `Program.cs` si
  - definisce la configurazione dei feature flags
  - registra il servizio specificando la configurazione `services.AddFeatureManagement(configuration);`
- Nel file `Worker.cs` si inietta la dipendenza `IFeatureManager` che ci mette a disposizione il toggle router `await featureManager.IsEnabledAsync("LogTime")`
- Modificando il valore del flag nella configurazione all'interno del `Program.cs` arricchieremo i log con preziose informazioni relative allo state di esecuzione del nostro servizio