// <copyright file="IHasRelation.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Relations
{
    /// <summary>Represents an entity that has an associated relation type and relation category.</summary>
    public interface IHasRelation
    {
        /// <summary>
        /// Gets a read-only collection of <see cref="IRelationType"/>s that this error type belongs to.
        /// These relations define the logical domains or cross-cutting concerns associated with this error.
        /// </summary>
        IReadOnlyCollection<IRelationType> Relations { get; }
    }
}
