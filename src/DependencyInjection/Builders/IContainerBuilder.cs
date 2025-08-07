// <copyright file="IContainerBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Reflection;
using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.DependencyInjection.Results;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.DependencyInjection.Builders
{
    /// <summary>Container-agnostic builder for orchestrating service registrations.</summary>
    /// <remarks>
    /// The container builder provides a comprehensive, fluent API for configuring dependency injection
    /// containers with advanced features including attribute-based registration, assembly scanning,
    /// conditional registration, module management, validation, diagnostics, and flexible container
    /// lifecycle management. It abstracts the complexities of different DI container implementations
    /// while providing rich configuration options and comprehensive error handling.
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
        /// Gets a value indicating whether auto-registration is enabled for attribute-decorated types.
        /// </summary>
        /// <value>True if auto-registration is enabled; otherwise, false.</value>
        bool AutoRegistrationEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether validation occurs during registration.
        /// </summary>
        /// <value>True if validation on registration is enabled; otherwise, false.</value>
        bool ValidationOnRegistrationEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether duplicate registrations are allowed.
        /// </summary>
        /// <value>True if duplicate registrations are allowed; otherwise, false.</value>
        bool AllowDuplicateRegistrations { get; }

        /// <summary>
        /// Gets the current environment names this builder is configured for.
        /// </summary>
        /// <value>A collection of environment names.</value>
        IReadOnlyCollection<string> Environments { get; }

        /// <summary>
        /// Gets all currently registered service types.
        /// </summary>
        /// <value>A collection of registered service types.</value>
        IReadOnlyCollection<Type> RegisteredServiceTypes { get; }

        #region Core Registration Methods

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
        /// Registers a service with its interface using fluent configuration.
        /// </summary>
        /// <typeparam name="TService">The service interface type.</typeparam>
        /// <typeparam name="TImplementation">The service implementation type.</typeparam>
        /// <param name="configure">Optional delegate to configure the registration.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder Register<TService, TImplementation>(Action<IFluentServiceRegistration<TService, TImplementation>>? configure = null)
            where TImplementation : class, TService;

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
        /// Registers a singleton instance of a service.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <param name="instance">The service instance.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="instance"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterInstance<TService>(TService instance) where TService : class;

        /// <summary>
        /// Registers a service using a factory function.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <param name="factory">The factory function to create the service.</param>
        /// <param name="lifetime">The service lifetime.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="factory"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterFactory<TService>(Func<IServiceResolver, TService> factory, ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TService : class;

        /// <summary>
        /// Registers a service using an asynchronous factory function.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <param name="factory">The asynchronous factory function to create the service.</param>
        /// <param name="lifetime">The service lifetime.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="factory"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterAsyncFactory<TService>(Func<IServiceResolver, CancellationToken, Task<TService>> factory, ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TService : class;

        #endregion

        #region Assembly Scanning

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
        /// Registers services from types that implement the specified interface in the given assemblies.
        /// </summary>
        /// <typeparam name="TInterface">The interface type to search for.</typeparam>
        /// <param name="assemblies">The assemblies to scan.</param>
        /// <param name="lifetime">The service lifetime for registered services.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterImplementationsOf<TInterface>(IEnumerable<Assembly> assemblies, ServiceLifetime lifetime = ServiceLifetime.Transient);

        #endregion

        #region Conditional Registration

        /// <summary>
        /// Registers services conditionally based on a predicate.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="configure">The configuration action to execute if the condition is true.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="condition"/> or <paramref name="configure"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterIf(Func<bool> condition, Action<IContainerBuilder> configure);

        /// <summary>
        /// Registers services conditionally based on an async predicate.
        /// </summary>
        /// <param name="condition">The async condition to evaluate.</param>
        /// <param name="configure">The configuration action to execute if the condition is true.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous conditional registration operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="condition"/> or <paramref name="configure"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        Task<IContainerBuilder> RegisterIf(Func<CancellationToken, Task<bool>> condition, Action<IContainerBuilder> configure, CancellationToken cancellationToken = default);

        /// <summary>
        /// Registers services for specific environments.
        /// </summary>
        /// <param name="environments">The environment names to register for.</param>
        /// <param name="configure">The configuration action to execute for the specified environments.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="environments"/> or <paramref name="configure"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterForEnvironments(IEnumerable<string> environments, Action<IContainerBuilder> configure);

        /// <summary>
        /// Registers services conditionally based on whether another service is registered.
        /// </summary>
        /// <typeparam name="TDependency">The dependency service type to check for.</typeparam>
        /// <param name="configure">The configuration action to execute if the dependency is registered.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="configure"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder RegisterIfServiceRegistered<TDependency>(Action<IContainerBuilder> configure);

        #endregion

        #region Module Management

        /// <summary>
        /// Adds a registration module to the builder.
        /// </summary>
        /// <typeparam name="TModule">The module type.</typeparam>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder AddModule<TModule>() where TModule : IServiceModule, new();

        /// <summary>
        /// Adds a registration module instance to the builder.
        /// </summary>
        /// <param name="module">The module instance.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="module"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder AddModule(IServiceModule module);

        /// <summary>
        /// Adds multiple registration modules to the builder.
        /// </summary>
        /// <param name="modules">The module instances.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="modules"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder AddModules(IEnumerable<IServiceModule> modules);

        #endregion

        #region Configuration

        /// <summary>
        /// Enables or disables auto-registration for attribute-decorated types.
        /// </summary>
        /// <param name="enabled">True to enable auto-registration; otherwise, false.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder ConfigureAutoRegistration(bool enabled);

        /// <summary>
        /// Enables or disables validation during registration.
        /// </summary>
        /// <param name="enabled">True to enable validation on registration; otherwise, false.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder ConfigureValidationOnRegistration(bool enabled);

        /// <summary>
        /// Configures whether duplicate registrations are allowed.
        /// </summary>
        /// <param name="allowed">True to allow duplicate registrations; otherwise, false.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder ConfigureAllowDuplicateRegistrations(bool allowed);

        /// <summary>
        /// Sets the environments this builder should consider for conditional registrations.
        /// </summary>
        /// <param name="environments">The environment names.</param>
        /// <returns>The builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="environments"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder ConfigureEnvironments(IEnumerable<string> environments);

        #endregion

        #region Service Descriptor Management

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

        #endregion

        #region Builder Configuration

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
        Task<IContainerBuilder> Configure(Func<IContainerBuilder, CancellationToken, Task> configure, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a child builder that inherits the current configuration.
        /// </summary>
        /// <returns>A new child builder instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder is already built.</exception>
        IContainerBuilder CreateChildBuilder();

        #endregion

        #region Metadata

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

        #endregion

        #region Validation & Diagnostics

        /// <summary>
        /// Validates all registered services without building the container.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous validation operation.</returns>
        Task<IResult> Validate(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets comprehensive diagnostics about the current builder state.
        /// </summary>
        /// <returns>A diagnostics report containing registration statistics and analysis.</returns>
        IContainerBuilderDiagnostics GetDiagnostics();

        /// <summary>
        /// Gets statistics about the current registrations.
        /// </summary>
        /// <returns>Registration statistics including counts by lifetime, type analysis, etc.</returns>
        IRegistrationStatistics GetStatistics();

        #endregion

        #region Container Lifecycle

        /// <summary>
        /// Builds the dependency injection container with all registered services.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous build operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder has already been built.</exception>
        Task<IServiceResolver> Build(CancellationToken cancellationToken = default);

        /// <summary>
        /// Builds the dependency injection container synchronously.
        /// </summary>
        /// <returns>The built service resolver.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder has already been built.</exception>
        IServiceResolver Build();

        /// <summary>
        /// Builds the entire Zentient application core, returning the unified
        /// <see cref="IZentient"/> interface that provides access to all framework systems.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that resolves to the fully constructed and validated <see cref="IZentient"/> instance.
        /// This represents the culmination of all four pillars working together as a cohesive system.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown when the builder has already been built.</exception>
        /// <remarks>
        /// This method performs a comprehensive build that:
        /// 1. Validates all registrations and dependencies
        /// 2. Builds the service resolver with all registered services
        /// 3. Initializes validation and diagnostic systems
        /// 4. Returns the unified IZentient interface providing access to all systems
        /// 
        /// The returned IZentient instance demonstrates the four-pillar architecture in action:
        /// - Definition-Centric Core: Through discoverable service registrations
        /// - Universal Envelope: Through standardized result handling
        /// - Fluent DI and Application Builder: Through the built service resolver
        /// - Built-in Observability: Through integrated validation and diagnostics
        /// </remarks>
        Task<IZentient> BuildZentientAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Attempts to build the dependency injection container, returning success or failure without throwing exceptions.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous build attempt.</returns>
        Task<IResult<IServiceResolver>> TryBuild(CancellationToken cancellationToken = default);

        /// <summary>
        /// Attempts to build the dependency injection container synchronously, returning success or failure without throwing exceptions.
        /// </summary>
        /// <returns>A result that represents the build attempt.</returns>
        IResult<IServiceResolver> TryBuild();

        /// <summary>
        /// Attempts to build the entire Zentient application core, returning success or failure without throwing exceptions.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous Zentient build attempt.</returns>
        /// <remarks>
        /// This method provides the same functionality as BuildZentientAsync but returns an IResult
        /// instead of throwing exceptions, making it suitable for scenarios where error handling
        /// should be explicit rather than exception-based.
        /// </remarks>
        Task<IResult<IZentient>> TryBuildZentientAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a snapshot of the current builder state for debugging or analysis.
        /// </summary>
        /// <returns>An immutable snapshot of the builder's current state.</returns>
        IContainerBuilderSnapshot CreateSnapshot();

        #endregion
    }

    /// <summary>
    /// Fluent registration interface for configuring service registrations.
    /// </summary>
    /// <typeparam name="TService">The service interface type.</typeparam>
    /// <typeparam name="TImplementation">The service implementation type.</typeparam>
    public interface IFluentServiceRegistration<TService, TImplementation>
        where TImplementation : class, TService
    {
        /// <summary>
        /// Sets the service lifetime.
        /// </summary>
        /// <param name="lifetime">The service lifetime.</param>
        /// <returns>The registration builder for method chaining.</returns>
        IFluentServiceRegistration<TService, TImplementation> WithLifetime(ServiceLifetime lifetime);

        /// <summary>
        /// Adds metadata to the service registration.
        /// </summary>
        /// <param name="metadata">The metadata to add.</param>
        /// <returns>The registration builder for method chaining.</returns>
        IFluentServiceRegistration<TService, TImplementation> WithMetadata(IMetadata metadata);

        /// <summary>
        /// Adds a metadata tag to the service registration.
        /// </summary>
        /// <typeparam name="TValue">The type of the metadata value.</typeparam>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The registration builder for method chaining.</returns>
        IFluentServiceRegistration<TService, TImplementation> WithMetadataTag<TValue>(string key, TValue value);

        /// <summary>
        /// Conditionally registers the service based on a predicate.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <returns>The registration builder for method chaining.</returns>
        IFluentServiceRegistration<TService, TImplementation> When(Func<bool> condition);

        /// <summary>
        /// Registers the service as a singleton instance.
        /// </summary>
        /// <param name="instance">The singleton instance.</param>
        /// <returns>The registration builder for method chaining.</returns>
        IFluentServiceRegistration<TService, TImplementation> AsSingleton(TImplementation instance);

        /// <summary>
        /// Registers the service using a factory method.
        /// </summary>
        /// <param name="factory">The factory method.</param>
        /// <returns>The registration builder for method chaining.</returns>
        IFluentServiceRegistration<TService, TImplementation> UsingFactory(Func<IServiceResolver, TImplementation> factory);

        /// <summary>
        /// Registers the service as a decorator for another service.
        /// </summary>
        /// <typeparam name="TDecorated">The service type to decorate.</typeparam>
        /// <returns>The registration builder for method chaining.</returns>
        IFluentServiceRegistration<TService, TImplementation> AsDecoratorFor<TDecorated>() where TDecorated : TService;

        /// <summary>
        /// Configures the service for specific environments.
        /// </summary>
        /// <param name="environments">The environment names.</param>
        /// <returns>The registration builder for method chaining.</returns>
        IFluentServiceRegistration<TService, TImplementation> ForEnvironments(params string[] environments);
    }

    /// <summary>
    /// Represents a service module that groups related service registrations.
    /// </summary>
    public interface IServiceModule
    {
        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the version of the module.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Configures services for this module.
        /// </summary>
        /// <param name="builder">The container builder to configure.</param>
        void ConfigureServices(IContainerBuilder builder);

        /// <summary>
        /// Configures services for this module asynchronously.
        /// </summary>
        /// <param name="builder">The container builder to configure.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous configuration operation.</returns>
        Task ConfigureServices(IContainerBuilder builder, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Provides comprehensive diagnostics about a container builder's state.
    /// </summary>
    public interface IContainerBuilderDiagnostics
    {
        /// <summary>
        /// Gets the timestamp when the diagnostics were generated.
        /// </summary>
        DateTimeOffset GeneratedAt { get; }

        /// <summary>
        /// Gets the total number of registered services.
        /// </summary>
        int TotalRegistrations { get; }

        /// <summary>
        /// Gets the number of registrations by service lifetime.
        /// </summary>
        IReadOnlyDictionary<ServiceLifetime, int> RegistrationsByLifetime { get; }

        /// <summary>
        /// Gets the number of registrations by service type category.
        /// </summary>
        IReadOnlyDictionary<string, int> RegistrationsByCategory { get; }

        /// <summary>
        /// Gets potential issues detected in the current registrations.
        /// </summary>
        IReadOnlyCollection<IDiagnosticIssue> PotentialIssues { get; }

        /// <summary>
        /// Gets performance metrics for the builder operations.
        /// </summary>
        IBuilderPerformanceMetrics PerformanceMetrics { get; }

        /// <summary>
        /// Gets dependency graph analysis results.
        /// </summary>
        IDependencyGraphAnalysis DependencyAnalysis { get; }
    }

    /// <summary>
    /// Provides statistical information about service registrations.
    /// </summary>
    public interface IRegistrationStatistics
    {
        /// <summary>
        /// Gets the total number of service registrations.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets the number of unique service types registered.
        /// </summary>
        int UniqueServiceTypes { get; }

        /// <summary>
        /// Gets the number of unique implementation types registered.
        /// </summary>
        int UniqueImplementationTypes { get; }

        /// <summary>
        /// Gets the count of registrations by service lifetime.
        /// </summary>
        IReadOnlyDictionary<ServiceLifetime, int> CountByLifetime { get; }

        /// <summary>
        /// Gets the most common service types by registration count.
        /// </summary>
        IReadOnlyCollection<(Type ServiceType, int Count)> MostCommonServiceTypes { get; }

        /// <summary>
        /// Gets the most common implementation types by registration count.
        /// </summary>
        IReadOnlyCollection<(Type ImplementationType, int Count)> MostCommonImplementationTypes { get; }

        /// <summary>
        /// Gets the count of open generic registrations.
        /// </summary>
        int OpenGenericCount { get; }

        /// <summary>
        /// Gets the count of closed generic registrations.
        /// </summary>
        int ClosedGenericCount { get; }

        /// <summary>
        /// Gets the count of registrations with decorators.
        /// </summary>
        int DecoratedServicesCount { get; }

        /// <summary>
        /// Gets the count of registrations with interceptors.
        /// </summary>
        int InterceptedServicesCount { get; }
    }

    /// <summary>
    /// Represents a diagnostic issue detected during container analysis.
    /// </summary>
    public interface IDiagnosticIssue
    {
        /// <summary>
        /// Gets the severity level of the issue.
        /// </summary>
        DiagnosticSeverity Severity { get; }

        /// <summary>
        /// Gets the category of the issue.
        /// </summary>
        string Category { get; }

        /// <summary>
        /// Gets a description of the issue.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the service type associated with the issue, if applicable.
        /// </summary>
        Type? ServiceType { get; }

        /// <summary>
        /// Gets suggested actions to resolve the issue.
        /// </summary>
        IReadOnlyCollection<string> SuggestedActions { get; }
    }

    /// <summary>
    /// Represents the severity level of a diagnostic issue.
    /// </summary>
    public enum DiagnosticSeverity
    {
        /// <summary>Informational message.</summary>
        Info,
        /// <summary>Warning that should be reviewed.</summary>
        Warning,
        /// <summary>Error that prevents proper operation.</summary>
        Error,
        /// <summary>Critical error that requires immediate attention.</summary>
        Critical
    }

    /// <summary>
    /// Provides performance metrics for container builder operations.
    /// </summary>
    public interface IBuilderPerformanceMetrics
    {
        /// <summary>
        /// Gets the total time spent on service registrations.
        /// </summary>
        TimeSpan TotalRegistrationTime { get; }

        /// <summary>
        /// Gets the average time per service registration.
        /// </summary>
        TimeSpan AverageRegistrationTime { get; }

        /// <summary>
        /// Gets the time spent on assembly scanning operations.
        /// </summary>
        TimeSpan AssemblyScanTime { get; }

        /// <summary>
        /// Gets the time spent on validation operations.
        /// </summary>
        TimeSpan ValidationTime { get; }

        /// <summary>
        /// Gets the peak memory usage during builder operations.
        /// </summary>
        long PeakMemoryUsage { get; }

        /// <summary>
        /// Gets the number of types scanned during assembly scanning.
        /// </summary>
        int TypesScanned { get; }

        /// <summary>
        /// Gets the number of types that were automatically registered.
        /// </summary>
        int AutoRegisteredTypes { get; }
    }

    /// <summary>
    /// Provides analysis results for the dependency graph.
    /// </summary>
    public interface IDependencyGraphAnalysis
    {
        /// <summary>
        /// Gets the total number of nodes in the dependency graph.
        /// </summary>
        int TotalNodes { get; }

        /// <summary>
        /// Gets the total number of edges in the dependency graph.
        /// </summary>
        int TotalEdges { get; }

        /// <summary>
        /// Gets the maximum depth of the dependency graph.
        /// </summary>
        int MaximumDepth { get; }

        /// <summary>
        /// Gets circular dependencies detected in the graph.
        /// </summary>
        IReadOnlyCollection<ICircularDependency> CircularDependencies { get; }

        /// <summary>
        /// Gets services with the highest number of dependencies.
        /// </summary>
        IReadOnlyCollection<(Type ServiceType, int DependencyCount)> HighestDependencyCounts { get; }

        /// <summary>
        /// Gets services that are most depended upon by other services.
        /// </summary>
        IReadOnlyCollection<(Type ServiceType, int DependentCount)> MostDependedUpon { get; }

        /// <summary>
        /// Gets leaf services (services with no dependencies).
        /// </summary>
        IReadOnlyCollection<Type> LeafServices { get; }

        /// <summary>
        /// Gets root services (services that no other service depends on).
        /// </summary>
        IReadOnlyCollection<Type> RootServices { get; }
    }

    /// <summary>
    /// Represents a circular dependency in the service graph.
    /// </summary>
    public interface ICircularDependency
    {
        /// <summary>
        /// Gets the types involved in the circular dependency.
        /// </summary>
        IReadOnlyList<Type> DependencyChain { get; }

        /// <summary>
        /// Gets the severity of the circular dependency.
        /// </summary>
        CircularDependencySeverity Severity { get; }

        /// <summary>
        /// Gets suggested resolutions for the circular dependency.
        /// </summary>
        IReadOnlyCollection<string> SuggestedResolutions { get; }
    }

    /// <summary>
    /// Represents the severity of a circular dependency.
    /// </summary>
    public enum CircularDependencySeverity
    {
        /// <summary>Low severity - can be resolved at runtime.</summary>
        Low,
        /// <summary>Medium severity - may cause performance issues.</summary>
        Medium,
        /// <summary>High severity - likely to cause runtime failures.</summary>
        High,
        /// <summary>Critical severity - will definitely cause runtime failures.</summary>
        Critical
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

        /// <summary>
        /// Gets configuration settings that were active at snapshot time.
        /// </summary>
        IBuilderConfiguration Configuration { get; }

        /// <summary>
        /// Gets statistics about registrations at snapshot time.
        /// </summary>
        IRegistrationStatistics Statistics { get; }
    }

    /// <summary>
    /// Represents the configuration settings for a container builder.
    /// </summary>
    public interface IBuilderConfiguration
    {
        /// <summary>
        /// Gets a value indicating whether auto-registration is enabled.
        /// </summary>
        bool AutoRegistrationEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether validation on registration is enabled.
        /// </summary>
        bool ValidationOnRegistrationEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether duplicate registrations are allowed.
        /// </summary>
        bool AllowDuplicateRegistrations { get; }

        /// <summary>
        /// Gets the environments configured for this builder.
        /// </summary>
        IReadOnlyCollection<string> Environments { get; }

        /// <summary>
        /// Gets custom configuration properties.
        /// </summary>
        IReadOnlyDictionary<string, object> CustomProperties { get; }
    }
}
