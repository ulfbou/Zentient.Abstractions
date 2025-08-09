using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using FluentValidation;
using ZentientTemplate.Core.Configuration.Options;

namespace ZentientTemplate.Core.Infrastructure.Configuration;

/// <summary>
/// Extension methods for configuring application configuration services.
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Adds configuration services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddCoreConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configure and validate options
        services.Configure<ApplicationOptions>(configuration.GetSection(ApplicationOptions.SectionName));
        services.Configure<CacheOptions>(configuration.GetSection(CacheOptions.SectionName));
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
        
        // Add options validation
        services.AddSingleton<IValidateOptions<ApplicationOptions>, ApplicationOptionsValidator>();
        services.AddSingleton<IValidateOptions<CacheOptions>, CacheOptionsValidator>();
        services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();
        
        // Add strongly-typed configuration accessors
        services.AddSingleton(provider => 
            provider.GetRequiredService<IOptions<ApplicationOptions>>().Value);
        services.AddSingleton(provider => 
            provider.GetRequiredService<IOptions<CacheOptions>>().Value);
        services.AddSingleton(provider => 
            provider.GetRequiredService<IOptions<DatabaseOptions>>().Value);
        
        return services;
    }
}
