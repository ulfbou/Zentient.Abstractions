// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents a factory for creating immutable <see cref="IErrorInfo"/> instances.
    /// This factory abstracts the construction process, ensuring consistency and adherence to
    /// Zentient's core principles of structured errors using <see cref="ICode{TCode}"/> and <see cref="IMetadata"/>.
    /// </summary>
    /// <remarks>
    /// This factory is responsible for creating new instances of <see cref="IErrorInfo"/>.
    /// For modifying existing (immutable) <see cref="IErrorInfo"/> instances,
    /// use extension methods like `WithMetadata` or `WithInnerError` directly on the <see cref="IErrorInfo"/> type,
    /// which leverage C# 'with' expressions on the concrete implementation.
    /// </remarks>
    public interface IErrorInfoFactory
    {
        /// <summary>
        /// Creates a new <see cref="IErrorInfo"/> instance with the specified details.
        /// This is the most comprehensive creation method, allowing full control over all properties.
        /// </summary>
        /// <param name="category">The high-level category of the error.</param>
        /// <param name="code">The structured, protocol-agnostic code representing the specific error type.</param>
        /// <param name="message">A human-readable message describing the error.</param>
        /// <param name="detail">Optional, more verbose technical details or diagnostic information.</param>
        /// <param name="metadata">Optional, immutable metadata associated with this specific error instance. If null, an empty IMetadata instance will be used.</param>
        /// <param name="innerErrors">Optional immutable list of inner errors, allowing for hierarchical error reporting. If null, an empty list will be used.</param>
        /// <returns>A new, immutable <see cref="IErrorInfo"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="code"/> or <paramref name="message"/> is null.</exception>
        IErrorInfo Create(
            ErrorCategory category,
            ICode code,
            string message,
            string? detail = null,
            IMetadata? metadata = null,
            IEnumerable<IErrorInfo>? innerErrors = null);

        /// <summary>
        /// Creates a new <see cref="IErrorInfo"/> instance using a simplified code representation.
        /// The factory will internally create an <see cref="ICode"/> instance using the provided name and value.
        /// </summary>
        /// <param name="category">The high-level category of the error.</param>
        /// <param name="codeName">The symbolic name of the error code (e.g., "VALIDATION_FAILED").</param>
        /// <param name="codeValue">An optional numeric value for the error code (e.g., 400).</param>
        /// <param name="message">A human-readable message describing the error.</param>
        /// <param name="detail">Optional, more verbose technical details or diagnostic information.</param>
        /// <param name="metadata">Optional, immutable metadata associated with this specific error instance. If null, an empty IMetadata instance will be used.</param>
        /// <param name="innerErrors">Optional immutable list of inner errors. If null, an empty list will be used.</param>
        /// <returns>A new, immutable <see cref="IErrorInfo"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="codeName"/> or <paramref name="message"/> is null.</exception>
        IErrorInfo Create(
            ErrorCategory category,
            string codeName,
            int? codeValue,
            string message,
            string? detail = null,
            IMetadata? metadata = null,
            IEnumerable<IErrorInfo>? innerErrors = null);

        /// <summary>
        /// Creates a new <see cref="IErrorInfo"/> instance from an <see cref="Exception"/>.
        /// This method automatically extracts relevant exception details (message, stack trace, type)
        /// and populates them into the <see cref="IErrorInfo"/>'s properties and metadata.
        /// </summary>
        /// <param name="ex">The exception to convert into an <see cref="IErrorInfo"/>.</param>
        /// <param name="category">The high-level category for the error. Defaults to <see cref="ErrorCategory.InternalError"/>.</param>
        /// <param name="codeName">Optional symbolic name for the error code. If null, derived from exception type name.</param>
        /// <param name="codeValue">Optional numeric value for the error code.</param>
        /// <param name="metadata">Optional additional metadata to include, which will be merged with exception-derived metadata.</param>
        /// <param name="innerErrors">Optional immutable list of inner errors. If null, an empty list will be used.</param>
        /// <returns>A new, immutable <see cref="IErrorInfo"/> instance representing the exception.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="ex"/> is null.</exception>
        IErrorInfo CreateFromException(
            Exception ex,
            ErrorCategory category = ErrorCategory.InternalError,
            string? codeName = null,
            int? codeValue = null,
            IMetadata? metadata = null,
            IEnumerable<IErrorInfo>? innerErrors = null);
    }
}
