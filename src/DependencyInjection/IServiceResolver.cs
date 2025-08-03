// <copyright file="IServiceResolver.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.DependencyInjection.Definitions;
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
    /// with full support for asynchronous operations and metadata-driven queries.
    /// </remarks>
    public interface IServiceResolver : IServiceProvider
    {
        /// <summary>
        /// Resolves a single instance of the specified contract using a metadata-based predicate.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">A function to filter service descriptors based on metadata.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        Task<IResult<TContract>> ResolveSingle<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolves all registered instances of the specified contract asynchronously.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">A function to filter service descriptors based on metadata.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An asynchronous enumerable of all resolved instances.</returns>
        IAsyncEnumerable<TContract> ResolveMany<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default,
            CancellationToken cancellationToken = default);
    }
    /// <summary>
    /// A fluent builder for wiring up a service definition.
    /// </summary>
    /// <typeparam name="TDefinition">The type of the service definition.</typeparam>
    public interface IServiceRegistrationBuilder<TDefinition>
        where TDefinition : IServiceDefinition
    {
        /// <summary>
        /// Registers a concrete implementation type for the service contract.
        /// </summary>
        IServiceRegistrationBuilder<TDefinition> WithImplementation<TImpl>()
            where TImpl : class, TDefinition;

        /// <summary>
        /// Registers an asynchronous factory delegate for the service contract.
        /// </summary>
        IServiceRegistrationBuilder<TDefinition> WithFactory(Func<IServiceResolver, Task<object>> factory);

        /// <summary>
        /// Registers a synchronous factory delegate for the service contract.
        /// </summary>
        IServiceRegistrationBuilder<TDefinition> WithFactory(Func<IServiceResolver, object> factory);

        /// <summary>
        /// Sets the lifetime of the registered service.
        /// </summary>
        IServiceRegistrationBuilder<TDefinition> WithLifetime(ServiceLifetime lifetime);

        /// <summary>
        /// Adds metadata to the service registration.
        /// </summary>
        IServiceRegistrationBuilder<TDefinition> WithMetadata(string key, object? value);

        /// <summary>
        /// Finalizes and builds the service descriptor.
        /// </summary>
        IServiceDescriptor Build();
    }
}
