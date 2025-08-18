// <copyright file="IServiceDescriptor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.DependencyInjection.Registration
{
    /// <summary>Describes a registered service in the dependency injection container.</summary>
    /// <remarks>
    /// Service descriptors are immutable data structures that contain all the information
    /// needed to create service instances. They support both synchronous and asynchronous
    /// factory patterns with optimized hot paths for performance-critical scenarios.
    /// </remarks>
    public interface IServiceDescriptor
    {
        /// <summary>Gets the unique identifier for this service descriptor.</summary>
        /// <value>A unique string identifier for this service registration.</value>
        string Id { get; }

        /// <summary>Gets the type-safe definition for the service.</summary>
        /// <value>The service definition that defines the service contract and metadata.</value>
        IServiceDefinition Definition { get; }

        /// <summary>Gets the CLR type of the contract being registered.</summary>
        /// <value>The contract type that consumers will request.</value>
        Type ServiceContract { get; }

        /// <summary>Gets the CLR type of the implementation being registered.</summary>
        /// <value>The concrete implementation type that will be instantiated.</value>
        Type ImplementationType { get; }

        /// <summary>
        /// Gets the asynchronous factory delegate used to create the service instance.
        /// </summary>
        /// <value>
        /// An asynchronous factory function that creates service instances.
        /// This is the primary factory method that all other factory types delegate to.
        /// </value>
        Func<IServiceResolver, CancellationToken, Task<object>> AsyncFactory { get; }

        /// <summary>
        /// Gets a synchronous factory delegate for performance-critical scenarios.
        /// </summary>
        /// <value>
        /// An optional synchronous factory function for zero-allocation hot paths.
        /// If null, the service requires asynchronous instantiation.
        /// </value>
        Func<IServiceResolver, object>? SyncFactory { get; }

        /// <summary>Gets metadata associated with this service registration.</summary>
        /// <value>Immutable metadata that can be used for filtering and service discovery.</value>
        IMetadata Metadata { get; }

        /// <summary>Gets the lifetime of the registered service.</summary>
        /// <value>The service lifetime that determines instance creation and disposal behavior.</value>
        ServiceLifetime Lifetime { get; }


        /// <summary>
        /// Gets a value indicating whether this service can be created synchronously.
        /// </summary>
        /// <value>
        /// True if the service has a synchronous factory and can be created without async overhead;
        /// otherwise, false.
        /// </value>
#if NETSTANDARD2_0
        bool SupportsSynchronousCreation { get; }
#else
        bool SupportsSynchronousCreation => SyncFactory is not null;
#endif

        /// <summary>
        /// Gets a value indicating whether this service supports decorator patterns.
        /// </summary>
        /// <value>
        /// True if this service is configured as a decorator for another service;
        /// otherwise, false.
        /// </value>
        bool IsDecorator { get; }

        /// <summary>
        /// Gets the type being decorated if this service is a decorator.
        /// </summary>
        /// <value>
        /// The type being decorated, or null if this service is not a decorator.
        /// </value>
        Type? DecoratedType { get; }

        /// <summary>
        /// Gets a value indicating whether this service supports interception patterns.
        /// </summary>
        /// <value>
        /// True if this service is configured as an interceptor for method calls;
        /// otherwise, false.
        /// </value>
        bool IsInterceptor { get; }

        /// <summary>
        /// Gets the type being intercepted if this service is an interceptor.
        /// </summary>
        /// <value>
        /// The type being intercepted, or null if this service is not an interceptor.
        /// </value>
        Type? InterceptedType { get; }

        /// <summary>
        /// Gets conditional registration predicates that determine when this service should be active.
        /// </summary>
        /// <value>
        /// A collection of predicates that must all return true for this service to be available.
        /// Empty collection means the service is always available.
        /// </value>
        IReadOnlyCollection<Func<IServiceRegistry, bool>> Conditions { get; }

        /// <summary>
        /// Gets asynchronous conditional registration predicates.
        /// </summary>
        /// <value>
        /// A collection of async predicates that must all return true for this service to be available.
        /// Empty collection means no async conditions are defined.
        /// </value>
        IReadOnlyCollection<Func<IServiceRegistry, CancellationToken, Task<bool>>> AsyncConditions { get; }

        /// <summary>
        /// Creates a service instance using the synchronous factory if available.
        /// </summary>
        /// <param name="resolver">The service resolver to use for dependency resolution.</param>
        /// <returns>A new service instance.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the service does not support synchronous creation.
        /// </exception>
        object CreateInstance(IServiceResolver resolver);

        /// <summary>
        /// Creates a service instance using the asynchronous factory.
        /// </summary>
        /// <param name="resolver">The service resolver to use for dependency resolution.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous creation operation.</returns>
        Task<object> CreateInstanceAsync(IServiceResolver resolver, CancellationToken cancellationToken = default);

        /// <summary>
        /// Evaluates all registration conditions to determine if this service should be available.
        /// </summary>
        /// <param name="registry">The service registry to evaluate conditions against.</param>
        /// <returns>True if all conditions are met; otherwise, false.</returns>
        bool EvaluateConditions(IServiceRegistry registry);

        /// <summary>
        /// Evaluates all registration conditions asynchronously to determine if this service should be available.
        /// </summary>
        /// <param name="registry">The service registry to evaluate conditions against.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous evaluation operation.</returns>
        Task<bool> EvaluateConditionsAsync(IServiceRegistry registry, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new service descriptor with updated metadata.
        /// </summary>
        /// <param name="metadata">The new metadata to associate with the service.</param>
        /// <returns>A new service descriptor with the updated metadata.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="metadata"/> is null.</exception>
        IServiceDescriptor WithMetadata(IMetadata metadata);

        /// <summary>
        /// Creates a new service descriptor with an additional metadata tag.
        /// </summary>
        /// <typeparam name="TValue">The type of the metadata value.</typeparam>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>A new service descriptor with the additional metadata tag.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
        IServiceDescriptor WithMetadataTag<TValue>(string key, TValue value);
    }
}
