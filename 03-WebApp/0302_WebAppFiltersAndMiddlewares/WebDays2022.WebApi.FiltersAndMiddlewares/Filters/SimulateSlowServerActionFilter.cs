using Microsoft.AspNetCore.Mvc.Filters;

public class SimulateSlowServerActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        await Task.Delay(5000);

        await next();
    }
}