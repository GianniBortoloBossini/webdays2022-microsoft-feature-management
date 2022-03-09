using Microsoft.FeatureManagement;
using UAParser;

[FilterAlias("BrowsersFilter")]
public class BrowsersFeatureFilter : IFeatureFilter
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public BrowsersFeatureFilter(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
    {
        var userAgent = httpContextAccessor.HttpContext.Request.Headers["User-Agent"];

        var uaParser = Parser.GetDefault();
        var clientInfo = uaParser.Parse(userAgent);

        BrowsersFeatureFilterSettings settings = context.Parameters.Get<BrowsersFeatureFilterSettings>();
        foreach(var browser in settings.Browsers)
            if(clientInfo.UA.Family.Contains(browser, StringComparison.InvariantCultureIgnoreCase))
                return Task.FromResult(true);
        return Task.FromResult(false);
    }
}