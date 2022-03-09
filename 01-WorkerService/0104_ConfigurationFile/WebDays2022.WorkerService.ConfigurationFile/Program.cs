IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddFeatureManagement();   // <=== REGISTRIAMO IL SERVIZIO (senza specificare la configurazione)
    })
    .Build();

await host.RunAsync();
