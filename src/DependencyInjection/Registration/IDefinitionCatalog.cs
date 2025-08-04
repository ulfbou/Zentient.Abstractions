// <copyright file="IDefinitionCatalog.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.DependencyInjection.Registration
{
    /// <summary>
    /// A generic registry for all definitions, allowing for broad introspection.
    /// </summary>
    public interface IDefinitionCatalog
    {
        /// <summary>Retrieves all definitions.</summary>
        Task<IReadOnlyCollection<IDefinition>> GetAll();

        /// <summary>Retrieves all definitions that implement a specific type.</summary>
        /// <typeparam name="TDefinition">The definition type to filter by.</typeparam>
        Task<IReadOnlyCollection<TDefinition>> GetByType<TDefinition>() where TDefinition : IDefinition;
    }
}
