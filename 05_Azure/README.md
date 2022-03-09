# 05 - Manage Feature Flag in Azure App Configuration
- Creazione webapp `dotnet new webapp -n WebDays2022.WebApp.WebAppCompleteForAzure`
- Aggiunta packages 
  - `dotnet add package Microsoft.FeatureManagement.AspNetCore`
  - `dotnet add package Microsoft.Azure.AppConfiguration.AspNetCore`
  - `dotnet add package Microsoft.Extensions.Configuration.AzureAppConfiguration`
  - `dotnet add package UAParser`
- Salvataggio della configurazione negli user-secrets
  - `dotnet user-secrets init` (aggiunge nel file csproj `<UserSecretsId>dfa86f47-f732-453c-a3a5-1a9f4585d5cf</UserSecretsId>`)
  - `dotnet user-secrets set ConnectionStrings:AppConfig "<your_connection_string>"`
- Avvio applicazione `dotnet run`

## Demo
- L'applicazione ha 3 feature flags:
- ```
  "FeatureManagement": {
	
    "ShowTime": false,
    
    "ShowTimeAvailability": {
      "EnabledFor": [
      {
        "Name": "Microsoft.TimeWindow",
        "Parameters": {
          "Start": "2022-02-28T06:00:00+00:00",
          "End": "2022-02-28T20:00:00+00:00"
        }
      }]
    },
	
    "ShowTimeBrowsersAllowed": {
      "EnabledFor": [
        {
          "Name": "BrowsersFilter",
          "Parameters": {
            "Browsers": [ "Chrome" ]
          }
        }
      ]
    }    
  }
  ```
  e sono configurati in `Azure App Configuration`.
- Nel `Program.cs` c'è
    - il recupero della stringa di connessione dai secrets
    - il collegamento ad `Azure App Configuration`
    - la registrazione dei servizio per gestire 
        - Feature Flags
        - Azure App Configuration
- In `appsettings.json` non c'è niente perchè la configurazione è su Azure
- Modificando il valore degli stati su `Azure App Configuration` appare o scompare la data nella Home page 