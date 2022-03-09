// *** HARDCODED FEATURE FLAGS CONFIGURATION ***
var flags = new Dictionary<string, string>
    {
        { $"FeatureManagement:{nameof(FeatureFlags.LogTime)}", "False"}
    };
// *********************************************

IConfigurationBuilder builder = new ConfigurationBuilder();
builder.AddInMemoryCollection(flags);
IConfigurationRoot configuration = builder.Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddFeatureManagement(configuration);                           // <=== REGISTRIAMO IL SERVIZIO
        services.AddSingleton<IFeatureAwareFactory, FeatureAwareFactory>();     // <=== CLASSE PER GESTIONE LOGICHE TOGGLE
        services.AddSingleton<IMyLogger<Worker>, MyLogger<Worker>>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
