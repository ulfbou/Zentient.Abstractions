// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents the minimal shape of a protocol-agnostic operation outcome envelope.
    /// Provides common properties for success/failure, messages, errors, and metadata.
    /// </summary>
    public interface IEnvelope
    {
        /// <summary>Indicates whether the operation succeeded.</summary>
        /// <value><see langword="true" /> if the operation was successful; otherwise, <see langword="false" />.</value>
        bool IsSuccess { get; }

        /// <summary>
        /// A transport-agnostic code describing the result or outcome (e.g., "NotFound", "Aborted").
        /// </summary>
        /// <remarks>
        /// This code should be used to convey the outcome of the operation in a way that is meaningful across different protocols.
        /// For example, it could represent a specific error condition or a successful operation.
        /// It is not intended to be a detailed error code, but rather a high-level categorization of the result.
        /// It is recommended to use a standardized set of codes that can be understood across different systems.
        /// If no specific code applies, this property can be <see langword="null" />.
        /// </remarks>
        /// <value>The code representing the result, or <see langword="null" /> if no specific code applies.</value>
        ICode? Code { get; }

        /// <summary>Optional informational or diagnostic messages.</summary>
        /// <remarks>
        /// Messages should be used to convey additional context or information about the operation,
        /// such as warnings, informational messages, or success confirmations.
        /// Each message should be a simple string that provides meaningful information to the caller.
        /// If no messages are present, this property can be an empty collection.
        /// </remarks>
        /// <value>The collection of messages, or an empty collection if no messages are present.</value>
        IReadOnlyCollection<string> Messages { get; }

        /// <summary>Optional metadata container for tags relevant to the result.</summary>
        /// <remarks>
        /// Metadata should be used to provide additional structured information about the operation,
        /// such as timestamps, user identifiers, operation context, or any other relevant data.
        /// The metadata should implement <see cref="IMetadata"/> to ensure a consistent structure.
        /// </remarks>
        /// <value>The metadata associated with the result, never <see langword="null" />.</value>
        IMetadata Metadata { get; }

        /// <summary>
        /// Optional collection of errors that occurred during the operation.
        /// This property is never null; if no errors are present, an empty collection is returned.
        /// </summary>
        /// <remarks>
        /// Errors should be used to convey detailed, structured error information,
        /// such as validation failures, business logic errors, or system exceptions.
        /// Each error should implement <see cref="IErrorInfo"/> to provide a consistent structure.
        /// </remarks>
        /// <value>The collection of errors, or an empty collection if no errors occurred.</value>
        IReadOnlyCollection<IErrorInfo> Errors { get; }
    }
}
