// <copyright file="IContainerBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Reflection;
using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.DependencyInjection.Results;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.DependencyInjection.Builders
{
    /// <summary>Container-agnostic builder for orchestrating service registrations.</summary>
    /// <remarks>
    /// The container builder provides a high-level API for configuring dependency injection
    /// containers with support for attribute-based registration, validation, and performance optimization.
    /// It abstracts the complexities of different DI container implementations while providing
    /// rich configuration options and comprehensive error handling.
    /// </remarks>
    public interface IContainerBuilder
    {
        /// <summary>
        /// Gets the service registry associated with this builder.
        /// </summary>
        /// <value>The service registry that will contain all registered services.</value>
        IServiceRegistry Registry { get; }

        /// <summary>
        /// Gets a value indicating whether the builder is in read-only mode.
        /// </summary>
        /// <value>True if the container has been built and is immutable; otherwise, false.</value>
        bool IsBuilt { get; }

        /// <summary>
        /// Registers a service implementation by discovering its metadata via attributes.
        /// </summary>
        /// <typeparam name="TImplementation">The service implementation type.</typeparam>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder Register<TImplementation>() where TImplementation : class;

        /// <summary>
        /// Registers a service implementation by discovering its metadata via attributes.
        /// </summary>
        /// <param name="implementationType">The service implementation type.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="implementationType"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder Register(Type implementationType);

        /// <summary>
        /// Registers a service and its configuration using a definition.
        /// This is used for manual overrides or third-party registrations.
        /// </summary>
        /// <typeparam name="TDefinition">The definition type.</typeparam>
        /// <param name="definition">The definition instance.</param>
        /// <param name="configure">Delegate to configure the registration.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="definition"/> or <paramref name="configure"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder Register<TDefinition>(
            TDefinition definition,
            Action<IServiceRegistrationBuilder<TDefinition>> configure)
            where TDefinition : IServiceDefinition;

        /// <summary>
        /// Registers multiple services from the specified assemblies using attribute discovery.
        /// </summary>
        /// <param name="assemblies">The assemblies to scan for service types.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="assemblies"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterFromAssemblies(params Assembly[] assemblies);

        /// <summary>
        /// Registers multiple services from the specified assemblies with filtering.
        /// </summary>
        /// <param name="assemblies">The assemblies to scan for service types.</param>
        /// <param name="typeFilter">A predicate to filter types for registration.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="assemblies"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterFromAssemblies(IEnumerable<Assembly> assemblies, Func<Type, bool>? typeFilter = null);

        /// <summary>
        /// Registers services from types in the calling assembly.
        /// </summary>
        /// <param name="typeFilter">A predicate to filter types for registration.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterFromCallingAssembly(Func<Type, bool>? typeFilter = null);

        /// <summary>
        /// Registers services from types in the entry assembly.
        /// </summary>
        /// <param name="typeFilter">A predicate to filter types for registration.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterFromEntryAssembly(Func<Type, bool>? typeFilter = null);

        /// <summary>
        /// Adds a service descriptor directly to the builder.
        /// </summary>
        /// <param name="descriptor">The service descriptor to add.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="descriptor"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder Add(IServiceDescriptor descriptor);

        /// <summary>
        /// Adds multiple service descriptors to the builder.
        /// </summary>
        /// <param name="descriptors">The service descriptors to add.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="descriptors"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder AddRange(IEnumerable<IServiceDescriptor> descriptors);

        /// <summary>
        /// Configures the builder with a custom action.
        /// </summary>
        /// <param name="configure">The configuration action to apply.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="configure"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder Configure(Action<IContainerBuilder> configure);

        /// <summary>
        /// Configures the builder asynchronously with a custom action.
        /// </summary>
        /// <param name="configure">The asynchronous configuration action to apply.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous configuration operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="configure"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        Task<IContainerBuilder> ConfigureAsync(Func<IContainerBuilder, CancellationToken, Task> configure, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds metadata to be associated with the container build process.
        /// </summary>
        /// <param name="metadata">The metadata to add.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="metadata"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder WithMetadata(IMetadata metadata);

        /// <summary>
        /// Adds a metadata tag to be associated with the container build process.
        /// </summary>
        /// <typeparam name="TValue">The type of the metadata value.</typeparam>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder WithMetadataTag<TValue>(string key, TValue value);

        /// <summary>
        /// Validates all registered services without building the container.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous validation operation.</returns>
        Task<IResult> ValidateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Builds the dependency injection container with all registered services.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous build operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder has already been built.</exception>
        Task<IServiceResolver> BuildAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Attempts to build the dependency injection container, returning success or failure without throwing exceptions.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous build attempt.</returns>
        Task<IResult<IServiceResolver>> TryBuildAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a snapshot of the current builder state for debugging or analysis.
        /// </summary>
        /// <returns>An immutable snapshot of the builder's current state.</returns>
        IContainerBuilderSnapshot CreateSnapshot();

        /// <summary>
        /// Removes all services that match the specified predicate.
        /// </summary>
        /// <param name="predicate">A predicate to identify services to remove.</param>
        /// <returns>The number of services removed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        int RemoveAll(Func<IServiceDescriptor, bool> predicate);

        /// <summary>
        /// Replaces existing service registrations with new ones.
        /// </summary>
        /// <param name="predicate">A predicate to identify services to replace.</param>
        /// <param name="replacement">The replacement service descriptor.</param>
        /// <returns>The number of services replaced.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> or <paramref name="replacement"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        int Replace(Func<IServiceDescriptor, bool> predicate, IServiceDescriptor replacement);

        /// <summary>
        /// Decorates existing service registrations with decorator implementations.
        /// </summary>
        /// <typeparam name="TService">The service type to decorate.</typeparam>
        /// <typeparam name="TDecorator">The decorator implementation type.</typeparam>
        /// <param name="lifetime">The lifetime of the decorator service.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder Decorate<TService, TDecorator>(ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TDecorator : class, TService;

        /// <summary>
        /// Adds an interceptor for method calls on existing service registrations.
        /// </summary>
        /// <typeparam name="TService">The service type to intercept.</typeparam>
        /// <typeparam name="TInterceptor">The interceptor implementation type.</typeparam>
        /// <param name="lifetime">The lifetime of the interceptor service.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder Intercept<TService, TInterceptor>(ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TInterceptor : class;
    }

    /// <summary>
    /// Represents an immutable snapshot of a container builder's state.
    /// </summary>
    public interface IContainerBuilderSnapshot
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
        /// Gets metadata about the builder state at snapshot time.
        /// </summary>
        IMetadata BuilderMetadata { get; }

        /// <summary>
        /// Gets a value indicating whether the builder was built at snapshot time.
        /// </summary>
        bool WasBuilt { get; }

        /// <summary>
        /// Gets validation results from the snapshot time, if validation was performed.
        /// </summary>
        IResult? ValidationResult { get; }
    }
}
