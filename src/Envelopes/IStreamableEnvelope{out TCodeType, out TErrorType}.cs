// <copyright file="IStreamableEnvelope{out TCodeType, out TErrorType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>Represents an envelope carrying a stream payload.</summary>
    /// <typeparam name="TCodeType">The type of the code.</typeparam>
    /// <typeparam name="TErrorType">The type of the error.</typeparam>
    public interface IStreamableEnvelope<out TCodeType, out TErrorType> : IEnvelope<TCodeType, TErrorType>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        /// <summary>The stream payload.</summary>
        /// <value>The stream.</value>
        Stream Stream { get; }
    }
 }
