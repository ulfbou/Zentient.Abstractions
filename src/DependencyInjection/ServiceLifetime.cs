// <copyright file="ServiceLifetime.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Zentient.Abstractions.DependencyInjection
{
    /// <summary>Defines the possible lifetimes for a registered service.</summary>
    /// <remarks>
    /// Service lifetimes determine how instances are created, cached, and disposed of
    /// within the dependency injection container. The choice of lifetime affects both
    /// performance and memory usage characteristics of the application.
    /// </remarks>
    public enum ServiceLifetime
    {
        /// <summary>
        /// A new instance is created every time the service is requested.
        /// Ideal for lightweight, stateless services or those with mutable state
        /// that should not be shared.
        /// </summary>
        /// <remarks>
        /// Transient services have the lowest memory footprint but the highest
        /// instantiation cost. They are automatically disposed if they implement
        /// IDisposable when the scope that created them is disposed.
        /// </remarks>
        [Description("Creates a new instance every time the service is requested")]
        Transient = 0,

        /// <summary>
        /// A single instance is created per scope (e.g., per web request, or manually created
        /// scope). 
        /// Ideal for services that need to maintain state within a logical operation or
        /// rely on other scoped services.
        /// </summary>
        /// <remarks>
        /// Scoped services provide a balance between performance and isolation.
        /// They are automatically disposed when their scope is disposed.
        /// In web applications, this typically means one instance per HTTP request.
        /// </remarks>
        [Description("Creates one instance per scope (e.g., per HTTP request)")]
        Scoped = 1,

        /// <summary>
        /// A single instance is created for the entire application lifetime.
        /// Ideal for stateless utility services, expensive resources, or global coordination.
        /// </summary>
        /// <remarks>
        /// Singleton services have the highest performance for repeated access but
        /// must be thread-safe. They are only disposed when the application shuts down.
        /// Care must be taken to avoid capturing scoped dependencies.
        /// </remarks>
        [Description("Creates one instance for the entire application lifetime")]
        Singleton = 2,

        /// <summary>
        /// A single instance is created per thread.
        /// Ideal for services that maintain thread-specific state or resources.
        /// </summary>
        /// <remarks>
        /// Thread-local services provide isolation between threads without the overhead
        /// of creating new instances for each request. They are disposed when the
        /// thread terminates or the container is disposed.
        /// </remarks>
        [Description("Creates one instance per thread")]
        ThreadLocal = 3,

        /// <summary>
        /// Instances are pooled and reused to minimize allocation overhead.
        /// Ideal for expensive-to-create services that can be safely reused.
        /// </summary>
        /// <remarks>
        /// Pooled services provide excellent performance for high-throughput scenarios
        /// where service creation is expensive. Services must implement a reset mechanism
        /// to return to a clean state when returned to the pool.
        /// </remarks>
        [Description("Instances are pooled and reused to minimize allocations")]
        Pooled = 4
    }

    /// <summary>
    /// Provides extension methods and utilities for working with service lifetimes.
    /// </summary>
    public static class ServiceLifetimeExtensions
    {
        /// <summary>
        /// Gets a human-readable description of the service lifetime.
        /// </summary>
        /// <param name="lifetime">The service lifetime to describe.</param>
        /// <returns>A description of the service lifetime behavior.</returns>
        public static string GetDescription(this ServiceLifetime lifetime)
        {
            var field = typeof(ServiceLifetime).GetField(lifetime.ToString());
            if (field?.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return lifetime.ToString();
        }

        /// <summary>
        /// Determines if the service lifetime requires scope management.
        /// </summary>
        /// <param name="lifetime">The service lifetime to check.</param>
        /// <returns>True if the lifetime requires scope management; otherwise, false.</returns>
        public static bool RequiresScope(this ServiceLifetime lifetime)
        {
            return lifetime is ServiceLifetime.Scoped or ServiceLifetime.ThreadLocal;
        }

        /// <summary>
        /// Determines if the service lifetime supports caching.
        /// </summary>
        /// <param name="lifetime">The service lifetime to check.</param>
        /// <returns>True if the lifetime supports instance caching; otherwise, false.</returns>
        public static bool SupportsCaching(this ServiceLifetime lifetime)
        {
            return lifetime != ServiceLifetime.Transient;
        }

        /// <summary>
        /// Determines if the service lifetime requires thread safety.
        /// </summary>
        /// <param name="lifetime">The service lifetime to check.</param>
        /// <returns>True if the lifetime requires thread-safe implementations; otherwise, false.</returns>
        public static bool RequiresThreadSafety(this ServiceLifetime lifetime)
        {
            return lifetime is ServiceLifetime.Singleton or ServiceLifetime.Pooled;
        }

        /// <summary>
        /// Determines if the service lifetime allows multiple instances.
        /// </summary>
        /// <param name="lifetime">The service lifetime to check.</param>
        /// <returns>True if multiple instances can exist simultaneously; otherwise, false.</returns>
        public static bool AllowsMultipleInstances(this ServiceLifetime lifetime)
        {
            return lifetime is ServiceLifetime.Transient or ServiceLifetime.Pooled;
        }

        /// <summary>
        /// Gets the relative performance cost of the service lifetime.
        /// </summary>
        /// <param name="lifetime">The service lifetime to evaluate.</param>
        /// <returns>A value indicating the relative performance cost (lower is better).</returns>
        public static int GetPerformanceCost(this ServiceLifetime lifetime)
        {
            return lifetime switch
            {
                ServiceLifetime.Singleton => 1,
                ServiceLifetime.Scoped => 2,
                ServiceLifetime.ThreadLocal => 2,
                ServiceLifetime.Pooled => 3,
                ServiceLifetime.Transient => 4,
                _ => 5
            };
        }

        /// <summary>
        /// Gets the relative memory cost of the service lifetime.
        /// </summary>
        /// <param name="lifetime">The service lifetime to evaluate.</param>
        /// <returns>A value indicating the relative memory cost (lower is better).</returns>
        public static int GetMemoryCost(this ServiceLifetime lifetime)
        {
            return lifetime switch
            {
                ServiceLifetime.Transient => 1,
                ServiceLifetime.Scoped => 2,
                ServiceLifetime.ThreadLocal => 3,
                ServiceLifetime.Pooled => 4,
                ServiceLifetime.Singleton => 5,
                _ => 3
            };
        }

        /// <summary>
        /// Determines if one service lifetime is compatible with another for dependency injection.
        /// </summary>
        /// <param name="dependent">The lifetime of the service that depends on another.</param>
        /// <param name="dependency">The lifetime of the service being depended upon.</param>
        /// <returns>True if the lifetimes are compatible; otherwise, false.</returns>
        /// <remarks>
        /// Generally, a service can depend on services with equal or longer lifetimes.
        /// For example, a transient service can depend on scoped or singleton services,
        /// but a singleton service should not depend on scoped or transient services.
        /// </remarks>
        public static bool IsCompatibleWith(this ServiceLifetime dependent, ServiceLifetime dependency)
        {
            // Transient services can depend on any lifetime
            if (dependent == ServiceLifetime.Transient)
                return true;

            // Scoped services can depend on scoped, singleton, or thread-local services
            if (dependent == ServiceLifetime.Scoped)
                return dependency is ServiceLifetime.Scoped or ServiceLifetime.Singleton or ServiceLifetime.ThreadLocal;

            // Thread-local services can depend on thread-local or singleton services
            if (dependent == ServiceLifetime.ThreadLocal)
                return dependency is ServiceLifetime.ThreadLocal or ServiceLifetime.Singleton;

            // Pooled services can depend on singleton services or other pooled services
            if (dependent == ServiceLifetime.Pooled)
                return dependency is ServiceLifetime.Pooled or ServiceLifetime.Singleton;

            // Singleton services should only depend on other singleton services
            if (dependent == ServiceLifetime.Singleton)
                return dependency == ServiceLifetime.Singleton;

            return false;
        }

        /// <summary>
        /// Gets the recommended service lifetime based on usage patterns.
        /// </summary>
        /// <param name="isStateless">Whether the service is stateless.</param>
        /// <param name="isExpensiveToCreate">Whether the service is expensive to create.</param>
        /// <param name="isThreadSafe">Whether the service is thread-safe.</param>
        /// <param name="isHighFrequency">Whether the service is accessed frequently.</param>
        /// <returns>The recommended service lifetime.</returns>
        public static ServiceLifetime GetRecommendedLifetime(
            bool isStateless,
            bool isExpensiveToCreate,
            bool isThreadSafe,
            bool isHighFrequency)
        {
            // If it's expensive to create and thread-safe, prefer singleton
            if (isExpensiveToCreate && isThreadSafe)
                return ServiceLifetime.Singleton;

            // If it's expensive to create but not thread-safe, use scoped
            if (isExpensiveToCreate && !isThreadSafe)
                return ServiceLifetime.Scoped;

            // If it's high frequency and thread-safe, consider pooling
            if (isHighFrequency && isThreadSafe && !isStateless)
                return ServiceLifetime.Pooled;

            // If it's high frequency and stateless, use singleton
            if (isHighFrequency && isStateless && isThreadSafe)
                return ServiceLifetime.Singleton;

            // Default to transient for simple, stateless services
            if (isStateless)
                return ServiceLifetime.Transient;

            // Default to scoped for stateful services
            return ServiceLifetime.Scoped;
        }
    }

    /// <summary>
    /// Provides metadata about service lifetime characteristics.
    /// </summary>
    public static class ServiceLifetimeMetadata
    {
        /// <summary>
        /// Gets all available service lifetimes.
        /// </summary>
        public static readonly IReadOnlyList<ServiceLifetime> AllLifetimes = new[]
        {
            ServiceLifetime.Transient,
            ServiceLifetime.Scoped,
            ServiceLifetime.Singleton,
            ServiceLifetime.ThreadLocal,
            ServiceLifetime.Pooled
        };

        /// <summary>
        /// Gets service lifetimes that support instance caching.
        /// </summary>
        public static readonly IReadOnlyList<ServiceLifetime> CachedLifetimes = new[]
        {
            ServiceLifetime.Scoped,
            ServiceLifetime.Singleton,
            ServiceLifetime.ThreadLocal,
            ServiceLifetime.Pooled
        };

        /// <summary>
        /// Gets service lifetimes that require thread safety.
        /// </summary>
        public static readonly IReadOnlyList<ServiceLifetime> ThreadSafeLifetimes = new[]
        {
            ServiceLifetime.Singleton,
            ServiceLifetime.Pooled
        };

        /// <summary>
        /// Gets service lifetimes ordered by performance (fastest first).
        /// </summary>
        public static readonly IReadOnlyList<ServiceLifetime> ByPerformance = new[]
        {
            ServiceLifetime.Singleton,
            ServiceLifetime.Scoped,
            ServiceLifetime.ThreadLocal,
            ServiceLifetime.Pooled,
            ServiceLifetime.Transient
        };

        /// <summary>
        /// Gets service lifetimes ordered by memory efficiency (most efficient first).
        /// </summary>
        public static readonly IReadOnlyList<ServiceLifetime> ByMemoryEfficiency = new[]
        {
            ServiceLifetime.Transient,
            ServiceLifetime.Scoped,
            ServiceLifetime.ThreadLocal,
            ServiceLifetime.Pooled,
            ServiceLifetime.Singleton
        };
    }
}
