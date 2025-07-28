// <copyright file="IRelationMetadataProvider.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Relations
{
    /// <summary>
    /// Provides metadata associated with <see cref="IRelationType"/>s, supporting rich introspection,
    /// developer tooling, UI generation, and documentation scenarios.
    /// </summary>
    /// <remarks>
    /// This provider abstracts metadata access from <see cref="IRelationType"/> implementations, enabling
    /// external description, categorization, and tagging without polluting the domain contracts.
    /// It can be used in reflection-free systems, dynamic dashboards, policy configurators, or code generators
    /// to surface relational semantics to both humans and machines. It promotes a separation of concerns
    /// between the definition of a relation and its descriptive attributes.
    /// </remarks>
    public interface IRelationMetadataProvider
    {
        /// <summary>
        /// Gets the human-readable display name of the specified <see cref="IRelationType"/>.
        /// </summary>
        /// <param name="relationType">The <see cref="Type"/> implementing <see cref="IRelationType"/>.</param>
        /// <returns>The display name, or <see langword="null"/> if not available.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationType"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationType"/> does not implement <see cref="IRelationType"/>.</exception>
        string? GetDisplayName(Type relationType);

        /// <summary>
        /// Gets a short summary or description of the purpose of the specified <see cref="IRelationType"/>.
        /// </summary>
        /// <param name="relationType">The <see cref="Type"/> implementing <see cref="IRelationType"/>.</param>
        /// <returns>The description text, or <see langword="null"/> if not available.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationType"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationType"/> does not implement <see cref="IRelationType"/>.</exception>
        string? GetDescription(Type relationType);

        /// <summary>
        /// Gets a machine-readable category or classification for the specified <see cref="IRelationType"/>.
        /// </summary>
        /// <param name="relationType">The <see cref="Type"/> implementing <see cref="IRelationType"/>.</param>
        /// <returns>The category string, or <see langword="null"/> if not defined.</returns>
        /// <remarks>
        /// This category can be used for logical grouping in UIs, filtering, or automated processing pipelines.
        /// Examples: "Messaging", "API", "BusinessProcess".
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationType"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationType"/> does not implement <see cref="IRelationType"/>.</exception>
        string? GetCategory(Type relationType);

        /// <summary>
        /// Gets additional named metadata values associated with the specified <see cref="IRelationType"/>.
        /// </summary>
        /// <param name="relationType">The <see cref="Type"/> implementing <see cref="IRelationType"/>.</param>
        /// <returns>
        /// A read-only dictionary of metadata keys and string values, or an empty dictionary if none are registered.
        /// </returns>
        /// <remarks>
        /// This allows for arbitrary, extensible metadata to be associated with a relation,
        /// providing rich context for advanced tooling or custom logic. The keys and values
        /// are expected to be strings for simplicity and broad compatibility.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relationType"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="relationType"/> does not implement <see cref="IRelationType"/>.</exception>
        IReadOnlyDictionary<string, string> GetMetadata(Type relationType);
    }
}
