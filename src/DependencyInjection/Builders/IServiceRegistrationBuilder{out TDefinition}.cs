// <copyright file="IServiceRegistrationBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Definitions;

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
        IServiceRegistrationBuilder<TDefinition> WithImplementation<TImplementation>()
        where TImplementation : class;

        /// <summary>Specifies the service implementation type.</summary>
        /// <param name="implementationType">The implementation type.</param>
        IServiceRegistrationBuilder<TDefinition> WithImplementation(Type implementationType);

        /// <summary>Specifies a factory function to create the service instance.</summary>
        /// <param name="factory">The factory function.</param>
        IServiceRegistrationBuilder<TDefinition> WithFactory(Func<IServiceResolver, object> factory);

        /// <summary>Specifies the lifetime of the service in the container.</summary>
        /// <param name="lifetime">The service lifetime.</param>
        IServiceRegistrationBuilder<TDefinition> WithLifetime(ServiceLifetime lifetime);
    }
}
