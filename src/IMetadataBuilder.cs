// <copyright file="IMetadataBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zentient.Abstractions
{
    /// <summary>Provides a fluent API for building immutable <see cref="IMetadata"/> instances.</summary>
    public interface IMetadataBuilder
    {
        /// <summary>
        /// Adds or updates a tag in the metadata being built.
        /// </summary>
        /// <typeparam name="TValue">The type of the tag value.</typeparam>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value to associate with the key.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for chaining.</returns>
        IMetadataBuilder WithTag<TValue>(string key, TValue value);

        /// <summary>
        /// Adds or updates multiple tags from a collection of key-value pairs.
        /// </summary>
        /// <param name="tags">The tags to add or update.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for chaining.</returns>
        IMetadataBuilder WithTags(IEnumerable<KeyValuePair<string, object?>> tags);

        /// <summary>
        /// Removes a tag from the metadata being built.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for chaining.</returns>
        IMetadataBuilder WithoutTag(string key);

        /// <summary>
        /// Removes multiple tags from the metadata being built.
        /// </summary>
        /// <param name="keys">The keys of the tags to remove.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for chaining.</returns>
        IMetadataBuilder WithoutTags(IEnumerable<string> keys);

        /// <summary>
        /// Merges another <see cref="IMetadata"/> instance into the metadata being built.
        /// Tags from the merged instance will overwrite existing tags.
        /// </summary>
        /// <param name="other">The <see cref="IMetadata"/> instance to merge.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for chaining.</returns>
        IMetadataBuilder Merge(IMetadata other);

        /// <summary>
        /// Conditionally adds or updates a tag if the predicate is true.
        /// </summary>
        /// <typeparam name="TValue">The type of the tag value.</typeparam>
        /// <param name="condition">The condition that must be true for the tag to be added/updated.</param>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value to associate with the key.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for chaining.</returns>
        IMetadataBuilder WithTagIf<TValue>(bool condition, string key, TValue value);

        /// <summary>
        /// Conditionally adds or updates a tag if the predicate is true, using a value factory.
        /// </summary>
        /// <typeparam name="TValue">The type of the tag value.</typeparam>
        /// <param name="condition">The condition that must be true for the tag to be added/updated.</param>
        /// <param name="key">The key for the tag.</param>
        /// <param name="valueFactory">A factory function to produce the value if the condition is true.</param>
        /// <returns>The current <see cref="IMetadataBuilder"/> instance for chaining.</returns>
        IMetadataBuilder WithTagIf<TValue>(bool condition, string key, Func<TValue> valueFactory);

        /// <summary>
        /// Builds the immutable <see cref="IMetadata"/> instance from the current state of the builder.
        /// </summary>
        /// <returns>An immutable <see cref="IMetadata"/> instance.</returns>
        IMetadata Build();
    }
}
