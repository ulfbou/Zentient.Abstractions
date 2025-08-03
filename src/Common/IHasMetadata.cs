// <copyright file="IHasMetadata.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Common
{
    /// <summary>Represents an entity that has associated metadata.</summary>
    /// <remarks>
    /// This interface provides a standardized way for any object to expose its
    /// metadata, facilitating introspection, extensibility, and dynamic behavior
    /// throughout the Zentient Framework. The metadata is expected to be immutable.
    /// </remarks>
    public interface IHasMetadata
    {
        /// <summary>
        /// Gets the immutable collection of metadata associated with this entity.
        /// </summary>
        IMetadata Metadata { get; }
    }
}
