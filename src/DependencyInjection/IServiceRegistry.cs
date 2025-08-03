// <copyright file="IServiceRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Definitions;

namespace Zentient.Abstractions.DependencyInjection
{
    /// <summary>
    /// Represents a registry that holds and manages all service descriptors in Zentient.
    /// </summary>
    public interface IServiceRegistry
    {
        /// <summary>
        /// Begins the fluent registration process for a new service definition.
        /// </summary>
        /// <typeparam name="TDefinition">The type of the service definition.</typeparam>
        IServiceRegistrationBuilder<TDefinition> Register<TDefinition>()
            where TDefinition : IServiceDefinition;

        /// <summary>
        /// Gets all finalized service descriptors.
        /// </summary>
        IReadOnlyCollection<IServiceDescriptor> GetAll();

        /// <summary>
        /// Tries to get a service descriptor by its unique definition identifier.
        /// </summary>
        bool TryGet(string definitionId, out IServiceDescriptor? descriptor);
    }
}
