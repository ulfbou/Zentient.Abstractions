// <copyright file="IEnvelopeI{out TCodeDefinition, out TErrorDefinition, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>Represents a strongly-typed envelope with a specific value payload.</summary>
    /// <typeparam name="TCodeDefinition">The specific code type identifier.</typeparam>
    /// <typeparam name="TErrorDefinition">The specific error type identifier.</typeparam>
    /// <typeparam name="TValue">The type of the payload.</typeparam>
    public interface IEnvelope<out TCodeDefinition, out TErrorDefinition, out TValue> : IEnvelope<TCodeDefinition, TErrorDefinition>
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    {
        /// <summary>The strongly-typed payload.</summary>
        /// <value>The value contained in the envelope.</value>
        TValue? Value { get; }
    }
}
