using System.Text;

public class LogRequestsMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<LogRequestsMiddleware> logger;

    public LogRequestsMiddleware(RequestDelegate next, ILogger<LogRequestsMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation($"{context.Request.Method} - {context.Request.Path}");

        await next(context);
    }

    private async Task<string> ReadRequestBody(HttpRequest request)
    {
        HttpRequestRewindExtensions.EnableBuffering(request);

        var body = request.Body;
        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer, 0, buffer.Length);
        string requestBody = Encoding.UTF8.GetString(buffer);
        body.Seek(0, SeekOrigin.Begin);
        request.Body = body;

        return $"{requestBody}";
    }
}