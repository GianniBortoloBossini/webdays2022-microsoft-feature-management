public enum FeatureFlags
{
    LogTime
}

public interface IFeatureAwareFactory
{
    public Task<bool> IncludeTimestampIntoLogMesssages { get; }
}

public class FeatureAwareFactory : IFeatureAwareFactory
{
    private readonly IFeatureManager featureManager;

    public FeatureAwareFactory(IFeatureManager featureManager)
    {
        this.featureManager = featureManager;
    }

    public Task<bool> IncludeTimestampIntoLogMesssages => featureManager.IsEnabledAsync(nameof(FeatureFlags.LogTime));
}