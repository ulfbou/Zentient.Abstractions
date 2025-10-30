// <copyright file="IDescribed.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Provides an optional, extended description that documents the purpose or semantics of the concept.
    /// Implementers should use this property to provide maintainable, discoverable documentation.
    /// </summary>
    public interface IDescribed : IConcept
    {
        /// <summary>
        /// Gets a longer-form description of the concept, or <c>null</c> if unspecified.
        /// </summary>
        string? Description { get; }
    }
}
