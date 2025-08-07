// <copyright file="ConfigurationScope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Zentient.Abstractions.Configuration
{
    /// <summary>
    /// Defines the scope levels for configuration values and settings.
    /// </summary>
    /// <remarks>
    /// Configuration scopes determine the hierarchy and precedence of configuration values,
    /// enabling sophisticated configuration inheritance and override patterns.
    /// </remarks>
    public enum ConfigurationScope
    {
        /// <summary>
        /// Global configuration scope.
        /// Applies to all environments, applications, and services.
        /// Lowest precedence in the configuration hierarchy.
        /// </summary>
        [Description("Global configuration for all environments")]
        Global = 0,

        /// <summary>
        /// Environment-specific configuration scope.
        /// Applies to a specific environment (e.g., Development, Staging, Production).
        /// Overrides global settings for the specific environment.
        /// </summary>
        [Description("Environment-specific configuration")]
        Environment = 1,

        /// <summary>
        /// Application-specific configuration scope.
        /// Applies to a specific application within an environment.
        /// Overrides environment and global settings for the specific application.
        /// </summary>
        [Description("Application-specific configuration")]
        Application = 2,

        /// <summary>
        /// Service-specific configuration scope.
        /// Applies to a specific service within an application.
        /// Overrides application, environment, and global settings for the specific service.
        /// </summary>
        [Description("Service-specific configuration")]
        Service = 3,

        /// <summary>
        /// User-specific configuration scope.
        /// Applies to a specific user or user group.
        /// Provides personalized configuration overrides.
        /// </summary>
        [Description("User-specific configuration")]
        User = 4,

        /// <summary>
        /// Tenant-specific configuration scope.
        /// Applies to a specific tenant in multi-tenant applications.
        /// Provides tenant-isolated configuration overrides.
        /// </summary>
        [Description("Tenant-specific configuration")]
        Tenant = 5,

        /// <summary>
        /// Request-specific configuration scope.
        /// Applies to a specific request or operation context.
        /// Highest precedence - overrides all other configuration scopes.
        /// </summary>
        [Description("Request-specific configuration")]
        Request = 6
    }

    /// <summary>
    /// Provides extension methods for working with ConfigurationScope values.
    /// </summary>
    public static class ConfigurationScopeExtensions
    {
        /// <summary>
        /// Gets the precedence order for configuration scope resolution.
        /// </summary>
        /// <param name="scope">The configuration scope.</param>
        /// <returns>The precedence value (higher numbers have higher precedence).</returns>
        public static int GetPrecedence(this ConfigurationScope scope)
        {
            return (int)scope;
        }

        /// <summary>
        /// Determines whether this scope has higher precedence than another scope.
        /// </summary>
        /// <param name="scope">The configuration scope to check.</param>
        /// <param name="otherScope">The scope to compare against.</param>
        /// <returns>True if this scope has higher precedence; otherwise, false.</returns>
        public static bool HasHigherPrecedenceThan(this ConfigurationScope scope, ConfigurationScope otherScope)
        {
            return scope.GetPrecedence() > otherScope.GetPrecedence();
        }

        /// <summary>
        /// Determines whether this scope is a context-specific scope.
        /// </summary>
        /// <param name="scope">The configuration scope to check.</param>
        /// <returns>True if the scope is User, Tenant, or Request; otherwise, false.</returns>
        public static bool IsContextSpecific(this ConfigurationScope scope)
        {
            return scope is ConfigurationScope.User or ConfigurationScope.Tenant or ConfigurationScope.Request;
        }

        /// <summary>
        /// Determines whether this scope is an infrastructure scope.
        /// </summary>
        /// <param name="scope">The configuration scope to check.</param>
        /// <returns>True if the scope is Global, Environment, Application, or Service; otherwise, false.</returns>
        public static bool IsInfrastructureScope(this ConfigurationScope scope)
        {
            return scope is ConfigurationScope.Global or ConfigurationScope.Environment or 
                   ConfigurationScope.Application or ConfigurationScope.Service;
        }

        /// <summary>
        /// Gets the cache duration appropriate for this configuration scope.
        /// </summary>
        /// <param name="scope">The configuration scope.</param>
        /// <returns>The recommended cache duration for this scope.</returns>
        public static TimeSpan GetCacheDuration(this ConfigurationScope scope)
        {
            return scope switch
            {
                ConfigurationScope.Global => TimeSpan.FromHours(24),
                ConfigurationScope.Environment => TimeSpan.FromHours(12),
                ConfigurationScope.Application => TimeSpan.FromHours(6),
                ConfigurationScope.Service => TimeSpan.FromHours(2),
                ConfigurationScope.User => TimeSpan.FromHours(1),
                ConfigurationScope.Tenant => TimeSpan.FromMinutes(30),
                ConfigurationScope.Request => TimeSpan.Zero, // No caching for request scope
                _ => TimeSpan.FromHours(1)
            };
        }

        /// <summary>
        /// Gets all scopes that this scope should inherit from.
        /// </summary>
        /// <param name="scope">The configuration scope.</param>
        /// <returns>An enumerable of scopes in inheritance order (lowest to highest precedence).</returns>
        public static IEnumerable<ConfigurationScope> GetInheritanceChain(this ConfigurationScope scope)
        {
            var scopes = new List<ConfigurationScope>();
            
            // Add all lower precedence scopes
            for (int i = 0; i < (int)scope; i++)
            {
                scopes.Add((ConfigurationScope)i);
            }
            
            // Add the current scope
            scopes.Add(scope);
            
            return scopes;
        }
    }
}
