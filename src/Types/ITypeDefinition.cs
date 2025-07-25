// <copyright file="ITypeDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// The foundational interface for defining any type or category within the system. 
    /// Provides common metadata for identification and description.
    /// </summary>
    public interface ITypeDefinition
    {
        /// <summary>Gets a unique identifier for the type definition.</summary>
        /// <value>A unique string identifier, never <see langword="null" /> or empty.</value>
        string Id { get; }

        /// <summary>Gets the human-readable name of the type definition.</summary>
        /// <value>A string representing the name, never <see langword="null" /> or empty.</value>
        string Name { get; }

        /// <summary>Gets the version of the type definition.</summary>
        /// <value>A string representing the version, never <see langword="null" /> or empty.</value>
        string Version { get; }

        /// <summary>Gets a detailed description of the type definition.</summary>
        /// <value>A string providing a description, never <see langword="null" /> or empty.</value>
        string Description { get; }
    }
}
