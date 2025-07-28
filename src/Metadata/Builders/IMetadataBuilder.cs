// <copyright file="IMetadataBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zentient.Abstractions.Metadata.Builders
{
    /// <summary>
    /// Provides a mutable fluent API for constructing immutable <see cref="IMetadata"/> instances.
    /// </summary>
    /// <remarks>
    /// This builder pattern enables the step-by-step construction of immutable metadata collections.
    /// It's the designated interface for creating and accumulating metadata entries before
    /// an immutable <see cref="IMetadata"/> object is finalized via the <see cref="Build"/> method.
    /// </remarks>
    public interface IMetadataBuilder
    {
        /// <summary>
        /// Adds a metadata value for the specified key. If the key already exists, its value is updated.
        /// </summary>
        /// <param name="key">The key of the metadata entry. Must not be null or empty.</param>
        /// <param name="value">The value to associate with the key. Can be <see langword="null"/>.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key"/> is empty or whitespace.</exception>
        IMetadataBuilder AddTag(string key, object? value);

        /// <summary>
        /// Adds a set of metadata entries from another <see cref="IMetadataReader"/> instance.
        /// If a key already exists, its value is updated with the value from the provided instance.
        /// </summary>
        /// <param name="metadata">The <see cref="IMetadataReader"/> instance containing metadata entries to add. Must not be <see langword="null"/>.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="metadata"/> is <see langword="null"/>.</exception>
        IMetadataBuilder AddTags(IMetadataReader metadata);

        // Predicate-based methods for adding tags

        /// <summary>Updates the metadata entries that match the specified predicate.</summary>
        /// <param name="predicate">A function that defines the condition for updating entries. Must not be <see langword="null"/>.</param>
        /// <param name="updateAction">A function that defines how to update the entries that match the predicate. Must not be <see langword="null"/>.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="predicate"/> or <paramref name="updateAction"/> is <see langword="null"/>.</exception>
        public IMetadataBuilder UpdateTags(Func<string, bool> predicate, Action<string, object?> updateAction);

        /// <summary>Removes a metadata entry with the specified key.</summary>
        /// <param name="key">The key of the metadata entry to remove. Must not be null or empty.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key"/> is empty or whitespace.</exception>
        IMetadataBuilder RemoveTag(string key);

        /// <summary>Removes all metadata entries with keys that match the specified <paramref name="keys"/>.</summary>
        /// <param name="keys">A collection of keys to remove. Must not be <see langword="null"/>.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="keys"/> is <see langword="null"/>.</exception>
        IMetadataBuilder RemoveTags(IEnumerable<string> keys);

        /// <summary>Removes all metadata entries that match the specified predicate.</summary>
        /// <param name="predicate">A function that defines the condition for removal. Must not be <see langword="null"/>.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="predicate"/> is <see langword="null"/>.</exception>
        public IMetadataBuilder RemoveTags(Func<string, bool> predicate);

        /// <summary>
        /// Merges the provided metadata into the current builder's state.
        /// Existing keys in the builder will be overwritten by keys from the <paramref name="metadata"/> instance.
        /// </summary>
        /// <param name="metadata">The <see cref="IMetadataReader"/> instance to merge. Must not be null.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="metadata"/> is <see langword="null"/>.</exception>
        IMetadataBuilder Merge(IMetadataReader metadata);

        /// <summary>
        /// Builds an immutable <see cref="IMetadata"/> instance from the currently accumulated entries.
        /// </summary>
        /// <returns>A new, immutable <see cref="IMetadata"/> instance.</returns>
        IMetadata Build();
    }
}
