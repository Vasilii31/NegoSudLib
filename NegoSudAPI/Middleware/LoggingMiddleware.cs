namespace AirFranceAPI.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate next;
    public LoggingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext httpcontext, ILogger<LoggingMiddleware> logger)
    {
        logger.LogDebug("Received request {RequestPath}", httpcontext.Request.Path);

        try
        {
            await next(httpcontext);

            logger.LogDebug("Completed request {RequestPath}", httpcontext.Request.Path);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while processing request {RequestPath}", httpcontext.Request.Path);
            httpcontext.Response.StatusCode = 400;
            await httpcontext.Response.WriteAsync("Une erreur est survenue, si cela persiste merci de contacter Olivier Franco");
        }
    }
}