// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

// Zentient.Abstractions/IMetadataFactory.cs (Corrected Elevated to 3.0.0 - Next Level)
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Zentient.Abstractions
{
    /// <summary>
    /// Factory interface for creating <see cref="IMetadata"/> instances,
    /// including fluent building capabilities.
    /// </summary>
    public interface IMetadataFactory
    {
        /// <summary>Gets an empty, immutable <see cref="IMetadata"/> instance.</summary>
        /// <value>The empty metadata instance.</value>
        IMetadata Empty { get; }

        /// <summary>
        /// Creates a new <see cref="IMetadata"/> instance from an initial collection of key-value pairs.
        /// This is the most efficient means to initialize metadata with multiple tags.
        /// </summary>
        /// <param name="initialTags">
        /// An optional collection of key-value pairs to initialize the metadata.
        /// If <c>null</c>, the metadata will be empty.
        /// </param>
        /// <returns>A new <see cref="IMetadata"/> instance containing the provided tags.</returns>
        IMetadata Create(IEnumerable<KeyValuePair<string, object?>>? initialTags = null);

        /// <summary>Creates a new <see cref="IMetadata"/> instance with a single tag.</summary>
        /// <typeparam name="TValue">The type of the tag value.</typeparam>
        /// <param name="key">The key of the tag.</param>
        /// <param name="value">The value of the tag.</param>
        /// <returns>A new <see cref="IMetadata"/> instance containing the single tag.</returns>
        IMetadata Create<TValue>(string key, TValue value);

        /// <summary>Starts building a new <see cref="IMetadata"/> instance using a fluent API.</summary>
        /// <returns>An <see cref="IMetadataBuilder"/> instance for fluent construction.</returns>
        IMetadataBuilder CreateBuilder();

        /// <summary>
        /// Starts building a new <see cref="IMetadata"/> instance using a fluent API, 
        /// based on an existing <see cref="IMetadata"/> instance.
        /// This allows for extending or modifying existing metadata.
        /// </summary>
        /// <param name="existingMetadata">The existing metadata to base the builder on.</param>
        /// <returns>
        /// An <see cref="IMetadataBuilder"/> instance pre-populated with the tags from the existing metadata.
        /// This allows for extending or modifying existing metadata.
        /// </returns>
        IMetadataBuilder CreateBuilderFrom(IMetadata existingMetadata)
            => CreateBuilder().Merge(existingMetadata);
    }
}
