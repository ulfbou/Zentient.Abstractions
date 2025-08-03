// <copyright file="IRelationDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.Relations.Builders;

namespace Zentient.Abstractions.Relations.Definitions
{
    /// <summary>
    /// Represents a fundamental relationship type that can be shared between different
    /// categories of abstractions (e.g., CodeTypes, ContextTypes).
    /// </summary>
    /// <remarks>
    /// This interface allows expressing that certain codes and contexts belong to a common
    /// logical domain or concern, facilitating sophisticated, relationship-aware abstractions.
    /// It also supports hierarchical modeling of relations via a parent link.
    /// </remarks>
    public interface IRelationDefinition : ITypeDefinition, IHasParent<IRelationDefinition>
    { }
}
