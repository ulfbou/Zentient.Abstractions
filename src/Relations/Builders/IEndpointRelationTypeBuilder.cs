// <copyright file="IEndpointRelationTypeBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Builders;
using Zentient.Abstractions.Endpoints.Relations;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Relations.Builders
{
    /// <summary>Specialized builder for endpoint relations, exposing severity.</summary>
    /// <typeparam name="TRelationType">The specific type of endpoint relation being built.</typeparam>
    public interface IEndpointRelationTypeBuilder<out TRelationType>
        : ITypeDefinitionBuilder<TRelationType>
        where TRelationType : IEndpointRelationType
    {
        /// <summary>Sets the error severity associated with this endpoint relation.</summary>
        /// <param name="severity"> The severity level to assign.</param>
        /// <returns> The current builder instance for fluent chaining.</returns>
        IEndpointRelationTypeBuilder<TRelationType> WithSeverity(ErrorSeverity severity);

        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithId(string id);
        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithName(string name);
        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithVersion(string version);
        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithDescription(string description);
        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithDisplayName(string displayName);
        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithCategory(string category); // This is for IHasCategory.Category (string)
        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithMetadata(string key, object? value);
        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithMetadata(IMetadata metadata);
        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithRelation(IRelationType relation, bool allowDuplicates = false);
        /// <inheritdoc />
        new IEndpointRelationTypeBuilder<TRelationType> WithRelations(IEnumerable<IRelationType>? relations, bool clearExisting = true);

        /// <inheritdoc />
        new TRelationType Build();
    }
}
