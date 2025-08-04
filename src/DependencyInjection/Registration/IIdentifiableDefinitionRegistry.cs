// <copyright file="IIdentifiableDefinitionRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.DependencyInjection.Registration
{
    /// <summary>
    /// A specialized registry for definitions that are uniquely identifiable.
    /// </summary>
    public interface IIdentifiableDefinitionRegistry
    {
        /// <summary>
        /// Retrieves a definition by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the definition.</param>
        Task<IIdentifiableDefinition?> GetById(string id);

        /// <summary>
        /// Registers an identifiable definition.
        /// </summary>
        /// <param name="def">The definition to register.</param>
        Task Register(IIdentifiableDefinition def);
    }
}
