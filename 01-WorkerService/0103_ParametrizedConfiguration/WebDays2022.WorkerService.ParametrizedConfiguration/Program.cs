// *** RETRIEVE FEATURE FLAGS CONFIGURATION FROM COMMAND LINE ARGS***
string[] arguments = Environment.GetCommandLineArgs();

var logTimeArg = arguments.FirstOrDefault(a => a.StartsWith(nameof(FeatureFlags.LogTime)))?.Split("=")[1] ?? "False";
Console.WriteLine($"LogTime={logTimeArg}");

var flags = new Dictionary<string, string>
    {
        { $"FeatureManagement:{nameof(FeatureFlags.LogTime)}", logTimeArg}
    };
// ******************************************************************

IConfigurationBuilder builder = new ConfigurationBuilder();
builder.AddInMemoryCollection(flags);
IConfigurationRoot configuration = builder.Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddFeatureManagement(configuration);      // <=== REGISTRIAMO IL SERVIZIO
    })
    .Build();

await host.RunAsync();
