namespace Webapp.Middleware;

public class GlobalErrorHandlingMiddleware : Middleware
{
    private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

    public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger) : base(next)
    {
        _logger = logger;
    }

    public override async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        }
    }
}