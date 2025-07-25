// <copyright file="IResult.cs" company="Zentient Framework Team">
// Copyright Â© 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Defines the contract for an non-generic operation's outcome, which can be either a success or a failure.
    /// </summary>
    public interface IResult
    {
        /// <summary>Gets a value indicating whether the operation was successful.</summary>
        /// <value><see langword="true" /> if the operation was successful; otherwise, <see langword="false" />.</value>
        bool IsSuccess { get; }

        /// <summary>Gets a value indicating whether the operation failed.</summary>
        /// <value><see langword="true" /> if the operation failed; otherwise, <see langword="false" />.</value>
        bool IsFailure { get; }

        /// <summary>Gets a read-only list of detailed error information if the operation failed. Empty if successful.</summary>
        /// <value>A read-only list of <see cref="IErrorInfo"/> instances representing the errors.</value>
        IReadOnlyList<IErrorInfo> Errors { get; }

        /// <summary>Gets a read-only list of messages associated with the result (success or failure).</summary>
        /// <value>A read-only list of strings containing messages related to the operation.</value>
        IReadOnlyList<string> Messages { get; }

        /// <summary>Gets the message of the first error if the operation failed; otherwise, null.</summary>
        /// <value>The error message if the operation failed; otherwise, <see langword="null" />.</value>
        string? ErrorMessage { get; }
    }
}
