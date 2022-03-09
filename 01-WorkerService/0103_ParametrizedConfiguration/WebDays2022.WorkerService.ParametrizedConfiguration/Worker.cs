public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    public readonly IFeatureManager featureManager;

    public Worker(ILogger<Worker> logger,
                  IFeatureManager featureManager)
    {
        this.featureManager = featureManager;
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var logMsg = "Worker running";
            logMsg += await featureManager.IsEnabledAsync(nameof(FeatureFlags.LogTime))
                ? $" at: {DateTimeOffset.Now}"
                : "";

            logger.LogInformation(logMsg);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
