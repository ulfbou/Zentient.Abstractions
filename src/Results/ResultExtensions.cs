// <copyright file="ResultExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Results
{
#if NETSTANDARD2_0
    /// <summary>
    /// Provides extension methods for <see cref="IResult"/> to simplify success and failure checks.
    /// </summary>
    public static class ResultExtensions
    {
        /// <summary>
        /// Determines whether the specified <see cref="IResult"/> instance represents a successful result.
        /// </summary>
        /// <param name="result">The result to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the result is successful (contains no errors); otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsSuccess(this IResult result) => result?.Errors.Any() != true;

        /// <summary>
        /// Determines whether the specified <see cref="IResult"/> instance represents a failed result.
        /// </summary>
        /// <param name="result">The result to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the result is not successful (contains errors); otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsFailure(this IResult result) => !result.IsSuccess();
    }
#endif
}
