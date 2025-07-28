// <copyright file="IFormatter{in TIn, out TOut}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Formatters.Registry
{
    /// <summary>Represents a registry of available formatter types.</summary>
    public interface IFormatterRegistry
    {
        /// <summary>Gets all registered formatter type definitions.</summary>
        /// <returns>An enumeration of all available formatter types.</returns>
        IEnumerable<IFormatterType> GetAll();

        /// <summary>Attempts to retrieve a formatter type definition by its unique identifier.</summary>
        /// <param name="id">The identifier of the formatter type.</param>
        /// <param name="type">When found, the resulting formatter type.</param>
        /// <returns>True if found; otherwise, false.</returns>
        bool TryGet(string id, out IFormatterType? type);
    }
}
