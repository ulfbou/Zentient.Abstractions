// <copyright file="ITrait.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Marker interface for orthogonal capabilities or mixins that can be applied to concepts.
    /// Use traits to indicate additional non-hierarchical characteristics (for example, versioned or stateful).
    /// </summary>
    public interface ITrait : IConcept { }
}
