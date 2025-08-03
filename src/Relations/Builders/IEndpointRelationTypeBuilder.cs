// <copyright file="IEndpoinTRelationDefinitionBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Builders;
using Zentient.Abstractions.Endpoints.Relations;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Relations.Builders
{
    /// <summary>Specialized builder for endpoint relations, exposing severity.</summary>
    /// <typeparam name="TRelationDefinition">The specific type of endpoint relation being built.</typeparam>
    public interface IEndpoinTRelationDefinitionBuilder<out TRelationDefinition>
        : ITypeDefinitionBuilder<TRelationDefinition>
        where TRelationDefinition : IEndpoinTRelationDefinition
    {
        /// <summary>Sets the error severity associated with this endpoint relation.</summary>
        /// <param name="severity"> The severity level to assign.</param>
        /// <returns> The current builder instance for fluent chaining.</returns>
        IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithSeverity(ErrorSeverity severity);

        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithId(string id);
        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithName(string name);
        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithVersion(string version);
        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithDescription(string description);
        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithDisplayName(string displayName);
        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithCategory(string category); // This is for IHasCategory.Category (string)
        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithMetadata(string key, object? value);
        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithMetadata(IMetadata metadata);
        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithRelation(IRelationDefinition relation, bool allowDuplicates = false);
        /// <inheritdoc />
        new IEndpoinTRelationDefinitionBuilder<TRelationDefinition> WithRelations(IEnumerable<IRelationDefinition>? relations, bool clearExisting = true);

        /// <inheritdoc />
        new TRelationDefinition Build();
    }
}
