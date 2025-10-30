// <copyright file="IComposable.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Represents a composable aggregate of smaller conceptual parts.
    /// Implementations should expose the constituent parts in a stable iteration order if order is meaningful.
    /// </summary>
    public interface IComposable
    {
        /// <summary>
        /// Gets the sequence of conceptual parts that compose this instance.
        /// </summary>
        IEnumerable<IConcept> Parts { get; }
    }
}
