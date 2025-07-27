// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Factory for creating various <see cref="IEnvelope"/> types representing operation outcomes.
    /// </summary>
    public interface IEnvelopeFactory
    {
        /// <summary>
        /// Creates a new <see cref="IEnvelope"/> instance with the specified success state, messages, errors, and metadata.
        /// </summary>
        /// <param name="messages">Optional informational or diagnostic messages.</param>
        /// <param name="errors">Optional collection of error details.</param>
        /// <param name="metadata">Optional metadata associated with the envelope.</param>
        /// <returns>A new <see cref="IEnvelope"/> instance.</returns>
        IEnvelope CreateEnvelope(
            IReadOnlyCollection<string>? messages = null,
            IReadOnlyCollection<IErrorInfo>? errors = null,
            IMetadata? metadata = null);

        /// <summary>
        /// Creates a new <see cref="IEnvelope{TValue}"/> instance with the specified success state, value, messages, errors, and metadata.
        /// </summary>
        /// <typeparam name="TValue">The type of the payload value.</typeparam>
        /// <param name="value">The payload value to include in the envelope.</param>
        /// <param name="messages">Optional informational or diagnostic messages.</param>
        /// <param name="errors">Optional collection of error details.</param>
        /// <param name="metadata">Optional metadata associated with the envelope.</param>
        /// <returns>A new <see cref="IEnvelope{TValue}"/> instance.</returns>
        IEnvelope<TValue> CreateEnvelope<TValue>(
            TValue? value,
            IReadOnlyCollection<string>? messages = null,
            IReadOnlyCollection<IErrorInfo>? errors = null,
            IMetadata? metadata = null);

        /// <summary>
        /// Creates a new <see cref="IHeaderedEnvelope"/> instance with the specified success state, headers, messages, errors, and metadata.
        /// </summary>
        /// <param name="headers">Optional key-value headers for protocol-level information.</param>
        /// <param name="messages">Optional informational or diagnostic messages.</param>
        /// <param name="errors">Optional collection of error details.</param>
        /// <param name="metadata">Optional metadata associated with the envelope.</param>
        /// <returns>A new <see cref="IHeaderedEnvelope"/> instance.</returns>
        IHeaderedEnvelope CreateHeaderedEnvelope(
            IReadOnlyDictionary<string, string>? headers = null,
            IReadOnlyCollection<string>? messages = null,
            IReadOnlyCollection<IErrorInfo>? errors = null,
            IMetadata? metadata = null);

        /// <summary>
        /// Creates a new <see cref="IHeaderedEnvelope{TValue}"/> instance with the specified value, headers, messages, errors, and metadata.
        /// </summary>
        /// <typeparam name="TValue">The type of the payload value.</typeparam>
        /// <param name="value">The payload value to include in the envelope.</param>
        /// <param name="headers">Optional key-value headers for protocol-level information.</param>
        /// <param name="messages">Optional informational or diagnostic messages.</param>
        /// <param name="errors">Optional collection of error details.</param>
        /// <param name="metadata">Optional metadata associated with the envelope.</param>
        /// <returns>A new <see cref="IHeaderedEnvelope{TValue}"/> instance.</returns>
        IHeaderedEnvelope<TValue> CreateHeaderedEnvelope<TValue>(
            TValue? value,
            IReadOnlyDictionary<string, string>? headers = null,
            IReadOnlyCollection<string>? messages = null,
            IReadOnlyCollection<IErrorInfo>? errors = null,
            IMetadata? metadata = null);

        /// <summary>
        /// Creates a new <see cref="IStreamableEnvelope{TStream}"/> instance for streaming payloads.
        /// </summary>
        /// <typeparam name="TStream">The type of the stream carrying the payload.</typeparam>
        /// <param name="payloadStream">The stream containing the payload data.</param>
        /// <param name="contentType">Optional content type for the stream (e.g., "application/json").</param>
        /// <param name="payloadLength">Optional length of the payload, if known.</param>
        /// <param name="messages">Optional informational or diagnostic messages.</param>
        /// <param name="errors">Optional collection of error details.</param>
        /// <param name="metadata">Optional metadata associated with the envelope.</param>
        /// <returns>A new <see cref="IStreamableEnvelope{TStream}"/> instance.</returns>
        IStreamableEnvelope<TStream> CreateStreamableEnvelope<TStream>(
            TStream payloadStream,
            string? contentType = null,
            long? payloadLength = null,
            IReadOnlyCollection<string>? messages = null,
            IReadOnlyCollection<IErrorInfo>? errors = null,
            IMetadata? metadata = null) where TStream : Stream;

        /// <summary>
        /// Creates a new <see cref="IStreamableEnvelope{TStream, TValue}"/> instance for streaming payloads with an associated value.
        /// </summary>
        /// <typeparam name="TStream">The type of the stream carrying the payload. Must inherit from <see cref="Stream"/>.</typeparam>
        /// <typeparam name="TValue">The type of the payload value.</typeparam>
        /// <param name="payloadStream">The stream containing the payload data.</param>
        /// <param name="value">The payload value to include in the envelope.</param>
        /// <param name="contentType">Optional content type for the stream (e.g., "application/json").</param>
        /// <param name="payloadLength">Optional length of the payload, if known.</param>
        /// <param name="messages">Optional informational or diagnostic messages.</param>
        /// <param name="errors">Optional collection of error details.</param>
        /// <param name="metadata">Optional metadata associated with the envelope.</param>
        /// <returns>A new <see cref="IStreamableEnvelope{TStream, TValue}"/> instance.</returns>
        IStreamableEnvelope<TStream, TValue> CreateStreamableEnvelope<TStream, TValue>(
            TStream payloadStream,
            TValue? value,
            string? contentType = null,
            long? payloadLength = null,
            IReadOnlyCollection<string>? messages = null,
            IReadOnlyCollection<IErrorInfo>? errors = null,
            IMetadata? metadata = null) where TStream : Stream;
    }
}
