# 0401 - Targeting Feature Flag
- Creazione il worker service `dotnet new webapp --auth Individual -o WebDays2022.WebApp.WithFeatureFilters`
- Aggiunta package `dotnet add package Microsoft.FeatureManagement.AspNetCore`
- Avvio applicazione `dotnet run`

## Demo
- Nel file `Program.cs` si registrano 
  - il feature filter `.AddFeatureFilter<TargetingFilter>();`
  - la logica per discriminare utente o gruppo `.AddSingleton<ITargetingContextAccessor, TestTargetingContextAccessor>();`
- Nel file `appsettings.json` viene valorizzata la configurazione
- Il file `TestTargetingContextAccessor.cs` contiene la logica
- Nel file  `_ViewImports.cshtml` è stato inserito il tag helper `@addTagHelper *, Microsoft.FeatureManagement.AspNetCore`
- Nella pagina `_Layout.cshtml` abbiamo il tag `<feature..>` che discrimina la visualizzazione del link alla pagina Gianni in base alla logica applicata dal feature filter
- Accedendo come
  - `gianni.bossini@codiceplastico.com` nel menù viene mostrato il link alla pagina
  - `collega@codiceplastico.com` nel menù viene NON mostrato il link alla pagina
  - la password per entrambi gli utenti è `WebDays2022_`