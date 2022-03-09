# 0102 - Worker service with enhanced in-memory feature flags

- Creazione il worker service `dotnet new worker -n WebDays2022.WorkerService.HardcodedConfigurationEnhanced`
- Aggiunta package `dotnet add package Microsoft.FeatureManagement`
- Avvio applicazione `dotnet run`

## Demo
- Vale tutto quanto abbiamo detto per la demo `0101 - Worker service with in-memory feature flags`
- Aggiungiamo i seguenti miglioramenti
  - Introduzione della classe `FeatureAwareFactory` che contiene tutta la conoscenza in merito alla gestione dei feature flags e toggle routers
  - Creare un metodo che contiene il feature flag permette di rendere più parlante il significato del flag
    (`IncludeTimestampIntoLogMesssages` vs `FeatureFlags.LogTime`)
  - I feature flags non sono più stringhe ma sono diventati un enumerativo e saranno referenziati in questo modo `nameof(FeatureFlags.LogTime)`: utilizzare un enumerativo agevola la rimozione perchè senza l'enumerativo non copilerà
  - La classe `Worker.cs` più leggibile perchè nascondo l'`if` nella classe `MyLogger.cs`