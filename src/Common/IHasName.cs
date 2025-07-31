// <copyright file="IHasName.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common
{
    /// <summary>Represents an entity or definition that possesses a human-readable name.</summary>
    /// <remarks>
    /// This name is typically a concise label that can be used for logging,
    /// debugging, or simple display purposes, distinguishing it from a potentially
    /// more complex 'DisplayName' or a programmatic 'Id'.
    /// </remarks>
    public interface IHasName
    {
        /// <summary>
        /// Gets the human-readable name of the entity or definition.
        /// </summary>
        /// <value>A non-null, non-empty string representing the name.</value>
        string Name { get; }
    }
}
