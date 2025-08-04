// <copyright file="IDefinitionCatalog.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Registration
{
    /// <summary>A generic registry for all definitions, allowing for broad introspection.</summary>
    public interface IDefinitionCatalog
    {
        /// <summary>Retrieves all definitions.</summary>
        /// <returns>A read-only collection of all definitions.</returns>
        Task<IReadOnlyCollection<IDefinition>> GetAll();

        /// <summary>Retrieves all definitions that implement a specific type.</summary>
        /// <typeparam name="TDefinition">The definition type to filter by.</typeparam>
        /// <returns>A read-only collection of definitions that match the specified type.</returns>
        Task<IReadOnlyCollection<TDefinition>> GetByType<TDefinition>()
            where TDefinition : IDefinition;
    }
}
