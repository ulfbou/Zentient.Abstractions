// <copyright file="IServiceResolver.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.DependencyInjection.Performance;
using Zentient.Abstractions.DependencyInjection.Predicates;
using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.DependencyInjection.Results;
using Zentient.Abstractions.DependencyInjection.Scopes;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.DependencyInjection
{
    /// <summary>
    /// Represents a DI-agnostic resolver for retrieving services from the container.
    /// </summary>
    /// <remarks>
    /// This is the primary abstraction for consumers to resolve services.
    /// It provides both exception-based and result-based resolution methods,
    /// with full support for asynchronous operations, metadata-driven queries,
    /// performance monitoring, and advanced resolution patterns like optional dependencies.
    /// It also provides access to the <see cref="IServiceScopeFactory"/> for managing scoped services.
    /// </remarks>
    public interface IServiceResolver : IServiceProvider, IAsyncServiceProvider
    {
        /// <summary>Gets the factory for creating new service scopes.</summary>
        IServiceScopeFactory ScopeFactory { get; }

        /// <summary>Gets the performance monitor for tracking resolution metrics.</summary>
        IServicePerformanceMonitor PerformanceMonitor { get; }

        /// <summary>Gets the service registry associated with this resolver.</summary>
        IServiceRegistry Registry { get; }

        /// <summary>
        /// Resolves a single instance of the specified contract using an optional metadata-based
        /// predicate.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to monitor for cancellation requests.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, returning an
        /// <see cref="IServiceResolutionResult{TContract}"/> indicating success or failure of the resolution.
        /// </returns>
        Task<IServiceResolutionResult<TContract>> ResolveSingleAsync<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolves a single instance of the specified contract using a structured metadata
        /// predicate.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">A structured predicate to filter service descriptors.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, returning an
        /// <see cref="IServiceResolutionResult{TContract}"/> indicating success or failure of the resolution.
        /// </returns>
        Task<IServiceResolutionResult<TContract>> ResolveSingleAsync<TContract>(
            IMetadataPredicate predicate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolves a single instance of the specified contract synchronously for performance-critical scenarios.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <returns>
        /// An <see cref="IServiceResolutionResult{TContract}"/> indicating success or failure of the resolution.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the service requires asynchronous resolution.
        /// </exception>
        IServiceResolutionResult<TContract> ResolveSingle<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default);

        /// <summary>
        /// Attempts to resolve a single instance of the specified contract, returning null if not found.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, returning the resolved service
        /// or null if no matching service is registered.
        /// </returns>
        Task<TContract?> TryResolveSingleAsync<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default,
            CancellationToken cancellationToken = default) where TContract : class;

        /// <summary>
        /// Attempts to resolve a single instance of the specified contract synchronously.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <returns>
        /// The resolved service or null if no matching service is registered.
        /// </returns>
        TContract? TryResolveSingle<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default) where TContract : class;

        /// <summary>
        /// Resolves all registered instances of the specified contract asynchronously,
        /// using an optional metadata-based predicate.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// An asynchronous enumerable of all resolved instances matching the criteria.
        /// </returns>
        IAsyncEnumerable<TContract> ResolveManyAsync<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolves all registered instances of the specified contract asynchronously,
        /// using a structured metadata predicate.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">A structured predicate to filter service descriptors.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// An asynchronous enumerable of all resolved instances matching the criteria.
        /// </returns>
        IAsyncEnumerable<TContract> ResolveManyAsync<TContract>(
            IMetadataPredicate predicate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolves all registered instances of the specified contract synchronously.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <returns>
        /// A collection of all resolved instances matching the criteria.
        /// </returns>
        IEnumerable<TContract> ResolveMany<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default);

        /// <summary>
        /// Resolves services by their service definition identifiers.
        /// </summary>
        /// <param name="definitionIds">The service definition identifiers to resolve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, returning a dictionary
        /// of definition IDs to resolved service instances.
        /// </returns>
        Task<IReadOnlyDictionary<string, object>> ResolveByDefinitionIdsAsync(
            IEnumerable<string> definitionIds,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolves a service by name with optional type constraints.
        /// </summary>
        /// <typeparam name="TContract">The expected contract type.</typeparam>
        /// <param name="serviceName">The name of the service to resolve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, returning the named service
        /// or an error result if not found or type mismatch occurs.
        /// </returns>
        Task<IServiceResolutionResult<TContract>> ResolveByNameAsync<TContract>(
            string serviceName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a service can be resolved without actually resolving it.
        /// </summary>
        /// <typeparam name="TContract">The contract type to check.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <returns>True if the service can be resolved; otherwise, false.</returns>
        bool CanResolve<TContract>(Func<IServiceDescriptor, bool>? predicate = default);

        /// <summary>
        /// Checks if a service can be resolved without actually resolving it.
        /// </summary>
        /// <param name="serviceType">The service type to check.</param>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <returns>True if the service can be resolved; otherwise, false.</returns>
        bool CanResolve(Type serviceType, Func<IServiceDescriptor, bool>? predicate = default);

        /// <summary>
        /// Gets all service descriptors that can provide the specified contract type.
        /// </summary>
        /// <typeparam name="TContract">The contract type to search for.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <returns>A collection of service descriptors that can provide the contract type.</returns>
        IEnumerable<IServiceDescriptor> GetProvidersFor<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default);

        /// <summary>
        /// Gets all service descriptors that can provide the specified service type.
        /// </summary>
        /// <param name="serviceType">The service type to search for.</param>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <returns>A collection of service descriptors that can provide the service type.</returns>
        IEnumerable<IServiceDescriptor> GetProvidersFor(
            Type serviceType,
            Func<IServiceDescriptor, bool>? predicate = default);

        /// <summary>
        /// Creates a child resolver with additional or overridden services.
        /// </summary>
        /// <param name="configure">A delegate to configure the child resolver.</param>
        /// <returns>A new service resolver with the additional configuration.</returns>
        IServiceResolver CreateChildResolver(Action<IServiceRegistry> configure);

        /// <summary>
        /// Disposes of the resolver and all its managed resources.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous dispose operation.</returns>
        ValueTask DisposeAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Provides asynchronous service resolution capabilities.
    /// </summary>
    public interface IAsyncServiceProvider
    {
        /// <summary>
        /// Gets a service of the specified type asynchronously.
        /// </summary>
        /// <param name="serviceType">The type of service to resolve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<object?> GetServiceAsync(Type serviceType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a service of the specified type asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of service to resolve.</typeparam>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<T?> GetServiceAsync<T>(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a required service of the specified type asynchronously.
        /// </summary>
        /// <param name="serviceType">The type of service to resolve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the service cannot be resolved.</exception>
        Task<object> GetRequiredServiceAsync(Type serviceType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a required service of the specified type asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of service to resolve.</typeparam>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the service cannot be resolved.</exception>
        Task<T> GetRequiredServiceAsync<T>(CancellationToken cancellationToken = default) where T : notnull;

        /// <summary>
        /// Gets all services of the specified type asynchronously.
        /// </summary>
        /// <param name="serviceType">The type of services to resolve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An asynchronous enumerable of all services of the specified type.</returns>
        IAsyncEnumerable<object> GetServicesAsync(Type serviceType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all services of the specified type asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of services to resolve.</typeparam>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An asynchronous enumerable of all services of the specified type.</returns>
        IAsyncEnumerable<T> GetServicesAsync<T>(CancellationToken cancellationToken = default);
    }
}
