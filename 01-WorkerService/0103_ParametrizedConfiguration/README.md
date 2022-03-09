# 0103 - Worker service with feature flags definition from cli args

- Creazione il worker service `dotnet new worker -n WebDays2022.WorkerService.ParametrizedConfiguration`
- Aggiunta package `dotnet add package Microsoft.FeatureManagement`
- Avvio applicazione 
  - `dotnet run`: feature flag disabilitato
  - `dotnet run "LogTime=True"`: feature flag ABILITATO

## Demo
- Vale tutto quanto abbiamo detto per la demo `0101 - Worker service with in-memory feature flags`
- Configurazione recuperata dagli argomenti della CLI