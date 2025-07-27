// <copyright file="IRelationType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Relations
{
    /// <summary>
    /// Represents a fundamental relationship type that can be shared between different
    /// categories of abstractions (e.g., CodeTypes, ContextTypes).
    /// </summary>
    /// <remarks>
    /// This marker interface allows expressing that certain codes and contexts belong to a common
    /// logical domain or concern, facilitating sophisticated, relationship-aware abstractions.
    /// </remarks>
    public interface IRelationType : ITypeDefinition { }
}
