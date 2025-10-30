// <copyright file="IValue.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Marker indicating the concept represents a value-like concept (literal or value object).
    /// Values are defined by their content rather than by stable identity.
    /// </summary>
    public interface IValue : IConcept { }
}
