// <copyright file="IStreamableEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.IO;

namespace Zentient.Abstractions
{
    /// <summary>Represents an envelope whose payload can be streamed.</summary>
    public interface IStreamableEnvelope<out TStream> : IEnvelope
        where TStream : Stream
    {
        /// <summary>
        /// Gets the stream containing the payload.
        /// </summary>
        TStream PayloadStream { get; }

        /// <summary>
        /// Gets the size of the payload stream, if known.
        /// </summary>
        long? PayloadLength { get; }

        /// <summary>
        /// Gets the content type of the stream, for format negotiation.
        /// </summary>
        string? ContentType { get; }
    }
}
