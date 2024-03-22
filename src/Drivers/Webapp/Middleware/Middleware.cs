namespace Webapp.Middleware;

public abstract class Middleware
{
    protected readonly RequestDelegate _next;

    protected Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public abstract Task InvokeAsync(HttpContext context);
}