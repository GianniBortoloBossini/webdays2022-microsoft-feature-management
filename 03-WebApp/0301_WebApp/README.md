# 0301 - Web app with feature flags

## Setup
- Creazione il worker service `dotnet new webapi -n WebDays2022.WebAppMvc`
- Aggiunta package `dotnet add package Microsoft.FeatureManagement.AspNetCore`
- Avvio applicazione `dotnet run`

## Demo
- Nel file `GlobalUsings.cs` sono state inserite le dipendene della libreria `Microsoft.FeatureManagement.AspNetCore` che verranno utilizzare nel progetto
- I feature flags sono 3:
  - `NewWelcome`
  - `AboutPage`
  - `AboutPage_Details`
- Nel `HomeController.cs` abbiamo due utilizzi della libreria FeatureMangement:
  - nel metodo `Index` viene utilizzato il metodo `IsEnabledAsync` dell'interfaccia `IFeatureManager` per verificare puntualmente lo stato del flag `NewWelcome` e personalizzare la stringa di benvenuto
  -  il metodo `About` invece ha un `Feature gate` che consente di rendere attiva la action in base al feature flag `AboutPage`. Nel caso si volesse rendere attiva la pagina SOLO se entrambi i feature flag `AboutPage` e `AboutPage_Details` sono abilitati, si userà la configurazione `[FeatureGate(RequirementType.All, FeatureFlags.AboutPage, FeatureFlags.AboutPage_Details)]` in cui `RequirementType` può essere valorizzato a `All` oppure `Any`
  -  Cosa succede se il `Feature gate` non rende attiva la pagina `About`? Invocando la pagina (magari se ci siamo già dentro e premiamo F5) avremmo un 404. Per personalizzare la pagina di errore è possibile utilizzare e personalizzare la classe `CustomDisabledFeaturesHandler` (che implementa `IDisabledFeaturesHandler`) che risponderà nel caso le feature fossero disabilitate
-  A livello di interfaccia, per utilizzare i tag messi a disposizione dalla libreria `Microsoft.FeatureManagement.AspNetCore`, aggiungeremo nel file `_ViewImports.cshtml` il tag helper `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers`. Questi tag consentirà di implementare quello che si vede nelle pagine
  - `_Layout.cshtml`
  - `About.cshtml`
- Nella pagina `_Layout.cshtml` si vede l'uso del tag `feature` che attiva il codice HTML contenuto se il feature flag `AboutPage` è attivo (`<feature name="@nameof(FeatureFlags.AboutPage)"> ... </feature>`). Aggiungendo l'attibuto  `negate="true"` è possibile invertire l'attivazione, cioè abilitare il codice HTML se il feature flag è disabilitato.
- Nella pagina `About.cshtml` vediamo invece a livello di tag l'utilizzo dell'attributo `requirement` (l'analogo di `RequirementType` che abbiamo visto a livello di controller) il quale accetta `All` oppure `Any` per attivare la feature rispettivamente se tutti oppure un solo feature flag sono attivi.