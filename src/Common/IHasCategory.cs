// <copyright file="IHasCategory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Relations;

namespace Zentient.Abstractions.Common
{
    /// <summary>Represents an entity or definition that has a category.</summary>
    public interface IHasCategory
    {
        /// <summary>Gets the category of the entity or definition.</summary>
        /// <value>A non-null, non-empty string representing the category.</value>
        string CategoryName { get; }

        /// <summary>
        /// Gets the category that this <see cref="IRelationType"/> belongs to, providing a higher-level classification
        /// for the relation itself (e.g., a "Login" relation might belong to the "BusinessDomain" category).
        /// </summary>
        IRelationCategory? Category { get; }
    }
}
