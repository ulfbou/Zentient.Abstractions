// <copyright file="IServiceRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Builders;
using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.DependencyInjection.Registration;

namespace Zentient.Abstractions.DependencyInjection
{
    /// <summary>
    /// Represents a registry that holds and manages all service descriptors in Zentient.
    /// </summary>
    public interface IServiceRegistry
    {
        /// <summary>Begins the fluent registration process for a new service definition.</summary>
        /// <typeparam name="TDefinition">The type of the service definition.</typeparam>
        /// <returns>A fluent builder for configuring the service registration.</returns>
        /// <remarks>
        /// The actual fluent builder type <see cref="IServiceRegistrationBuilder{TDefinition}"/>
        /// would be defined in a concrete implementation or a separate fluent API namespace.
        /// </remarks>
        IServiceRegistrationBuilder<TDefinition> Register<TDefinition>()
            where TDefinition : IServiceDefinition;

        /// <summary>Gets all finalized service descriptors.</summary>
        /// <returns>A read-only collection of all registered service descriptors.</returns>
        IReadOnlyCollection<IServiceDescriptor> GetAll();

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
    }
}
