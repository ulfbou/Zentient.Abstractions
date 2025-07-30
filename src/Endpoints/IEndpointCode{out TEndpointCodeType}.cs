using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Endpoints.Internal;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Results;
using Zentient.Abstractions.Validation;

namespace Zentient.Abstractions.Endpoints
{
    /// <summary>
    /// Represents a canonical, symbolic code that describes the semantic meaning of an endpoint outcome
    /// to an API consumer, independent of transport-specific numeric codes (e.g., HTTP status codes).
    /// </summary>
    /// <remarks>
    /// This is a specialized <see cref="ICode{IEndpointCodeType}"/>. This ensures strong typing
    /// and consistency within the Zentient code system.
    /// </remarks>
    public interface IEndpointCode : ICode<IEndpointCodeType>
    { }
    /// <summary>
    /// Defines the metadata and semantic type for specific endpoint codes.
    /// This allows for categorizing and describing different types of endpoint outcomes.
    /// </summary>
    public interface IEndpointCodeType : ICodeType
    { }
    /// <summary>
    /// Represents the outcome of an endpoint operation, bridging the internal business logic
    /// (<see cref="Zentient.Abstractions.Results.IResult"/>) with external API needs,
    /// while remaining transport-agnostic.
    /// </summary>
    /// <remarks>
    /// It encapsulates an <see cref="Zentient.Abstractions.Results.IResult"/> internally and enriches it with a standardized
    /// <see cref="IEndpointCode"/> and flexible transport metadata.
    /// </remarks>
    public interface IEndpointOutcome : IHasMetadata
    {
        /// <summary>Gets the primary symbolic code associated with the outcome.</summary>
        IEndpointCode Code { get; }

        /// <summary>
        /// Gets a collection of informational or warning messages associated with the outcome.
        /// </summary>
        /// <value>A read-only list of messages that may include success messages, warnings, or other non-error information.</value>
        IReadOnlyList<string> Messages { get; }

        /// <summary>Gets a collection of structured error details.</summary>
        /// <value>A read-only list of errors that occurred during the operation.</value>
        IReadOnlyList<IErrorInfo<IErrorType>> Errors { get; }

        /// <summary>Gets a value indicating whether the operation succeeded.</summary>
        /// <value><see langword="true"/> if the operation succeeded; otherwise, <see langword="false"/>.</value>
        /// <remarks>This property is typically true when <see cref="Errors"/> is empty.</remarks>
        bool IsSuccess => Errors.Count == 0;

        /// <summary>Gets a value indicating whether the operation failed.</summary>
        /// <value>
        /// Always equals the negation of <see cref="IsSuccess" /> unless a custom implementation diverges.
        /// </value>
        bool IsFailure => Errors.Count > 0;

        /// <summary>
        /// Gets all error messages extracted from the <see cref="Errors"/> collection.
        /// </summary>
        IReadOnlyList<string> ErrorMessages =>
            Errors.Select(e => e.Message).ToList();

        /// <summary>
        /// Gets the first error message, or <see langword="null"/> if no errors exist.
        /// </summary>
        string? ErrorMessage
            =>
            Errors.Count == 0
                ? null
                : Errors[0].Message;

        /// <summary>
        /// Gets a single-line summary concatenating all error messages,
        /// or <see langword="null"/> if there are no errors.
        /// </summary>
        string? ErrorSummary =>
            Errors.Count == 0
                ? null
                : string.Join("; ", ErrorMessages);

        /// <summary>
        /// Gets errors grouped by their <see cref="IErrorType"/>,
        /// useful for stratified handling in adapters or telemetry.
        /// </summary>
        IReadOnlyDictionary<IErrorType, IReadOnlyList<IErrorInfo<IErrorType>>> ErrorsByCategory =>
            Errors
                .GroupBy(e => e.ErrorDefinition)
                .ToDictionary(
                    g => g.Key,
                    g => (IReadOnlyList<IErrorInfo<IErrorType>>)g.ToList());

        /// <summary>
        /// Indicates whether any errors of category <see cref="IValidationType"/> are present.
        /// </summary>
        bool HasValidationErrors =>
            Errors.Any(e => e.ErrorDefinition is IValidationType);

        /// <summary>Indicates whether any errors exist.</summary>
        bool HasErrors =>
            Errors.Count > 0;

        /// <summary>
        /// Gets all distinct error codes in the result, in order of occurrence.
        /// </summary>
        IReadOnlyList<ICode<ICodeType>> ErrorCodes =>
            Errors.Select(e => e.Code).Distinct().ToList();

        /// <summary>
        /// Gets the first error's code, or <see langword="null"/> if no errors exist.
        /// </summary>
        ICode<ICodeType>? PrimaryErrorCode => Errors.Count == 0
            ? null
            : Errors[0].Code;

        /// <summary>
        /// Flattens nested <see cref="Errors"/> into a single sequence.
        /// </summary>
        IEnumerable<IErrorInfo<IErrorType>> FlattenErrors() =>
            Errors.SelectMany(e => new[] { e }.Concat(e.InnerErrors));
    }

    /// <summary>
    /// Represents the outcome of an endpoint operation that produces a value,
    /// encapsulating an internal <see cref="Zentient.Abstractions.Results.IResult{TValue}"/> with endpoint-specific semantics.
    /// </summary>
    /// <typeparam name="TValue">The type of the value produced by the operation.</typeparam>
    public interface IEndpointOutcome<out TValue> : IEndpointOutcome
    { }
}
