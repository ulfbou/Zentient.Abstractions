// <copyright file="IEnvelopeBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.IO;
using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Envelopes.Builders
{
    /// <summary>
    /// Fluent builder for constructing <see cref="IEnvelope{TCodeDefinition,TErrorDefinition}"/> instances.
    /// </summary>
    /// <typeparam name="TCodeDefinition"> The specific <see cref="ICodeDefinition"/> for the envelope's code.</typeparam>
    /// <typeparam name="TErrorDefinition">The specific <see cref="IErrorDefinition"/> for the envelope's errors.</typeparam>
    public interface IEnvelopeBuilder<TCodeDefinition, TErrorDefinition>
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    {
        IEnvelopeBuilder<TCodeDefinition, TErrorDefinition> WithCode(ICode<TCodeDefinition> code);

        IEnvelopeBuilder<TCodeDefinition, TErrorDefinition> WithErrors(IEnumerable<IErrorInfo<TErrorDefinition>>? errors);

        IEnvelopeBuilder<TCodeDefinition, TErrorDefinition> WithValue(object? value);

        IEnvelopeBuilder<TCodeDefinition, TErrorDefinition> WithValue<TValue>(TValue? value);

        IEnvelopeBuilder<TCodeDefinition, TErrorDefinition> WithHeaders(IDictionary<string, IReadOnlyCollection<string>>? headers);

        IEnvelopeBuilder<TCodeDefinition, TErrorDefinition> WithStream(Stream? stream);

        IEnvelopeBuilder<TCodeDefinition, TErrorDefinition> WithMetadata(IMetadata? metadata);

        IEnvelopeBuilder<TCodeDefinition, TErrorDefinition> AddMetadata(string key, object? value);

        /// <summary>
        /// Builds the final <see cref="IEnvelope{TCodeDefinition,TErrorDefinition}"/> or its value-specific variant.
        /// </summary>
        /// <returns>The constructed envelope instance.</returns>
        IEnvelope<TCodeDefinition, TErrorDefinition> Build();
    }
}
