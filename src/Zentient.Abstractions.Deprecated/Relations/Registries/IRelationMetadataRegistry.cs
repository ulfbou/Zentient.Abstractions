// <copyright file="IRelationMetadataRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Relations.Definitions;
using Zentient.Abstractions.Relations.Providers;

namespace Zentient.Abstractions.Relations.Registries
{
    /// <summary>
    /// Provides a mutable registry for registering and updating metadata associated with <see cref="IRelationDefinition"/>s.
    /// </summary>
    /// <remarks>
    /// This interface complements <see cref="IRelationMetadataProvider"/> by supporting metadata registration
    /// during application startup, configuration phases, or plugin/module loading.
    /// It does not mandate runtime mutability, but enables it where needed — e.g., for dynamically loaded relations.
    /// It centralizes the management of descriptive information for relations, making them discoverable and extensible.
    /// </remarks>
    public interface IRelationMetadataRegistry
    {
        /// <summary>
        /// Registers or updates the display name for a given <see cref="IRelationDefinition"/>.
        /// </summary>
        /// <param name="relationDefinitionType">The <see cref="Type"/> implementing <see cref="IRelationDefinition"/>.</param>
        /// <param name="displayName">The human-readable display name to associate with the relation. Cannot be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationDefinitionType"/> or <paramref name="displayName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationDefinitionType"/> does not implement <see cref="IRelationDefinition"/>.</exception>
        /// <remarks>
        /// This allows for user-friendly names to be associated with technical relation types,
        /// useful for UI elements or generated documentation.
        /// </remarks>
        void SetDisplayName(Type relationDefinitionType, string displayName);

        /// <summary>
        /// Registers or updates the description for a given <see cref="IRelationDefinition"/>.
        /// </summary>
        /// <param name="relationDefinitionType">The <see cref="Type"/> implementing <see cref="IRelationDefinition"/>.</param>
        /// <param name="description">A summary or explanation of the relation’s purpose. Cannot be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationDefinitionType"/> or <paramref name="description"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationDefinitionType"/> does not implement <see cref="IRelationDefinition"/>.</exception>
        /// <remarks>
        /// Provides detailed context about the relation's semantic meaning and application.
        /// </remarks>
        void SetDescription(Type relationDefinitionType, string description);

        /// <summary>
        /// Registers or updates the category for a given <see cref="IRelationDefinition"/>.
        /// </summary>
        /// <param name="relationDefinitionType">The <see cref="Type"/> implementing <see cref="IRelationDefinition"/>.</param>
        /// <param name="category">A machine-readable category string for grouping or classification. Cannot be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationDefinitionType"/> or <paramref name="category"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationDefinitionType"/> does not implement <see cref="IRelationDefinition"/>.</exception>
        /// <remarks>
        /// Useful for organizational purposes in tools or for automated processing based on functional groupings.
        /// </remarks>
        void SetCategory(Type relationDefinitionType, string category);

        /// <summary>
        /// Registers or updates an additional named metadata key-value pair for a given <see cref="IRelationDefinition"/>.
        /// </summary>
        /// <param name="relationDefinitionType">The <see cref="Type"/> implementing <see cref="IRelationDefinition"/>.</param>
        /// <param name="key">The metadata key. Cannot be <see langword="null"/> or empty.</param>
        /// <param name="value">The metadata value to associate with the key. Can be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationDefinitionType"/> or <paramref name="key"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationDefinitionType"/> does not implement <see cref="IRelationDefinition"/>, or if <paramref name="key"/> is empty.</exception>
        /// <remarks>
        /// Allows for highly flexible and extensible metadata associations beyond the standard properties.
        /// Existing values for a key will be overwritten.
        /// </remarks>
        void SetMetadata(Type relationDefinitionType, string key, object? value); // Changed value type to object?

        /// <summary>
        /// Clears all registered metadata (display name, description, category, and additional metadata)
        /// for the specified <see cref="IRelationDefinition"/>.
        /// </summary>
        /// <param name="relationDefinitionType">The <see cref="Type"/> of the relation to remove all associated metadata from.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationDefinitionType"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationDefinitionType"/> does not implement <see cref="IRelationDefinition"/>.</exception>
        /// <remarks>
        /// Useful for resetting state, particularly in testing environments or when unloading dynamic modules.
        /// </remarks>
        void Clear(Type relationDefinitionType);
    }
}
