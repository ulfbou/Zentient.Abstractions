// <copyright file="IStreamableEnvelope{out TCodeType, out TErrorType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>Represents an envelope carrying a stream payload.</summary>
    public interface IStreamableEnvelope<out TCodeType, out TErrorType> : IEnvelope<TCodeType, TErrorType>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        /// <summary>
        /// The stream payload.
        /// </summary>
        Stream Stream { get; }
    }
}
