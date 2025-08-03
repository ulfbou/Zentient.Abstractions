// <copyright file="IStreamableEnvelope{out TCodeDefinition, out TErrorDefinition, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>
    /// Represents a strongly-typed envelope carrying a stream payload and a value.
    /// </summary>
    /// <typeparam name="TCodeDefinition">The specific code type identifier for the envelope's result code.</typeparam>
    /// <typeparam name="TErrorDefinition">The specific error type identifier for errors within the envelope.</typeparam>
    /// <typeparam name="TValue">The type of the strongly-typed value payload.</typeparam>
    /// <remarks>
    /// This interface extends <see cref="IStreamableEnvelope{TCodeDefinition, TErrorDefinition}"/> and <see cref="IEnvelope{TCodeDefinition, TErrorDefinition}"/>,
    /// providing a contract for envelopes that carry both a stream and a strongly-typed value.
    /// </remarks>
    public interface IStreamableEnvelope<out TCodeDefinition, out TErrorDefinition, out TValue>
        : IStreamableEnvelope<TCodeDefinition, TErrorDefinition>, IEnvelope<TCodeDefinition, TErrorDefinition, TValue>
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    { }
}
