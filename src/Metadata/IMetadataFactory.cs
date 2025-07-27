// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Metadata
{
    /// <summary>
    /// Factory interface for creating <see cref="IMetadata"/> instances.
    /// </summary>
    public interface IMetadataFactory
    {
        /// <summary>
        /// Gets an empty <see cref="IMetadata"/> instance.
        /// </summary>
        IMetadata Empty { get; }

        /// <summary>
        /// Creates a new <see cref="IMetadata"/> instance with the specified initial tags.
        /// </summary>
        /// <param name="initialTags">
        /// An optional collection of key-value pairs to initialize the metadata.
        /// If <c>null</c>, the metadata will be empty.
        /// </param>
        /// <returns>
        /// A new <see cref="IMetadata"/> instance containing the provided tags.
        /// </returns>
        IMetadata Create(IEnumerable<KeyValuePair<string, object?>>? initialTags = null);
    }
}
