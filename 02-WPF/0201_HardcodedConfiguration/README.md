# 0201 - WPF with in-memory feature flags

## Setup
- Creazione l'applicazione `WebDays2022.WPF.InMemory` con Visual Studio 2019
- Aggiunta package `dotnet add package Microsoft.FeatureManagement`
- Avvio applicazione `dotnet run`

## Demo
- Il file `App.xaml.cs` sostiuisce la configurazioni che, nelle deom precedenti, erano deputate al file  `Program.cs`
- La configurazione in memoria viene passata al servizio che gestisce i Feature Flag
- Nel code-behind della pagina `FeaturesPage.xaml.cs` viene aggiornata la configurazione
- Nel code-behind della pagina `MyPage.xaml.cs` è contenuto il toggle router che discrimina il comportamento da applicare