// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Metadata
{
    /// <summary>
    /// Represents an immutable collection of key-value metadata.
    /// </summary>
    /// <remarks>
    /// This interface provides a consistent and immutable contract for metadata
    /// across the Zentient ecosystem. It extends <see cref="IMetadataReader"/>
    /// for querying and provides functional methods for creating new instances
    /// with modified data, ensuring thread safety and predictability.
    /// </remarks>
    public interface IMetadata : IMetadataReader
    {
        /// <summary>
        /// Creates a new <see cref="IMetadata"/> instance by adding or updating a key-value pair.
        /// </summary>
        /// <param name="key">The key of the metadata entry. Must not be null or empty.</param>
        /// <param name="value">The value to associate with the key. Can be null.</param>
        /// <returns>A new <see cref="IMetadata"/> instance with the updated entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key"/> is empty or whitespace.</exception>
        IMetadata WithTag(string key, object? value);

        /// <summary>
        /// Creates a new <see cref="IMetadata"/> instance by removing a key-value pair.
        /// </summary>
        /// <param name="key">The key of the metadata entry to remove. Must not be null or empty.</param>
        /// <returns>A new <see cref="IMetadata"/> instance without the specified entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key"/> is empty or whitespace.</exception>
        IMetadata WithoutTag(string key);

        /// <summary>
        /// Creates a new <see cref="IMetadata"/> instance by merging this instance with another.
        /// Existing keys in this instance will be overwritten by keys from the <paramref name="other"/> metadata.
        /// </summary>
        /// <param name="other">The <see cref="IMetadataReader"/> instance to merge with. Must not be null.</param>
        /// <returns>A new <see cref="IMetadata"/> instance containing the merged data.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="other"/> is <see langword="null"/>.</exception>
        IMetadata Merge(IMetadataReader other);
    }
}
