// <copyright file="IHeaderedEnvelope{out TCodeDefinition, out TErrorDefinition, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>Represents an envelope with protocol headers and a value.</summary>
    /// <typeparam name="TCodeDefinition">The specific code type identifier.</typeparam>
    /// <typeparam name="TErrorDefinition">The specific error type identifier.</typeparam>
    /// <typeparam name="TValue">The type of the value contained in the envelope.</typeparam>
    /// <remarks>
    /// This interface extends <see cref="IHeaderedEnvelope{TCodeDefinition, TErrorDefinition}"/>
    /// to include a value of type <typeparamref name="TValue"/>.
    /// It is designed for scenarios where the envelope needs to carry a specific value
    /// along with its headers and metadata.
    /// </remarks>
    public interface IHeaderedEnvelope<out TCodeDefinition, out TErrorDefinition, out TValue> 
        : IHeaderedEnvelope<TCodeDefinition, TErrorDefinition>, IEnvelope<TCodeDefinition, TErrorDefinition, TValue>
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    { }
}
