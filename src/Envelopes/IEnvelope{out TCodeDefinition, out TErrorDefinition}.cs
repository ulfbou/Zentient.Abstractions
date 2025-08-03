// <copyright file="IEnvelope{out TCodeDefinition, out TErrorDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>
    /// Represents a strongly-typed, immutable envelope carrying a code, errors, value, and metadata.
    /// </summary>
    /// <typeparam name="TCodeDefinition">The specific code type identifier for the envelope's result code.</typeparam>
    /// <typeparam name="TErrorDefinition">The specific error type identifier for errors within the envelope.</typeparam>
    /// <remarks>
    /// This is the foundational envelope interface, designed to encapsulate the outcome of an operation.
    /// It includes core properties for the result code, any associated errors, an optional untyped payload,
    /// and extensible metadata for contextual information.
    /// </remarks>
    public interface IEnvelope<out TCodeDefinition, out TErrorDefinition> : IHasMetadata
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    {
        /// <summary>Indicates whether the operation succeeded.</summary>
        /// <value>
        /// <see langword="true" /> if the operation was successful; otherwise, <see langword="false" />.
        /// </value>
        bool IsSuccess { get; }

        /// <summary>The result code associated with this envelope.</summary>
        /// <value>
        /// An <see cref="ICode{TCodeDefinition}"/> instance representing the operation's outcome.
        /// </value>
        ICode<TCodeDefinition> Code { get; }

        /// <summary>Optional informational or diagnostic messages.</summary>
        /// <value>The collection of messages, or an empty collection if no messages are present.</value>
        /// <remarks>
        /// Messages should be used to convey additional context or information about the operation,
        /// such as warnings, informational messages, or success confirmations.
        /// Each message should be a simple string that provides meaningful information to the caller.
        /// If no messages are present, this property can be an empty collection.
        /// </remarks>
        IReadOnlyCollection<string> Messages { get; }

        /// <summary>A domain-typed collection of errors, if any.</summary>
        /// <value>
        /// A read-only list of <see cref="IErrorInfo{TErrorDefinition}"/> instances, or an empty list if no errors.
        /// </value>
        IReadOnlyList<IErrorInfo<TErrorDefinition>> Errors { get; }
    }
}
