// <copyright file="IHeaderedEnvelope{out TCodeType, out TErrorType, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>Represents an envelope with protocol headers and a value.</summary>
    /// <typeparam name="TCodeType">The specific code type identifier.</typeparam>
    /// <typeparam name="TErrorType">The specific error type identifier.</typeparam>
    /// <typeparam name="TValue">The type of the value contained in the envelope.</typeparam>
    /// <remarks>
    /// This interface extends <see cref="IHeaderedEnvelope{TCodeType, TErrorType}"/>
    /// to include a value of type <typeparamref name="TValue"/>.
    /// It is designed for scenarios where the envelope needs to carry a specific value
    /// along with its headers and metadata.
    /// </remarks>
    public interface IHeaderedEnvelope<out TCodeType, out TErrorType, out TValue> 
        : IHeaderedEnvelope<TCodeType, TErrorType>, IEnvelope<TCodeType, TErrorType, TValue>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    { }
}
