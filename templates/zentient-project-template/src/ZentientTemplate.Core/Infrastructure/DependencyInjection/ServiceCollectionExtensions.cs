using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zentient.Abstractions.DependencyInjection;
using ZentientTemplate.Core.Services.Interfaces;
using ZentientTemplate.Core.Services.Implementations;
using ZentientTemplate.Core.Infrastructure.Configuration;
using ZentientTemplate.Core.Infrastructure.Caching;
using ZentientTemplate.Core.Infrastructure.Validation;

namespace ZentientTemplate.Core.Infrastructure.DependencyInjection;

/// <summary>
/// Extension methods for configuring Core services in the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all Core services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddCoreServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add configuration services
        services.AddCoreConfiguration(configuration);
        
        // Add caching services
        services.AddCoreCaching(configuration);
        
        // Add validation services
        services.AddCoreValidation();
        
        // Add application services
        services.AddApplicationServices();
        
        // Add infrastructure services
        services.AddInfrastructureServices(configuration);
        
        return services;
    }

    /// <summary>
    /// Adds application services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register application services with their interfaces
        services.AddScoped<IExampleService, ExampleService>();
        
        // Add AutoMapper
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        
        return services;
    }

    /// <summary>
    /// Adds infrastructure services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The service collection for chaining.</returns>
    private static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add Entity Framework if enabled
        #if UseEntityFramework
        services.AddEntityFramework(configuration);
        #endif
        
        // Add Redis caching if enabled
        #if UseRedisCache
        services.AddRedisCache(configuration);
        #endif
        
        return services;
    }

#if UseEntityFramework
    /// <summary>
    /// Adds Entity Framework services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The service collection for chaining.</returns>
    private static IServiceCollection AddEntityFramework(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("DefaultConnection connection string is required.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
#endif

#if UseRedisCache
    /// <summary>
    /// Adds Redis caching services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The service collection for chaining.</returns>
    private static IServiceCollection AddRedisCache(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var redisConnectionString = configuration.GetConnectionString("Redis")
            ?? throw new InvalidOperationException("Redis connection string is required.");

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString;
        });

        return services;
    }
#endif
}
