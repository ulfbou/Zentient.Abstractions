// <copyright file="ITyped.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Marks a concept that exposes its underlying CLR type for reflective or diagnostic purposes.
    /// </summary>
    public interface ITyped : IConcept
    {
        /// <summary>
        /// Gets the CLR type that this concept represents or is associated with.
        /// </summary>
        System.Type ConceptualType { get; }
    }
}
