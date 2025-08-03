// <copyright file="IEndpointOutcome.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;
using Zentient.Abstractions.Validation;
using Zentient.Abstractions.Validation.Definitions;

namespace Zentient.Abstractions.Endpoints
{
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
        IReadOnlyList<IErrorInfo<IErrorDefinition>> Errors { get; }

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
        /// Gets errors grouped by their <see cref="IErrorDefinition"/>,
        /// useful for stratified handling in adapters or telemetry.
        /// </summary>
        IReadOnlyDictionary<IErrorDefinition, IReadOnlyList<IErrorInfo<IErrorDefinition>>> ErrorsByCategory =>
            Errors
                .GroupBy(e => e.ErrorDefinition)
                .ToDictionary(
                    g => g.Key,
                    g => (IReadOnlyList<IErrorInfo<IErrorDefinition>>)g.ToList());

        /// <summary>
        /// Indicates whether any errors of category <see cref="IValidationDefinition"/> are present.
        /// </summary>
        bool HasValidationErrors =>
            Errors.Any(e => e.ErrorDefinition is IValidationDefinition);

        /// <summary>Indicates whether any errors exist.</summary>
        bool HasErrors =>
            Errors.Count > 0;

        /// <summary>
        /// Gets all distinct error codes in the result, in order of occurrence.
        /// </summary>
        IReadOnlyList<ICode<ICodeDefinition>> ErrorCodes =>
            Errors.Select(e => e.Code).Distinct().ToList();

        /// <summary>
        /// Gets the first error's code, or <see langword="null"/> if no errors exist.
        /// </summary>
        ICode<ICodeDefinition>? PrimaryErrorCode => Errors.Count == 0
            ? null
            : Errors[0].Code;

        /// <summary>
        /// Flattens nested <see cref="Errors"/> into a single sequence.
        /// </summary>
        IEnumerable<IErrorInfo<IErrorDefinition>> FlattenErrors() =>
            Errors.SelectMany(e => new[] { e }.Concat(e.InnerErrors));
    }
}
