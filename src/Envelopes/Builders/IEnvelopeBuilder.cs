// <copyright file="IEnvelopeBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Envelopes.Builders
{
    /// <summary>
    /// Fluent builder for constructing <see cref="IEnvelope{TCodeType,TErrorType}"/> instances.
    /// </summary>
    /// <typeparam name="TCodeType"> The specific <see cref="ICodeType"/> for the envelope's code.</typeparam>
    /// <typeparam name="TErrorType">The specific <see cref="IErrorType"/> for the envelope's errors.</typeparam>
    public interface IEnvelopeBuilder<TCodeType, TErrorType>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        IEnvelopeBuilder<TCodeType, TErrorType> WithCode(ICode<TCodeType> code);

        IEnvelopeBuilder<TCodeType, TErrorType> WithErrors(IEnumerable<IErrorInfo<TErrorType>>? errors);

        IEnvelopeBuilder<TCodeType, TErrorType> WithValue(object? value);

        IEnvelopeBuilder<TCodeType, TErrorType> WithValue<TValue>(TValue? value);

        IEnvelopeBuilder<TCodeType, TErrorType> WithHeaders(IDictionary<string, IReadOnlyCollection<string>>? headers);

        IEnvelopeBuilder<TCodeType, TErrorType> WithStream(Stream? stream);

        IEnvelopeBuilder<TCodeType, TErrorType> WithMetadata(IMetadata? metadata);

        IEnvelopeBuilder<TCodeType, TErrorType> AddMetadata(string key, object? value);

        /// <summary>
        /// Builds the final <see cref="IEnvelope{TCodeType,TErrorType}"/> or its value-specific variant.
        /// </summary>
        /// <returns>The constructed envelope instance.</returns>
        IEnvelope<TCodeType, TErrorType> Build();
    }
}
