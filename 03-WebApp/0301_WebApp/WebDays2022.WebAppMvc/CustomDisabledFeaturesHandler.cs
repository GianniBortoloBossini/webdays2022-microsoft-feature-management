using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomDisabledFeaturesHandler : IDisabledFeaturesHandler
{
    public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
    {
        var message = $"<h1>Ops!</h1><p>Queste features non sono attualmente disponibili: {string.Join(',', features)}<p>";

        context.Result = new ContentResult()
        {
            ContentType = "text/html",
            Content = message,
            StatusCode = 404
        };

        return Task.CompletedTask;
    }
}