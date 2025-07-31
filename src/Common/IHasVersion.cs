// <copyright file="IHasVersion.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common
{
    /// <summary>Represents an entity or definition that is versioned.</summary>
    /// <remarks>
    /// This interface provides a way to specify the version of an abstraction,
    /// particularly useful for schema evolution, contract management, or compatibility checks.
    /// The version format is expected to be a string (e.g., semantic versioning).
    /// </remarks>
    public interface IHasVersion
    {
        /// <summary>Gets the version of the entity or definition.</summary>
        /// <value>A non-null, non-empty string representing the version.</value>
        string Version { get; }
    }
}
