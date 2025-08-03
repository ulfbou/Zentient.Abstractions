// <copyright file="IRelationMetadataProvider.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Relations.Providers
{
    /// <summary>
    /// Provides metadata associated with <see cref="IRelationDefinition"/>s, supporting rich introspection,
    /// developer tooling, UI generation, and documentation scenarios.
    /// </summary>
    /// <remarks>
    /// This provider abstracts metadata access from <see cref="IRelationDefinition"/> implementations, enabling
    /// external description, categorization, and tagging without polluting the domain contracts.
    /// It can be used in reflection-free systems, dynamic dashboards, policy configurators, or code generators
    /// to surface relational semantics to both humans and machines. It promotes a separation of concerns
    /// between the definition of a relation and its descriptive attributes.
    /// </remarks>
    public interface IRelationMetadataProvider
    {
        /// <summary>
        /// Gets the human-readable display name of the specified <see cref="IRelationDefinition"/>.
        /// </summary>
        /// <param name="relationDefinitionType">The <see cref="Type"/> implementing <see cref="IRelationDefinition"/>.</param>
        /// <returns>The display name, or <see langword="null"/> if not available.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationDefinitionType"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationDefinitionType"/> does not implement <see cref="IRelationDefinition"/>.</exception>
        string? GetDisplayName(Type relationDefinitionType);

        /// <summary>
        /// Gets a short summary or description of the purpose of the specified <see cref="IRelationDefinition"/>.
        /// </summary>
        /// <param name="relationDefinitionType">The <see cref="Type"/> implementing <see cref="IRelationDefinition"/>.</param>
        /// <returns>The description text, or <see langword="null"/> if not available.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationDefinitionType"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationDefinitionType"/> does not implement <see cref="IRelationDefinition"/>.</exception>
        string? GetDescription(Type relationDefinitionType);

        /// <summary>
        /// Gets a machine-readable category or classification for the specified <see cref="IRelationDefinition"/>.
        /// </summary>
        /// <param name="relationDefinitionType">The <see cref="Type"/> implementing <see cref="IRelationDefinition"/>.</param>
        /// <returns>The category string, or <see langword="null"/> if not defined.</returns>
        /// <remarks>
        /// This category can be used for logical grouping in UIs, filtering, or automated processing pipelines.
        /// Examples: "Messaging", "API", "BusinessProcess".
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationDefinitionType"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationDefinitionType"/> does not implement <see cref="IRelationDefinition"/>.</exception>
        string? GetCategory(Type relationDefinitionType);

        /// <summary>
        /// Gets additional named metadata values associated with the specified <see cref="IRelationDefinition"/>.
        /// </summary>
        /// <param name="relationDefinitionType">The <see cref="Type"/> implementing <see cref="IRelationDefinition"/>.</param>
        /// <returns>
        /// An <see cref="IMetadata"/> instance containing the metadata, never <see langword="null"/>.
        /// </returns>
        /// <remarks>
        /// This allows for arbitrary, extensible metadata to be associated with a relation,
        /// providing rich context for advanced tooling or custom logic.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationDefinitionType"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationDefinitionType"/> does not implement <see cref="IRelationDefinition"/>.</exception>
        IMetadata GetMetadata(Type relationDefinitionType); // Changed return type to IMetadata
    }
}
