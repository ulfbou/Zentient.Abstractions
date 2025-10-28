﻿// <copyright file="IRelationDefinitionBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>using Zentient.Abstractions.Common.Builders;
using Zentient.Abstractions.Endpoints.Relations;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Relations.Builders
{
    /// <summary>
    /// Fluent builder for creating immutable <see cref="IRelationDefinition"/> instances.
    /// This builder allows defining a relation's specific category and hierarchical parent.
    /// </summary>
    public interface IRelationDefinitionBuilder : ITypeDefinitionBuilder<IRelationDefinition>
    {
        /// <summary>
        /// Sets the parent <see cref="IRelationDefinition"/> for the relation being built.
        /// This establishes a hierarchical relationship, allowing for complex graph modeling
        /// where relations can be derived from or be a part of other relations.
        /// </summary>
        /// <param name="parent">The parent relation type. Must not be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="parent"/> is null.</exception>
        IRelationDefinitionBuilder WithParent(IRelationDefinition parent);

        /// <summary>
        /// Sets the category for the <see cref="IRelationDefinition"/> being built, using an <see cref="IRelationCategory"/> object.
        /// This represents the high-level classification of the relation itself, grouping it logically
        /// within the Zentient ecosystem (e.g., "Security Relations", "Data Flow Relations").
        /// </summary>
        /// <param name="category">The <see cref="IRelationCategory"/> to assign. Must not be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="category"/> is null.</exception>
        IRelationDefinitionBuilder WithCategory(IRelationCategory category);

        // Note: WithCategory(string category) is inherited and can be new'd if desired for specific builder return type,
        // otherwise the ITypeDefinitionBuilder<IRelationDefinition> version will be used.
        // Given the preference for IRelationCategory, this overload is more important.

        /// <inheritdoc />
        new IRelationDefinitionBuilder WithId(string id);
        /// <inheritdoc />
        new IRelationDefinitionBuilder WithName(string name);
        /// <inheritdoc />
        new IRelationDefinitionBuilder WithVersion(string version);
        /// <inheritdoc />
        new IRelationDefinitionBuilder WithDescription(string description);
        /// <inheritdoc />
        new IRelationDefinitionBuilder WithDisplayName(string displayName);
        /// <inheritdoc />
        new IRelationDefinitionBuilder WithMetadata(string key, object? value);
        /// <inheritdoc />
        new IRelationDefinitionBuilder WithMetadata(IMetadata metadata);
        /// <inheritdoc />
        new IRelationDefinitionBuilder WithRelation(IRelationDefinition relation, bool allowDuplicates = false);
        /// <inheritdoc />
        new IRelationDefinitionBuilder WithRelations(IEnumerable<IRelationDefinition>? relations, bool clearExisting = true);
        /// <inheritdoc />
        new IRelationDefinitionBuilder WithTimestamp(DateTimeOffset timestamp);

        /// <inheritdoc />
        new IRelationDefinition Build();
    }
}
