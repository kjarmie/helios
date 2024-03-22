using Common.Application.Abstractions.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehaviour<,>));
            config.AddOpenBehavior(typeof(QueryCachingPipelineBehavior<,>));
        });

        return services;
    }
}