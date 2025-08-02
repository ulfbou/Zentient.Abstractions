// <copyright file="IHasCategory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Relations;

namespace Zentient.Abstractions.Common
{
    /// <summary>Represents an entity or definition that has a category.</summary>
    public interface IHasCategory
    {
        /// <summary>Gets the category name of the entity or definition.</summary>
        /// <value>A non-null, non-empty string representing the category name.</value>
        string CategoryName { get; }

        /// <summary>
        /// Gets the category object that this entity or definition belongs to,
        /// providing a higher-level classification.
        /// </summary>
        /// <value>
        /// The <see cref="IRelationCategory"/> instance representing the category,
        /// or <see langword="null" /> if not categorized.
        /// </value>
        IRelationCategory? Category { get; }
    }
}
