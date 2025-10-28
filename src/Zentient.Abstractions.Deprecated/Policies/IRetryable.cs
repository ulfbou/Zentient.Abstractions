// <copyright file="IRetryable.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Policies
{
    /// <summary>
    /// Represents an operation that supports retry policies.
    /// </summary>
    /// <remarks>
    /// This interface provides a standard way to specify retry behavior
    /// for operations that may fail temporarily and should be retried.
    /// </remarks>
    public interface IRetryable
    {
        /// <summary>
        /// Gets the retry policy for the operation.
        /// </summary>
        /// <value>The policy that governs retry behavior.</value>
        RetryPolicy RetryPolicy { get; }

        /// <summary>
        /// Gets the maximum number of retry attempts.
        /// </summary>
        /// <value>The maximum number of times the operation should be retried.</value>
        int MaxRetryAttempts { get; }

        /// <summary>
        /// Gets the base interval between retry attempts.
        /// </summary>
        /// <value>The base time to wait between retries.</value>
        TimeSpan BaseRetryInterval { get; }

        /// <summary>
        /// Gets the current attempt number.
        /// </summary>
        /// <value>The number of attempts made so far (1-based).</value>
        int CurrentAttempt { get; }
    }

    /// <summary>
    /// Represents a retryable operation with a specific input and result type.
    /// </summary>
    /// <typeparam name="TInput">The type of input for the operation.</typeparam>
    /// <typeparam name="TResult">The type of result produced by the operation.</typeparam>
    public interface IRetryable<TInput, TResult> : IRetryable
    {
        /// <summary>
        /// Executes the operation with retry logic.
        /// </summary>
        /// <param name="input">The input for the operation.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the operation result.</returns>
        Task<TResult> ExecuteWithRetryAsync(TInput input, CancellationToken cancellationToken = default);

        /// <summary>
        /// Determines whether the operation should be retried based on the exception.
        /// </summary>
        /// <param name="exception">The exception that occurred.</param>
        /// <returns>True if the operation should be retried; otherwise, false.</returns>
        bool ShouldRetry(Exception exception);
    }
}
