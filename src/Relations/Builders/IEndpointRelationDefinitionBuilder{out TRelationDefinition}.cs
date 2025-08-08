﻿// <copyright file="IEndpointRelationDefinitionBuilder{out TRelationDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Builders;
using Zentient.Abstractions.Endpoints.Definitions;
using Zentient.Abstractions.Endpoints.Relations;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Relations.Builders
{
    /// <summary>Specialized builder for endpoint relations, exposing severity.</summary>
    /// <typeparam name="TRelationDefinition">The specific type of endpoint relation being built.</typeparam>
    public interface IEndpointRelationDefinitionBuilder<out TRelationDefinition>
        : ITypeDefinitionBuilder<TRelationDefinition>
        where TRelationDefinition : IEndpointRelationDefinition // Assuming IEndpointRelationDefinition now exists and inherits IRelationDefinition
    {
        /// <summary>Sets the error severity associated with this endpoint relation.</summary>
        /// <param name="severity"> The severity level to assign.</param>
        /// <returns> The current builder instance for fluent chaining.</returns>
        /// <remarks>
        /// This property is crucial for defining the impact or criticality of an endpoint relationship,
        /// enabling scenarios such as automated alerts, logging prioritization, or policy enforcement.
        /// For example, a "requires-authentication" relation might have a high severity if violated.
        /// </remarks>
        IEndpointRelationDefinitionBuilder<TRelationDefinition> WithSeverity(ErrorSeverity severity);

        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithId(string id);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithName(string name);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithVersion(string version);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithDescription(string description);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithDisplayName(string displayName);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithCategory(string category);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithMetadata(string key, object? value);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithMetadata(IMetadata metadata);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithRelation(IRelationDefinition relation, bool allowDuplicates = false);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithRelations(IEnumerable<IRelationDefinition>? relations, bool clearExisting = true);
        /// <inheritdoc />
        new IEndpointRelationDefinitionBuilder<TRelationDefinition> WithTimestamp(DateTimeOffset timestamp); // Added after ITypeDefinitionBuilder update

        /// <inheritdoc />
        new TRelationDefinition Build();
    }
}
