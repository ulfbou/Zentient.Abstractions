// <copyright file="IHeaderedEnvelope{out TCodeDefinition, out TErrorDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>Represents an envelope with protocol headers.</summary>
    /// <typeparam name="TCodeDefinition">The specific code type identifier.</typeparam>
    /// <typeparam name="TErrorDefinition">The specific error type identifier.</typeparam>
    /// <remarks>
    /// This interface adds support for transport-level key-value headers,
    /// distinct from domain-specific <see cref="IHasMetadata"/>.
    /// </remarks>
    public interface IHeaderedEnvelope<out TCodeDefinition, out TErrorDefinition> : IEnvelope<TCodeDefinition, TErrorDefinition>
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    {
        /// <summary>Transport-level headers associated with this envelope.</summary>
        /// <value>
        /// A read-only dictionary where keys are header names and values are collections of strings.
        /// </value>
        IReadOnlyDictionary<string, IReadOnlyCollection<string>> Headers { get; }
    }
}
