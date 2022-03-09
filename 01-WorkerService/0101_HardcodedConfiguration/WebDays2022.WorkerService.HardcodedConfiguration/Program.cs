// *** HARDCODED FEATURE FLAGS CONFIGURATION ***
var flags = new Dictionary<string, string>
    {
        { $"FeatureManagement:LogTime", "False"}
    };
// *********************************************

IConfigurationBuilder builder = new ConfigurationBuilder();
builder.AddInMemoryCollection(flags);
IConfigurationRoot configuration = builder.Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddFeatureManagement(configuration);   // <=== REGISTRIAMO IL SERVIZIO
    })
    .Build();

await host.RunAsync();
