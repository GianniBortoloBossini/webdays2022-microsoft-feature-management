# 0403 - Feature Flag State Management

- Creazione api `dotnet new webapi -n WebDays2022.Api.SessionManagement`
- Aggiunta package `dotnet add package Microsoft.FeatureManagement.AspNetCore`
- Avvio applicazione `dotnet run`

## Demo
- Configurazione del feature filter `Microsoft.Percentage` nell'`appsettings.json`
- Il filtro è configurato con una probabilità del 50%
- Nel `Program.cs` viene registrato il servizio ed il feature filter
- Il controllor `SlowController` contiene due rotte:
  - `\unsafe` contiene un ciclo di 10 iterazioni e utilizza `IFeatureManager`. Chiedendo ogni volta di applicare la logica del feature filter, nella response avremo valori diversi.
  Per provare eseguire effettuare la seguente chiamata: `curl https://localhost:7268/slow/unsafe`
  - `safe` contiene un ciclo di 10 iterazioni e utilizza `IFeatureManagerSnapshot`. In questo caso viene mantenuto lo stato all'interno della request.
  Per provare eseguire effettuare la seguente chiamata: `curl https://localhost:7268/slow/safe`