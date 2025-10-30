// <copyright file="IIdentifiable.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Marks a concept that exposes a stable, machine-readable identity.
    /// Implementations should provide a unique identifier suitable for addressing and lookup.
    /// </summary>
    public interface IIdentifiable : IConcept { }
}
