// <copyright file="IServiceRegistrationBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Definitions;

namespace Zentient.Abstractions.DependencyInjection
{
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
