// <copyright file="IContainerBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Definitions;

namespace Zentient.Abstractions.DependencyInjection.Builders
{
    /// <summary>Container-agnostic builder for orchestrating service registrations.</summary>
    public interface IContainerBuilder
    {
        /// <summary>
        /// Registers a service implementation by discovering its metadata via attributes.
        /// </summary>
        /// <typeparam name="TImplementation">The service implementation type.</typeparam>
        IContainerBuilder Register<TImplementation>() where TImplementation : class;

        /// <summary>
        /// Registers a service and its configuration using a definition.
        /// This is used for manual overrides or third-party registrations.
        /// </summary>
        /// <typeparam name="TDefinition">The definition type.</typeparam>
        /// <param name="definition">The definition instance.</param>
        /// <param name="configure">Delegate to configure the registration.</param>
        void Register<TDefinition>(
            TDefinition definition,
            Action<IServiceRegistrationBuilder<TDefinition>> configure)
            where TDefinition : IServiceDefinition;
    }
}
