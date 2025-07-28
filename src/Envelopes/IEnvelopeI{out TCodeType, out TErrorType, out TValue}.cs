// <copyright file="IEnvelopeI{out TCodeType, out TErrorType, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>Represents a strongly-typed envelope with a specific value payload.</summary>
    /// <typeparam name="TCodeType">The specific code type identifier.</typeparam>
    /// <typeparam name="TErrorType">The specific error type identifier.</typeparam>
    /// <typeparam name="TValue">The type of the payload.</typeparam>
    public interface IEnvelope<out TCodeType, out TErrorType, out TValue> : IEnvelope<TCodeType, TErrorType>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        /// <summary>The strongly-typed payload.</summary>
        /// <value>The value contained in the envelope.</value>
        TValue? Value { get; }
    }
}
