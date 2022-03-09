public interface IMyLogger<T>
{
    Task LogInformation(string message);
}

public class MyLogger<T> : IMyLogger<T>
{
    private readonly ILogger<T> logger;
    private readonly IFeatureAwareFactory featureManager;

    public MyLogger(ILogger<T> logger, IFeatureAwareFactory featureManager)
    {
        this.logger = logger;
        this.featureManager = featureManager;
    }

    public async Task LogInformation(string message)
    { 
        // *** TOGGLE ROUTER ***
        if(await featureManager.IncludeTimestampIntoLogMesssages)
            message += $" at: {DateTimeOffset.Now}";
        // *********************

        logger.LogInformation(message);
    }
}