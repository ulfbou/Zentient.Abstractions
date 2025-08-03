// <copyright file="IMetadataBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Metadata.Readers;

namespace Zentient.Abstractions.Metadata.Builders
{
    /// <summary>
    /// Provides a fluent builder for constructing immutable <see cref="IMetadata"/> instances.
    /// This builder facilitates the incremental assembly of metadata key-value pairs
    /// into a robust, final metadata object.
    /// </summary>
    /// <remarks>
    /// Implementations of this builder are generally <see langword="not thread-safe"/>
    /// and are intended for single-threaded construction phases. Each call to <see cref="Build"/>
    /// is expected to return a new, immutable instance of <see cref="IMetadata"/> reflecting
    /// the current state of the builder. The builder instance itself remains usable
    /// after calling <see cref="Build"/>, allowing for further modifications and subsequent
    /// calls to <see cref="Build"/> to create different metadata instances.
    /// </remarks>
    public interface IMetadataBuilder
    {
        /// <summary>
        /// Adds or updates a single metadata tag with the specified key and value.
        /// If the key already exists, its value is updated; otherwise, a new tag is added.
        /// </summary>
        /// <param name="key">The unique key for the metadata tag. Cannot be null or whitespace.</param>
        /// <param name="value">The value to associate with the key. Can be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key"/> is empty or whitespace.</exception>
        IMetadataBuilder SetTag(string key, object? value);

        /// <summary>
        /// Adds or updates multiple metadata tags from a collection of key-value pairs.
        /// Existing tags with matching keys will be updated; new tags will be added.
        /// </summary>
        /// <param name="tags">The collection of key-value pairs representing the tags to add or update. Cannot be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="tags"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if any key within <paramref name="tags"/> is null, empty, or whitespace.</exception>
        IMetadataBuilder AddTags(IEnumerable<KeyValuePair<string, object?>> tags);

        /// <summary>
        /// Removes a single metadata tag identified by its key.
        /// If the key does not exist, no action is taken.
        /// </summary>
        /// <param name="key">The key of the tag to remove. Cannot be null or whitespace.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key"/> is empty or whitespace.</exception>
        IMetadataBuilder RemoveTag(string key);

        /// <summary>
        /// Removes multiple metadata tags based on their keys.
        /// </summary>
        /// <param name="keys">A collection of keys for the tags to remove. Cannot be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="keys"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if any key within <paramref name="keys"/> is null, empty, or whitespace.</exception>
        IMetadataBuilder RemoveTags(IEnumerable<string> keys);

        /// <summary>
        /// Removes multiple metadata tags that satisfy a specified predicate.
        /// </summary>
        /// <param name="predicate">A function to test each key-value pair for a condition. Tags for which the predicate returns true are removed. Cannot be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="predicate"/> is null.</exception>
        IMetadataBuilder RemoveTags(Func<string, object?, bool> predicate);

        /// <summary>
        /// Updates the values of existing metadata tags that satisfy a specified predicate.
        /// Only tags for which the predicate returns true will have their values updated by the <paramref name="updateFunction"/>.
        /// </summary>
        /// <param name="predicate">A function to test each key-value pair for a condition. Cannot be null.</param>
        /// <param name="updateFunction">A function to compute the new value for a tag. Takes the old key and value, returns the new value. Cannot be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="predicate"/> or <paramref name="updateFunction"/> is null.</exception>
        IMetadataBuilder UpdateTags(Func<string, object?, bool> predicate, Func<string, object?, object?> updateFunction);

        /// <summary>
        /// Merges metadata from another <see cref="IMetadataReader"/> instance into the current builder.
        /// Existing keys in the builder will be overwritten by values from the <paramref name="metadata"/> instance.
        /// New keys from <paramref name="metadata"/> will be added.
        /// </summary>
        /// <param name="metadata">The <see cref="IMetadataReader"/> instance whose tags are to be merged. Cannot be null.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="metadata"/> is null.</exception>
        IMetadataBuilder Merge(IMetadataReader metadata);

        /// <summary>
        /// Finalizes the construction and returns a new, immutable <see cref="IMetadata"/> instance
        /// representing the current state of the builder.
        /// </summary>
        /// <returns>A new, immutable <see cref="IMetadata"/> instance.</returns>
        IMetadata Build();
    }
}
