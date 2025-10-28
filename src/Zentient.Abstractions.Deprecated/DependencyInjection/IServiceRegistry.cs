// <copyright file="IServiceRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Reflection;
using Zentient.Abstractions.DependencyInjection.Builders;
using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.DependencyInjection.Predicates;
using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.DependencyInjection
{
    /// <summary>
    /// Represents a registry that holds and manages all service descriptors in Zentient.
    /// </summary>
    /// <remarks>
    /// The service registry provides comprehensive service management capabilities including
    /// registration, querying, validation, and advanced patterns like decorators and interceptors.
    /// All operations are thread-safe and support both synchronous and asynchronous patterns.
    /// </remarks>
    public interface IServiceRegistry
    {
        /// <summary>
        /// Gets the total number of registered services.
        /// </summary>
        /// <value>The count of all service descriptors in the registry.</value>
        int Count { get; }

        /// <summary>
        /// Gets a value indicating whether the registry is read-only.
        /// </summary>
        /// <value>
        /// True if the registry has been built and is immutable; otherwise, false.
        /// </value>
        bool IsReadOnly { get; }

        /// <summary>Begins the fluent registration process for a new service definition.</summary>
        /// <typeparam name="TDefinition">The type of the service definition.</typeparam>
        /// <returns>A fluent builder for configuring the service registration.</returns>
        /// <remarks>
        /// The actual fluent builder type <see cref="IServiceRegistrationBuilder{TDefinition}"/>
        /// would be defined in a concrete implementation or a separate fluent API namespace.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the registry is read-only.</exception>
        IServiceRegistrationBuilder<TDefinition> Register<TDefinition>()
            where TDefinition : IServiceDefinition;

        /// <summary>
        /// Registers a service using a pre-built service descriptor.
        /// </summary>
        /// <param name="descriptor">The service descriptor to register.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="descriptor"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the registry is read-only.</exception>
        void Register(IServiceDescriptor descriptor);

        /// <summary>
        /// Registers multiple services using pre-built service descriptors.
        /// </summary>
        /// <param name="descriptors">The service descriptors to register.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="descriptors"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the registry is read-only.</exception>
        void RegisterRange(IEnumerable<IServiceDescriptor> descriptors);

        /// <summary>
        /// Registers services by scanning types with registration attributes.
        /// </summary>
        /// <param name="assemblies">The assemblies to scan for attributed types.</param>
        /// <returns>The number of services registered.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="assemblies"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the registry is read-only.</exception>
        int RegisterFromAttributes(params Assembly[] assemblies);

        /// <summary>
        /// Registers services by scanning types in the specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies to scan.</param>
        /// <param name="predicate">A predicate to filter types for registration.</param>
        /// <returns>The number of services registered.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="assemblies"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the registry is read-only.</exception>
        int RegisterFromAssemblies(IEnumerable<Assembly> assemblies, Func<Type, bool>? predicate = null);

        /// <summary>Gets all finalized service descriptors.</summary>
        /// <returns>A read-only collection of all registered service descriptors.</returns>
        IReadOnlyCollection<IServiceDescriptor> GetAll();

        /// <summary>
        /// Gets all service descriptors that match the specified predicate.
        /// </summary>
        /// <param name="predicate">A predicate to filter service descriptors.</param>
        /// <returns>A collection of matching service descriptors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
        IEnumerable<IServiceDescriptor> GetAll(Func<IServiceDescriptor, bool> predicate);

        /// <summary>
        /// Gets all service descriptors that match the specified metadata predicate.
        /// </summary>
        /// <param name="predicate">A metadata predicate to filter service descriptors.</param>
        /// <returns>A collection of matching service descriptors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
        IEnumerable<IServiceDescriptor> GetAll(IMetadataPredicate predicate);

        /// <summary>
        /// Gets all service descriptors for the specified contract type.
        /// </summary>
        /// <typeparam name="TContract">The contract type to search for.</typeparam>
        /// <returns>A collection of service descriptors implementing the contract.</returns>
        IEnumerable<IServiceDescriptor> GetAllFor<TContract>();

        /// <summary>
        /// Gets all service descriptors for the specified contract type.
        /// </summary>
        /// <param name="contractType">The contract type to search for.</param>
        /// <returns>A collection of service descriptors implementing the contract.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="contractType"/> is null.</exception>
        IEnumerable<IServiceDescriptor> GetAllFor(Type contractType);

        /// <summary>
        /// Tries to get a service descriptor by its unique definition identifier.
        /// </summary>
        /// <param name="definitionId">The unique identifier of the service definition.</param>
        /// <param name="descriptor">
        /// When this method returns, contains the <see cref="IServiceDescriptor"/>
        /// associated with the specified <paramref name="definitionId"/>, if the ID is found;
        /// otherwise, <see langword="null"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the service descriptor is found;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        bool TryGet(string definitionId, out IServiceDescriptor? descriptor);

        /// <summary>
        /// Tries to get the first service descriptor for the specified contract type.
        /// </summary>
        /// <typeparam name="TContract">The contract type to search for.</typeparam>
        /// <param name="descriptor">
        /// When this method returns, contains the first <see cref="IServiceDescriptor"/>
        /// for the specified contract type, if found; otherwise, <see langword="null"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if a service descriptor is found;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        bool TryGetFor<TContract>(out IServiceDescriptor? descriptor);

        /// <summary>
        /// Tries to get the first service descriptor for the specified contract type.
        /// </summary>
        /// <param name="contractType">The contract type to search for.</param>
        /// <param name="descriptor">
        /// When this method returns, contains the first <see cref="IServiceDescriptor"/>
        /// for the specified contract type, if found; otherwise, <see langword="null"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if a service descriptor is found;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        bool TryGetFor(Type contractType, out IServiceDescriptor? descriptor);

        /// <summary>
        /// Checks if any services are registered for the specified contract type.
        /// </summary>
        /// <typeparam name="TContract">The contract type to check for.</typeparam>
        /// <returns>True if any services are registered for the contract; otherwise, false.</returns>
        bool IsRegistered<TContract>();

        /// <summary>
        /// Checks if any services are registered for the specified contract type.
        /// </summary>
        /// <param name="contractType">The contract type to check for.</param>
        /// <returns>True if any services are registered for the contract; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="contractType"/> is null.</exception>
        bool IsRegistered(Type contractType);

        /// <summary>
        /// Removes a service descriptor from the registry.
        /// </summary>
        /// <param name="descriptor">The service descriptor to remove.</param>
        /// <returns>True if the descriptor was removed; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="descriptor"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the registry is read-only.</exception>
        bool Remove(IServiceDescriptor descriptor);

        /// <summary>
        /// Removes all service descriptors that match the specified predicate.
        /// </summary>
        /// <param name="predicate">A predicate to identify descriptors to remove.</param>
        /// <returns>The number of descriptors removed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the registry is read-only.</exception>
        int RemoveAll(Func<IServiceDescriptor, bool> predicate);

        /// <summary>
        /// Validates all registered services and their dependencies.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A result indicating success or failure with validation errors.</returns>
        Task<IResult> ValidateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Builds the registry, making it read-only and optimizing internal structures.
        /// </summary>
        /// <returns>A result indicating success or failure of the build operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the registry is already built.</exception>
        Task<IResult> BuildAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new service registry builder for fluent configuration.
        /// </summary>
        /// <returns>A new service registry builder instance.</returns>
        IServiceRegistryBuilder CreateBuilder();

        /// <summary>
        /// Creates a snapshot of the current registry state.
        /// </summary>
        /// <returns>An immutable snapshot of all service descriptors.</returns>
        IServiceRegistrySnapshot CreateSnapshot();
    }

    /// <summary>
    /// Represents a builder for configuring service registries with fluent API support.
    /// </summary>
    public interface IServiceRegistryBuilder
    {
        /// <summary>
        /// Adds a service descriptor to the registry being built.
        /// </summary>
        /// <param name="descriptor">The service descriptor to add.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="descriptor"/> is null.</exception>
        IServiceRegistryBuilder Add(IServiceDescriptor descriptor);

        /// <summary>
        /// Adds multiple service descriptors to the registry being built.
        /// </summary>
        /// <param name="descriptors">The service descriptors to add.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="descriptors"/> is null.</exception>
        IServiceRegistryBuilder AddRange(IEnumerable<IServiceDescriptor> descriptors);

        /// <summary>
        /// Applies a configuration action to the registry being built.
        /// </summary>
        /// <param name="configure">The configuration action to apply.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="configure"/> is null.</exception>
        IServiceRegistryBuilder Configure(Action<IServiceRegistry> configure);

        /// <summary>
        /// Builds the configured service registry.
        /// </summary>
        /// <returns>A new service registry instance.</returns>
        IServiceRegistry Build();
    }

    /// <summary>
    /// Represents an immutable snapshot of a service registry's state.
    /// </summary>
    public interface IServiceRegistrySnapshot
    {
        /// <summary>
        /// Gets the timestamp when this snapshot was created.
        /// </summary>
        DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Gets all service descriptors in the snapshot.
        /// </summary>
        IReadOnlyCollection<IServiceDescriptor> Descriptors { get; }

        /// <summary>
        /// Gets metadata about the registry state at snapshot time.
        /// </summary>
        IMetadata Metadata { get; }
    }
}
