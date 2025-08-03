// <copyright file="IRelationCategory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Relations
{
    /// <summary>
    /// Represents a high-level classification or domain for <see cref="IRelationDefinition"/> instances.
    /// This helps categorize and organize relations themselves, preventing them from becoming an undifferentiated list.
    /// </summary>
    /// <remarks>
    /// Examples: "BusinessDomain", "TechnicalConcern", "Security", "Infrastructure".
    /// </remarks>
    public interface IRelationCategory
    {
        /// <summary>Gets the unique identifier for this relation category (e.g., "BusinessDomain").</summary>
        string Id { get; }

        /// <summary>Gets the human-readable name of the relation category (e.g., "Business Domain").</summary>
        string Name { get; }

        /// <summary>Gets a brief description of the purpose or scope of this relation category.</summary>
        string Description { get; }
    }
}
