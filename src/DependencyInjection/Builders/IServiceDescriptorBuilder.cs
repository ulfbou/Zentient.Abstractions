// <copyright file="IServiceDescriptorBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.DependencyInjection.Builders
{
    /// <summary>
    /// Provides a fluent interface for building service descriptors with validation and immutable construction patterns.
    /// </summary>
    /// <remarks>
    /// This builder ensures that all required properties are set before a service descriptor can be built,
    /// providing compile-time safety and runtime validation for service registration.
    /// </remarks>
    public interface IServiceDescriptorBuilder
    {
        /// <summary>
        /// Sets the service definition for the descriptor being built.
        /// </summary>
        /// <param name="definition">The service definition that defines the service contract.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="definition"/> is null.</exception>
        IServiceDescriptorBuilder WithDefinition(IServiceDefinition definition);

        /// <summary>
        /// Sets the service contract type for the descriptor being built.
        /// </summary>
        /// <typeparam name="TContract">The service contract type.</typeparam>
        /// <returns>A builder instance for method chaining.</returns>
        IServiceDescriptorBuilder WithServiceContract<TContract>();

        /// <summary>
        /// Sets the service contract type for the descriptor being built.
        /// </summary>
        /// <param name="serviceContract">The service contract type.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="serviceContract"/> is null.</exception>
        IServiceDescriptorBuilder WithServiceContract(Type serviceContract);

        /// <summary>
        /// Sets the implementation type for the descriptor being built.
        /// </summary>
        /// <typeparam name="TImplementation">The implementation type.</typeparam>
        /// <returns>A builder instance for method chaining.</returns>
        IServiceDescriptorBuilder WithImplementationType<TImplementation>()
            where TImplementation : class;

        /// <summary>
        /// Sets the implementation type for the descriptor being built.
        /// </summary>
        /// <param name="implementationType">The implementation type.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="implementationType"/> is null.</exception>
        IServiceDescriptorBuilder WithImplementationType(Type implementationType);

        /// <summary>
        /// Sets a factory function for creating service instances.
        /// </summary>
        /// <param name="factory">The factory function that creates service instances.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="factory"/> is null.</exception>
        IServiceDescriptorBuilder WithFactory(Func<IServiceResolver, Task<object>> factory);

        /// <summary>
        /// Sets a synchronous factory function for creating service instances.
        /// </summary>
        /// <param name="factory">The synchronous factory function that creates service instances.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="factory"/> is null.</exception>
        IServiceDescriptorBuilder WithFactory(Func<IServiceResolver, object> factory);

        /// <summary>
        /// Sets the service lifetime for the descriptor being built.
        /// </summary>
        /// <param name="lifetime">The service lifetime.</param>
        /// <returns>A builder instance for method chaining.</returns>
        IServiceDescriptorBuilder WithLifetime(ServiceLifetime lifetime);

        /// <summary>
        /// Sets metadata for the descriptor being built.
        /// </summary>
        /// <param name="metadata">The metadata to associate with the service descriptor.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="metadata"/> is null.</exception>
        IServiceDescriptorBuilder WithMetadata(IMetadata metadata);

        /// <summary>
        /// Adds or updates a metadata tag for the descriptor being built.
        /// </summary>
        /// <typeparam name="TValue">The type of the metadata value.</typeparam>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>A builder instance for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
        IServiceDescriptorBuilder WithMetadataTag<TValue>(string key, TValue value);

        /// <summary>
        /// Validates the current state of the builder and throws an exception if any required properties are missing.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when required properties are not set.</exception>
        void Validate();

        /// <summary>
        /// Builds an immutable service descriptor from the current builder state.
        /// </summary>
        /// <returns>A new <see cref="IServiceDescriptor"/> instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown when required properties are not set.</exception>
        IServiceDescriptor Build();

        /// <summary>
        /// Attempts to build a service descriptor, returning success or failure without throwing exceptions.
        /// </summary>
        /// <param name="descriptor">When successful, contains the built service descriptor.</param>
        /// <param name="validationErrors">When unsuccessful, contains validation error messages.</param>
        /// <returns>True if the descriptor was successfully built; otherwise, false.</returns>
        bool TryBuild(out IServiceDescriptor? descriptor, out IReadOnlyList<string>? validationErrors);

        /// <summary>
        /// Builds service descriptors by inspecting attributes on the provided type.
        /// </summary>
        /// <param name="implementationType">The type to inspect for registration attributes.</param>
        /// <returns>An enumerable of service descriptors.</returns>
        IEnumerable<IServiceDescriptor> BuildFromAttributes(Type implementationType);
    }
}
