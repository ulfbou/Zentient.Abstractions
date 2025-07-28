using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Endpoints.Relations;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Relations.Builders
{
    /// <summary>Fluent builder for creating immutable IRelationType instances.</summary>
    /// <typeparam name="TRelationType">The specific type of relation type being built.</typeparam>
    public interface IRelationTypeBuilder<out TRelationType>
        where TRelationType : IRelationType
    {
        /// <summary>Sets the unique identifier of the relation type.</summary>
        /// <param name="id">The unique identifier string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="id"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="id"/> is empty or whitespace.</exception>
        IRelationTypeBuilder<TRelationType> WithId(string id);

        /// <summary>Sets the logical name of the relation type.</summary>
        /// <param name="name">The logical name string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is empty or whitespace.</exception>
        IRelationTypeBuilder<TRelationType> WithName(string name);

        /// <summary>Sets the version string for the relation type.</summary>
        /// <param name="version">The version string, typically in semantic versioning format.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="version"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="version"/> is empty or whitespace.</exception>
        IRelationTypeBuilder<TRelationType> WithVersion(string version);

        /// <summary>Sets the human‐readable description.</summary>
        /// <param name="description">The description string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="description"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="description"/> is empty or whitespace.</exception>
        IRelationTypeBuilder<TRelationType> WithDescription(string description);

        /// <summary>Sets a display name for UI or documentation surfaces.</summary>
        /// <param name="displayName">The display name string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="displayName"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="displayName"/> is empty or whitespace.</exception>
        IRelationTypeBuilder<TRelationType> WithDisplayName(string displayName);

        /// <summary>Assigns a category to group related relations together.</summary>
        /// <param name="category">The category string.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="category"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="category"/> is empty or whitespace.</exception>
        IRelationTypeBuilder<TRelationType> WithCategory(string category);

        /// <summary>Adds or replaces a metadata tag by key.</summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The value to associate with the key. Can be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key"/> or <paramref name="value"/> is empty or whitespace.</exception>
        IRelationTypeBuilder<TRelationType> WithMetadata(string key, object? value);

        /// <summary>Merges an existing metadata object into this relation type.</summary>
        /// <param name="metadata">The metadata object to merge.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="metadata"/> is null.</exception>
        IRelationTypeBuilder<TRelationType> WithMetadata(IMetadata metadata);

        /// <summary>Finalizes construction and returns a fully‐initialized relation type.</summary>
        /// <returns>A new instance of the specified relation type.</returns>
        /// <exception cref="ValidationException">Thrown if any required properties are not set or invalid.</exception>
        TRelationType Build();
    }
}
