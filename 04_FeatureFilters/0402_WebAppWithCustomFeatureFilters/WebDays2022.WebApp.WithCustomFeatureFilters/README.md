# 0402 - Custom Feature Filter

- Creazione il worker service `dotnet new webapp -n WebDays2022.WebApp.WithCustomFeatureFilters`
- Aggiunta package `dotnet add package Microsoft.FeatureManagement.AspNetCore`
- Avvio applicazione `dotnet run`

## Demo
- Il file `BrowsersFeatureFilterSettings.cs` è la classe che definisce la configurazione del feature filter. In base a questa configurazione avremo la valorizzazione all'interno del `appsettings.json`
- La classe `BrowsersFeatureFilter.cs` contiene la logica che verrà applicata dal feature filter
- Nel file  `_ViewImports.cshtml` è stato inserito il tag helper `@addTagHelper *, Microsoft.FeatureManagement.AspNetCore`
- Nella pagina `_Layout.cshtml` abbiamo il tag `<feature..>` che discrimina l'inserimento dell'HTML in base alla logica applicata dal feature filter
- Accedendo da Chrome la feature sarà visibile, mentre da Edge (o altro browser) no