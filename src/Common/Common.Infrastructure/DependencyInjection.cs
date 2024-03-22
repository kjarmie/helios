using Common.Application.Abstractions.Behaviours;
using Common.Application.Abstractions.Caching;
using Common.Infrastructure.Caching;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services)
    {
        services.AddMemoryCache();

        services.AddSingleton<ICacheService, CacheService>();

        return services;
    }
}