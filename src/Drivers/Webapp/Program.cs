using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    var services = builder.Services;
    var config = builder.Configuration;

    // Logging
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(config)
        .CreateLogger();

    Log.Information("Building application");

    builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

    // Routing
    services.AddRouting(options => { options.LowercaseUrls = true; });

    // App
    var app = builder.Build();

    // Logging
    app.UseSerilogRequestLogging(options =>
    {
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
        {
            diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
        };
        options.IncludeQueryInRequestPath = true;
    });

    app.MapGet("/", () => Results.Content(
        """
            <!DOCTYPE html>
            <html lang="en">
            <head>
                <meta charset="UTF-8">
                <link rel="icon" type="image/x-icon" href="favicon.svg">
                <title>Helios</title>
            </head>
            <body>
            Hello World!
            </body>
            </html>
        """, "text/html")
    );

    app.UseStaticFiles();

    app.UseHttpsRedirection();

    // Run application
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}