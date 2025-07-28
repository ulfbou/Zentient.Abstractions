// <copyright file="IHeaderedEnvelope{out TCodeType, out TErrorType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>Represents an envelope with protocol headers.</summary>
    /// <typeparam name="TCodeType">The specific code type identifier.</typeparam>
    /// <typeparam name="TErrorType">The specific error type identifier.</typeparam>
    /// <remarks>
    /// This interface adds support for transport-level key-value headers,
    /// distinct from domain-specific <see cref="IHasMetadata"/>.
    /// </remarks>
    public interface IHeaderedEnvelope<out TCodeType, out TErrorType> : IEnvelope<TCodeType, TErrorType>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        /// <summary>Transport-level headers associated with this envelope.</summary>
        /// <value>
        /// A read-only dictionary where keys are header names and values are collections of strings.
        /// </value>
        IReadOnlyDictionary<string, IReadOnlyCollection<string>> Headers { get; }
    }
}
