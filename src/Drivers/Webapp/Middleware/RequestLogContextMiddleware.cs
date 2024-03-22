using Serilog.Context;

namespace Webapp.Middleware;

public class RequestLogContextMiddleware : Middleware
{
    public RequestLogContextMiddleware(RequestDelegate next) : base(next)
    {
    }

    public override Task InvokeAsync(HttpContext context)
    {
        using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
        {
            return _next(context);
        }
    }
}