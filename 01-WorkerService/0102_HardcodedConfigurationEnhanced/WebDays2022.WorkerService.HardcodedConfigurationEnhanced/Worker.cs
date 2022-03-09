public class Worker : BackgroundService
{
    private readonly IMyLogger<Worker> logger;

    public Worker(IMyLogger<Worker> logger)
    {
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running");
            await Task.Delay(1000, stoppingToken);
        }
    }
}
