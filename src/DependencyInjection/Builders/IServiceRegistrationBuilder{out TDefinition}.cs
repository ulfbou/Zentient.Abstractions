// <copyright file="IServiceRegistrationBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.DependencyInjection.Builders
{
    /// <summary>
    /// Fluent builder for registering a service and its full configuration.
    /// It is constrained to accept only IServiceDefinition types.
    /// </summary>
    /// <typeparam name="TDefinition">The associated service definition type.</typeparam>
    public interface IServiceRegistrationBuilder<out TDefinition>
        where TDefinition : IServiceDefinition
    {
        /// <summary>Gets the definition being configured.</summary>
        TDefinition Definition { get; }

        /// <summary>Specifies the service implementation type.</summary>
        /// <typeparam name="TImplementation">The implementation type.</typeparam>
        /// <returns>A builder instance for method chaining.</returns>
        IServiceRegistrationBuilder<TDefinition> WithImplementation<TImplementation>()
            where TImplementation : class;

        /// <summary>Specifies the service implementation type.</summary>
        /// <param name="implementationType">The implementation type.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="implementationType"/> is null.</exception>
        IServiceRegistrationBuilder<TDefinition> WithImplementation(Type implementationType);

        /// <summary>Specifies a factory function to create the service instance.</summary>
        /// <param name="factory">The factory function.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="factory"/> is null.</exception>
        IServiceRegistrationBuilder<TDefinition> WithFactory(Func<IServiceResolver, object> factory);

        /// <summary>Specifies an asynchronous factory function to create the service instance.</summary>
        /// <param name="factory">The asynchronous factory function.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="factory"/> is null.</exception>
        IServiceRegistrationBuilder<TDefinition> WithFactory(Func<IServiceResolver, Task<object>> factory);

        /// <summary>Specifies the lifetime of the service in the container.</summary>
        /// <param name="lifetime">The service lifetime.</param>
        /// <returns>A builder instance for method chaining.</returns>
        IServiceRegistrationBuilder<TDefinition> WithLifetime(ServiceLifetime lifetime);

        /// <summary>Adds metadata to the service registration.</summary>
        /// <param name="metadata">The metadata to associate with the service.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="metadata"/> is null.</exception>
        IServiceRegistrationBuilder<TDefinition> WithMetadata(IMetadata metadata);

        /// <summary>Adds a metadata tag to the service registration.</summary>
        /// <typeparam name="TValue">The type of the metadata value.</typeparam>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
        IServiceRegistrationBuilder<TDefinition> WithMetadataTag<TValue>(string key, TValue value);

        /// <summary>
        /// Registers the service conditionally based on a predicate.
        /// </summary>
        /// <param name="condition">A predicate that determines whether the service should be registered.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="condition"/> is null.</exception>
        IServiceRegistrationBuilder<TDefinition> When(Func<IServiceRegistry, bool> condition);

        /// <summary>
        /// Registers the service conditionally based on an asynchronous predicate.
        /// </summary>
        /// <param name="condition">An asynchronous predicate that determines whether the service should be registered.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="condition"/> is null.</exception>
        IServiceRegistrationBuilder<TDefinition> WhenAsync(Func<IServiceRegistry, CancellationToken, Task<bool>> condition, CancellationToken cancellationToken = default);

        /// <summary>
        /// Configures the service as a decorator for existing registrations.
        /// </summary>
        /// <typeparam name="TDecorated">The type of service being decorated.</typeparam>
        /// <returns>A builder instance for method chaining.</returns>
        IServiceRegistrationBuilder<TDefinition> AsDecoratorFor<TDecorated>();

        /// <summary>
        /// Configures the service as an interceptor for method calls on existing registrations.
        /// </summary>
        /// <typeparam name="TIntercepted">The type of service being intercepted.</typeparam>
        /// <returns>A builder instance for method chaining.</returns>
        IServiceRegistrationBuilder<TDefinition> AsInterceptorFor<TIntercepted>();

        /// <summary>
        /// Validates the current registration configuration.
        /// </summary>
        /// <returns>A result indicating success or failure with validation errors.</returns>
        Task<IResult> ValidateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Completes the service registration and returns the built service descriptor.
        /// </summary>
        /// <returns>The completed service descriptor.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the registration is invalid.</exception>
        IServiceDescriptor Register();

        /// <summary>
        /// Attempts to complete the service registration, returning success or failure without throwing exceptions.
        /// </summary>
        /// <param name="descriptor">When successful, contains the built service descriptor.</param>
        /// <param name="validationErrors">When unsuccessful, contains validation error messages.</param>
        /// <returns>True if the registration was successful; otherwise, false.</returns>
        bool TryRegister(out IServiceDescriptor? descriptor, out IReadOnlyList<string>? validationErrors);

        /// <summary>
        /// Registers multiple implementations for the same service contract.
        /// </summary>
        /// <param name="implementationTypes">The implementation types to register.</param>
        /// <returns>A collection of service descriptors for all registered implementations.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="implementationTypes"/> is null.</exception>
        IEnumerable<IServiceDescriptor> RegisterMultiple(params Type[] implementationTypes);

        /// <summary>
        /// Registers multiple implementations for the same service contract with individual configuration.
        /// </summary>
        /// <param name="implementations">A collection of implementation configurations.</param>
        /// <returns>A collection of service descriptors for all registered implementations.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="implementations"/> is null.</exception>
        IEnumerable<IServiceDescriptor> RegisterMultiple(IEnumerable<(Type ImplementationType, ServiceLifetime Lifetime, IMetadata? Metadata)> implementations);
    }
}
