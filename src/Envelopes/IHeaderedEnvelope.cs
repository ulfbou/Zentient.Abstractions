// <copyright file="IHeaderedEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents an envelope that can carry arbitrary key-value headers,
    /// akin to HTTP headers but protocol-agnostic.
    /// </summary>
    public interface IHeaderedEnvelope : IEnvelope
    {
        /// <summary>
        /// Gets a collection of key-value headers associated with this envelope.
        /// This is distinct from IMetadata, used for transport/protocol-level information.
        /// </summary>
        IReadOnlyDictionary<string, IReadOnlyCollection<string>> Headers { get; }
    }
}
