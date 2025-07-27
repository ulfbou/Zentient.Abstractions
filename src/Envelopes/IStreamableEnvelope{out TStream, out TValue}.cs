// <copyright file="IStreamableEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>Represents a strongly typed streamable envelope containing both a stream payload and a value.</summary>
    /// <typeparam name="TStream">The type of the stream containing the payload. Must derive from <see cref="Stream"/>.</typeparam>
    /// <typeparam name="TValue">The type of the value payload.</typeparam>
    public interface IStreamableEnvelope<out TStream, out TValue> : IEnvelope<TValue>, IStreamableEnvelope<TStream>
        where TStream : Stream
    { }
}
