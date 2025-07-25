// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Factory for creating and accessing codes of a specific domain and value type.
    /// </summary>
    public interface ICodeFactory<TCode, TValue>
        where TCode : ICodeType
    {
        /// <summary>Create a code instance with the given properties.</summary>
        /// <param name="name">The symbolic name of the code (e.g., "NotFound", "ValidationError").</param>
        /// <param name="value">An optional numeric value associated with the code (e.g., 404, 1001).</param>
        /// <param name="severity">Optional severity level for the code (e.g., Error, Warning, Info).</param>
        /// <param name="category">Optional error category for classification (e.g., Validation, NotFound).</param>
        /// <param name="description">Optional human-readable description of the code.</param>
        /// <param name="metadata">Optional extensible metadata for diagnostics or future use.</param>
        /// <returns>A new instance of <see cref="ICode{TCode, TValue}"/> with the specified properties.</returns>
        ICode<TCode, TValue> CreateCode(
            string name,
            TValue? value = default,
            ErrorSeverity? severity = null,
            ErrorCategory? category = null,
            string? description = null,
            IReadOnlyDictionary<string, object?>? metadata = null);

        /// <summary>Determine if a code can be created with the given parameters.</summary>
        /// <param name="name">The symbolic name of the code.</param>
        /// <param name="value">An optional numeric value associated with the code.</param>
        /// <param name="severity">Optional severity level for the code.</param>
        /// <returns>
        /// <see langword="true" /> if a code can be created with the specified parameters; otherwise, <see langword="false" />.
        /// </returns>
        bool CanCreateCode(
            string name,
            TValue? value = default,
            ErrorSeverity? severity = null);

        /// <summary>Batch creation of multiple codes.</summary>
        /// <param name="requests">A collection of code creation requests.</param>
        /// <returns>
        /// A read-only list of created codes, each corresponding to a request.
        /// If a request cannot be fulfilled, it will not appear in the result.
        /// </returns>
        IReadOnlyList<ICode<TCode, TValue>> CreateMany(IEnumerable<CodeRequest<TValue>> requests);

        /// <summary>Safe code creation with result semantics.</summary>
        /// <param name="name">The symbolic name of the code.</param>
        /// <param name="value">An optional numeric value associated with the code.</param>
        /// <param name="severity">Optional severity level for the code.</param>
        /// <param name="category">Optional error category for classification.</param>
        /// <param name="description">Optional human-readable description of the code.</param>
        /// <param name="metadata">Optional extensible metadata for diagnostics or future use.</param>
        /// <returns>
        /// An <see cref="IResult{T}"/> containing the created code if successful,
        /// or an error if the code could not be created.
        /// </returns>
        IResult<ICode<TCode, TValue>> TryCreateCode(
            string name,
            TValue? value = default,
            ErrorSeverity? severity = null,
            ErrorCategory? category = null,
            string? description = null,
            IReadOnlyDictionary<string, object?>? metadata = null);

        #region Canonical Default Codes

        /// <summary>Represents the absence of a code or a default uninitialized state.</summary>
        /// <value>The canonical 'None' code instance.</value>
        ICode<TCode, TValue> None { get; }

        /// <summary>Represents a general, uncategorized error or outcome.</summary>
        /// <value>The canonical 'General' code instance.</value>
        ICode<TCode, TValue> General { get; }

        /// <summary>Indicates a validation error related to input data or structure.</summary>
        /// <value>The canonical 'Validation' code instance.</value>
        ICode<TCode, TValue> Validation { get; }

        /// <summary>Indicates a bad request due to semantic or logical issues.</summary>
        /// <value>The canonical 'BadRequest' code instance.</value>
        ICode<TCode, TValue> BadRequest { get; }

        /// <summary>Indicates an authentication failure.</summary>
        /// <value>The canonical 'Authentication' code instance.</value>
        ICode<TCode, TValue> Authentication { get; }

        /// <summary>Indicates an authorization failure.</summary>
        /// <value>The canonical 'Authorization' code instance.</value>
        ICode<TCode, TValue> Authorization { get; }

        /// <summary>Indicates that a requested resource or entity was not found.</summary>
        /// <value>The canonical 'NotFound' code instance.</value>
        ICode<TCode, TValue> NotFound { get; }

        /// <summary>Indicates a conflict, such as a resource state or concurrency violation.</summary>
        /// <value>The canonical 'Conflict' code instance.</value>
        ICode<TCode, TValue> Conflict { get; }

        /// <summary>Indicates a violation of business rules or domain invariants.</summary>
        /// <value>The canonical 'BusinessRule' code instance.</value>
        ICode<TCode, TValue> BusinessRule { get; }

        /// <summary>Indicates that a feature or operation is not implemented.</summary>
        /// <value>The canonical 'NotImplemented' code instance.</value>
        ICode<TCode, TValue> NotImplemented { get; }

        /// <summary>Indicates an unexpected internal error within the application.</summary>
        /// <value>The canonical 'InternalError' code instance.</value>
        ICode<TCode, TValue> InternalError { get; }

        /// <summary>Indicates an error related to an external dependency or service.</summary>
        /// <value>The canonical 'ExternalDependency' code instance.</value>
        ICode<TCode, TValue> ExternalDependency { get; }

        /// <summary>Indicates that an operation timed out.</summary>
        /// <value>The canonical 'Timeout' code instance.</value>
        ICode<TCode, TValue> Timeout { get; }

        /// <summary>Indicates that a service or system is temporarily unavailable.</summary>
        /// <value>The canonical 'ServiceUnavailable' code instance.</value>
        ICode<TCode, TValue> ServiceUnavailable { get; }

        /// <summary>Indicates a security violation beyond standard authentication/authorization failures.</summary>
        /// <value>The canonical 'SecurityViolation' code instance.</value>
        ICode<TCode, TValue> SecurityViolation { get; }

        #endregion
    }
}
