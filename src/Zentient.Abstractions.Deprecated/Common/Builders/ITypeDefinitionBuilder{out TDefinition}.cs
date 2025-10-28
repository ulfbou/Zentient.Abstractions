// <copyright file="ITypeDefinitionBuilder{out TDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Relations;
using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Common.Builders
{
    /// <summary>
    /// Base fluent builder for creating immutable instances that implement <see cref="ITypeDefinition"/>.
    /// This interface provides common methods for setting fundamental type properties,
    /// associated metadata, and importantly, its semantic relations.
    /// </summary>
    /// <typeparam name="TDefinition">The specific type definition being built.</typeparam>
    public interface ITypeDefinitionBuilder<out TDefinition>
        where TDefinition : ITypeDefinition
    {
        /// <summary>Sets the unique identifier of the type definition.</summary>
        /// <param name="id">The unique identifier string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="id"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="id"/> is empty or whitespace.</exception>
        ITypeDefinitionBuilder<TDefinition> WithId(string id);

        /// <summary>Sets the logical name of the type definition.</summary>
        /// <param name="name">The logical name string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is empty or whitespace.</exception>
        ITypeDefinitionBuilder<TDefinition> WithName(string name);

        /// <summary>Sets the version string for the type definition.</summary>
        /// <param name="version">The version string, typically in semantic versioning format.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="version"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="version"/> is empty or whitespace.</exception>
        ITypeDefinitionBuilder<TDefinition> WithVersion(string version);

        /// <summary>Sets the human-readable description for the type definition.</summary>
        /// <param name="description">The description string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="description"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="description"/> is empty or whitespace.</exception>
        ITypeDefinitionBuilder<TDefinition> WithDescription(string description);

        /// <summary>Sets a display name for UI or documentation surfaces.</summary>
        /// <param name="displayName">The display name string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="displayName"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="displayName"/> is empty or whitespace.</exception>
        ITypeDefinitionBuilder<TDefinition> WithDisplayName(string displayName);

        /// <summary>Assigns a category to group related type definitions together.</summary>
        /// <param name="category">The category string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="category"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="category"/> is empty or whitespace.</exception>
        ITypeDefinitionBuilder<TDefinition> WithCategory(string category);

        /// <summary>Adds or replaces a metadata tag by key.</summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The value to associate with the key. Can be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key"/> or <paramref name="value"/> is empty or whitespace.</exception>
        ITypeDefinitionBuilder<TDefinition> WithMetadata(string key, object? value);

        /// <summary>Merges an existing metadata object into this type definition.</summary>
        /// <param name="metadata">The metadata object to merge.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="metadata"/> is null.</exception>
        ITypeDefinitionBuilder<TDefinition> WithMetadata(IMetadata metadata);

        /// <summary>
        /// Adds a single <see cref="IRelationDefinition"/> to the collection of relations this type definition belongs to.
        /// </summary>
        /// <param name="relation">The <see cref="IRelationDefinition"/> to associate. Must not be null.</param>
        /// <param name="allowDuplicates">
        /// If <see langword="true"/>, allows adding the same relation multiple times.
        /// If <see langword="false"/> (default), ensures the relation is added only once based on its Id.
        /// </param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relation"/> is null.</exception>
        ITypeDefinitionBuilder<TDefinition> WithRelation(IRelationDefinition relation, bool allowDuplicates = false);

        /// <summary>
        /// Sets the collection of <see cref="IRelationDefinition"/>s this type definition belongs to.
        /// </summary>
        /// <param name="relations">The collection of <see cref="IRelationDefinition"/>s. Can be null or empty.</param>
        /// <param name="clearExisting">
        /// If <see langword="true"/> (default), replaces any existing relations with the new collection.
        /// If <see langword="false"/>, adds the new relations to the existing ones (handling duplicates based on builder's internal logic).
        /// </param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        ITypeDefinitionBuilder<TDefinition> WithRelations(IEnumerable<IRelationDefinition>? relations, bool clearExisting = true);

        /// <summary>Sets the creation or last update timestamp for the type definition.</summary>
        /// <param name="timestamp">The <see cref="DateTimeOffset"/> representing the timestamp.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        ITypeDefinitionBuilder<TDefinition> WithTimestamp(DateTimeOffset timestamp);

        /// <summary>Finalizes construction and returns a fully-initialized type definition.</summary>
        /// <returns>A new instance of the specified type definition.</returns>
        /// <exception cref="InvalidOperationException">Thrown if any required properties (e.g., Id, Name) are not set or are invalid.</exception>
        TDefinition Build();
    }
}
