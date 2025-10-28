// <copyright file="IResult.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Results
{
    /// <summary>
    /// Represents the result of an operation, including success state, messages, and errors.
    /// </summary>
    public interface IResult
    {
        /// <summary>Gets a value indicating whether the result is successful.</summary>
        /// <value>
        /// <see langword="true" /> if the result is successful and contains no errors; otherwise, <see langword="false" />.
        /// </value>
#if NETSTANDARD2_0
        bool IsSuccess { get; }
#else
        bool IsSuccess
            => !Errors.Any();
#endif

        /// <summary>
        /// Gets a read-only list of messages associated with the result (success or failure).
        /// </summary>
        /// <value>
        /// A read-only list of informational or diagnostic messages related to the result.
        /// </value>
        IReadOnlyList<string> Messages { get; }

        /// <summary>Gets a collection of error messages if the result is not successful.</summary>
        /// <value>
        /// A collection of <see cref="IErrorInfo{IErrorDefinition}"/> instances describing
        /// the errors for this result.
        /// </value>
        IEnumerable<IErrorInfo<IErrorDefinition>> Errors { get; }

        /// <summary>
        /// Gets the message of the first error if the operation failed;
        /// otherwise, <see langword="null" />
        /// </summary>
        /// <value>
        /// The message of the first error if present; otherwise, <see langword="null" />.
        /// </value>
#if NETSTANDARD2_0
        string? ErrorMessage { get; }
#else
        string? ErrorMessage
            => Errors.FirstOrDefault()?.Message;
#endif
    }
}
