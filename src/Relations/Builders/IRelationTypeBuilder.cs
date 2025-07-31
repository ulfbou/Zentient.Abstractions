// <copyright file="IRelationTypeBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Builders;
using Zentient.Abstractions.Endpoints.Relations;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Metadata;

// Assuming ITypeDefinitionBuilder and common IHasX interfaces are in Zentient.Abstractions.Common.Builders
// and IRelationType, IRelationCategory are in Zentient.Abstractions.Relations

namespace Zentient.Abstractions.Relations.Builders
{
    /// <summary>
    /// Fluent builder for creating immutable <see cref="IRelationType"/> instances.
    /// This builder allows defining a relation's specific category and hierarchical parent.
    /// </summary>
    public interface IRelationTypeBuilder : ITypeDefinitionBuilder<IRelationType>
    {
        /// <summary>
        /// Sets the parent <see cref="IRelationType"/> for the relation being built.
        /// </summary>
        /// <param name="parent">The parent relation type. Must not be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="parent"/> is null.</exception>
        IRelationTypeBuilder WithParent(IRelationType parent);

        /// <summary>
        /// Sets the category for the <see cref="IRelationType"/> being built, using an <see cref="IRelationCategory"/> object.
        /// This represents the high-level classification of the relation itself.
        /// </summary>
        /// <param name="category">The <see cref="IRelationCategory"/> to assign. Must not be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="category"/> is null.</exception>
        IRelationTypeBuilder WithCategory(IRelationCategory category); // Renamed for clarity from previous WithCategory(string category)

        // Inherited methods from ITypeDefinitionBuilder<IRelationType>
        // Use 'new' keyword to correctly specialize the return type for fluent chaining
        /// <inheritdoc />
        new IRelationTypeBuilder WithId(string id);
        /// <inheritdoc />
        new IRelationTypeBuilder WithName(string name);
        /// <inheritdoc />
        new IRelationTypeBuilder WithVersion(string version);
        /// <inheritdoc />
        new IRelationTypeBuilder WithDescription(string description);
        /// <inheritdoc />
        new IRelationTypeBuilder WithDisplayName(string displayName);
        /// <inheritdoc />
        new IRelationTypeBuilder WithMetadata(string key, object? value);
        /// <inheritdoc />
        new IRelationTypeBuilder WithMetadata(IMetadata metadata);
        /// <inheritdoc />
        new IRelationTypeBuilder WithRelation(IRelationType relation, bool allowDuplicates = false);
        /// <inheritdoc />
        new IRelationTypeBuilder WithRelations(IEnumerable<IRelationType>? relations, bool clearExisting = true);

        /// <inheritdoc />
        new IRelationType Build();
    }
}
