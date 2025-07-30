// <copyright file="IHasMetadata.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Represents an entity that carries an extensible collection of key-value metadata.
    /// </summary>
    /// <remarks>
    /// Metadata provides a flexible way to associate additional, often unstructured,
    /// data with an object without directly extending its public contract. This can be
    /// used for diagnostic tags, tracing information, or other contextual details.
    /// </remarks>
    public interface IHasMetadata
    {
        /// <summary>
        /// Gets an immutable collection of key-value metadata associated with this entity.
        /// </summary>
        /// <value>An instance of <see cref="IMetadata"/>, never <see langword="null"/>.</value>
        IMetadata Metadata { get; }
    }
}
