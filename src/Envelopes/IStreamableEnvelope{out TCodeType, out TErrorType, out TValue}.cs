// <copyright file="IStreamableEnvelope{out TCodeType, out TErrorType, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>
    /// Represents a strongly-typed envelope carrying a stream payload and a value.
    /// </summary>
    /// <typeparam name="TCodeType">The specific code type identifier for the envelope's result code.</typeparam>
    /// <typeparam name="TErrorType">The specific error type identifier for errors within the envelope.</typeparam>
    /// <typeparam name="TValue">The type of the strongly-typed value payload.</typeparam>
    /// <remarks>
    /// This interface extends <see cref="IStreamableEnvelope{TCodeType, TErrorType}"/> and <see cref="IEnvelope{TCodeType, TErrorType}"/>,
    /// providing a contract for envelopes that carry both a stream and a strongly-typed value.
    /// </remarks>
    public interface IStreamableEnvelope<out TCodeType, out TErrorType, out TValue>
        : IStreamableEnvelope<TCodeType, TErrorType>, IEnvelope<TCodeType, TErrorType, TValue>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    { }
}
