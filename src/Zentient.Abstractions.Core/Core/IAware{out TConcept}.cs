// <copyright file="IAware{out TConcept}.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Generic awareness bridge; used to associate a concept instance with another concept instance.
    /// Implementations expose the referred concept for introspection or composition.
    /// </summary>
    /// <typeparam name="TConcept">The type of the concept being referenced.</typeparam>
    public interface IAware<out TConcept> where TConcept : IConcept
    {
        /// <summary>
        /// Gets the referenced concept instance.
        /// </summary>
        TConcept Concept { get; }
    }
}
