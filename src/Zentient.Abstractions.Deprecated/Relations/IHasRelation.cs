// <copyright file="IHasRelation.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Relations
{
    /// <summary>Represents an entity that has an associated relation type and relation category.</summary>
    public interface IHasRelation
    {
        /// <summary>
        /// Gets a read-only collection of <see cref="IRelationDefinition"/>s that this error type belongs to.
        /// These relations define the logical domains or cross-cutting concerns associated with this error.
        /// </summary>
        IReadOnlyCollection<IRelationDefinition> Relations { get; }
    }
}
