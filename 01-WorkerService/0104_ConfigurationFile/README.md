# 0104 - Worker service with feature flags definition from config file

- Creazione il worker service `dotnet new worker -n WebDays2022.WorkerService.ConfigurationFile`
- Aggiunta package `dotnet add package Microsoft.FeatureManagement`
- Avvio applicazione `dotnet run`

## Demo
- Vale tutto quanto abbiamo detto per la demo `0101 - Worker service with in-memory feature flags`
- Configurazione spostata nel file `appsettings.json`
- Nel `Program.cs` viene registrato il servizio
- Non serve più leggere la configurazione: la registrazione del servizio tramite `services.AddFeatureManagement();` recupera la configurazione dal file `appsettings.json`