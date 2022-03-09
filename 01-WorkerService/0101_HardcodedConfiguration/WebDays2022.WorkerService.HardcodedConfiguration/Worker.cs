public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    private readonly IFeatureManager featureManager;

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

            // *** TOGGLE ROUTER ***
            if(await featureManager.IsEnabledAsync("LogTime"))
                logMsg += $" at: {DateTimeOffset.Now}";
            // *********************

            logger.LogInformation(logMsg);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
