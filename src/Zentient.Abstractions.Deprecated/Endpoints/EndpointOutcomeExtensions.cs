// <copyright file="EndpointOutcomeExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Errors.Definitions;
using Zentient.Abstractions.Validation.Definitions;

namespace Zentient.Abstractions.Endpoints
{
    // Implement NETSTANDARD2_0 compatibility extension methods for all IEndpointOutcome properties
#if NETSTANDARD2_0

    public static class EndpointOutcomeExtensions
    {
        /// <summary>
        /// Determines whether the specified <see cref="IEndpointOutcome"/> instance represents a successful outcome.
        /// </summary>
        /// <param name="outcome">The outcome to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the outcome is successful (contains no errors); otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsSuccess(this IEndpointOutcome outcome)
            => outcome != null && (outcome.Errors == null || outcome.Errors.Count == 0);

        /// <summary>
        /// Determines whether the specified <see cref="IEndpointOutcome"/> instance represents a failed outcome.
        /// </summary>
        /// <param name="outcome">The outcome to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the outcome is not successful (contains errors); otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsFailure(this IEndpointOutcome outcome)
            => !IsSuccess(outcome);

        /// <summary>
        /// Gets all error messages extracted from the <see cref="IEndpointOutcome.Errors"/> collection.
        /// </summary>
        public static IReadOnlyList<string> ErrorMessages(this IEndpointOutcome outcome)
            => outcome?.Errors?.Select(e => e.Message).ToList() ?? new List<string>();

        /// <summary>
        /// Gets the first error message, or <see langword="null"/> if no errors exist.
        /// </summary>
        public static string? ErrorMessage(this IEndpointOutcome outcome)
            => outcome != null && outcome.Errors != null && outcome.Errors.Count > 0
                ? outcome.Errors[0].Message
                : null;

        /// <summary>
        /// Gets a single-line summary concatenating all error messages,
        /// or <see langword="null"/> if there are no errors.
        /// </summary>
        public static string? ErrorSummary(this IEndpointOutcome outcome)
        {
            var messages = ErrorMessages(outcome);
            return messages.Count == 0 ? null : string.Join("; ", messages);
        }

        /// <summary>
        /// Gets errors grouped by their <see cref="IErrorDefinition"/>,
        /// useful for stratified handling in adapters or telemetry.
        /// </summary>
        public static IReadOnlyDictionary<IErrorDefinition, IReadOnlyList<IErrorInfo<IErrorDefinition>>> ErrorsByCategory(this IEndpointOutcome outcome)
            => outcome?.Errors?
                .GroupBy(e => e.ErrorDefinition)
                .ToDictionary(
                    g => g.Key,
                    g => (IReadOnlyList<IErrorInfo<IErrorDefinition>>)g.ToList())
                ?? new Dictionary<IErrorDefinition, IReadOnlyList<IErrorInfo<IErrorDefinition>>>();

        /// <summary>
        /// Indicates whether any errors of category <see cref="IValidationDefinition"/> are present.
        /// </summary>
        public static bool HasValidationErrors(this IEndpointOutcome outcome)
            => outcome?.Errors?.Any(e => e.ErrorDefinition is IValidationDefinition) == true;

        /// <summary>
        /// Indicates whether any errors exist.
        /// </summary>
        public static bool HasErrors(this IEndpointOutcome outcome)
            => outcome?.Errors != null && outcome.Errors.Count > 0;

        /// <summary>
        /// Gets all distinct error codes in the result, in order of occurrence.
        /// </summary>
        public static IReadOnlyList<ICode<ICodeDefinition>> ErrorCodes(this IEndpointOutcome outcome)
            => outcome?.Errors?.Select(e => e.Code).Distinct().ToList() ?? new List<ICode<ICodeDefinition>>();

        /// <summary>
        /// Gets the first error's code, or <see langword="null"/> if no errors exist.
        /// </summary>
        public static ICode<ICodeDefinition>? PrimaryErrorCode(this IEndpointOutcome outcome)
            => outcome != null && outcome.Errors != null && outcome.Errors.Count > 0
                ? outcome.Errors[0].Code
                : null;

        /// <summary>
        /// Flattens nested <see cref="IEndpointOutcome.Errors"/> into a single sequence.
        /// </summary>
        public static IEnumerable<IErrorInfo<IErrorDefinition>> FlattenErrors(this IEndpointOutcome outcome)
            => outcome?.Errors?.SelectMany(e => new[] { e }.Concat(e.InnerErrors)) ?? Enumerable.Empty<IErrorInfo<IErrorDefinition>>();
    }
#endif
}
