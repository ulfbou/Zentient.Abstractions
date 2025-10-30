// <copyright file="IHasMetadata{out TMetadata}.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Represents a strongly-typed metadata carrier.
    /// The <typeparamref name="TMetadata"/> type is expected to implement <see cref="IConcept"/>.
    /// </summary>
    /// <typeparam name="TMetadata">The CLR type of the metadata payload.</typeparam>
    public interface IHasMetadata<out TMetadata> : IHasMetadata where TMetadata : IConcept
    {
        /// <summary>
        /// Gets the metadata payload associated with the current concept.
        /// </summary>
        TMetadata Metadata { get; }
    }
}
