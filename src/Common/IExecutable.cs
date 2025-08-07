// <copyright file="IExecutable.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Represents an object that can be executed with state tracking.
    /// </summary>
    /// <remarks>
    /// This interface provides a standard way to manage execution lifecycle
    /// for operations, services, and processes throughout the framework.
    /// </remarks>
    public interface IExecutable
    {
        /// <summary>
        /// Gets the current execution state of the object.
        /// </summary>
        /// <value>The current state in the execution lifecycle.</value>
        ExecutionState State { get; }

        /// <summary>
        /// Gets the timestamp when execution started.
        /// </summary>
        /// <value>The start time, or null if execution has not started.</value>
        DateTimeOffset? StartedAt { get; }

        /// <summary>
        /// Gets the timestamp when execution completed.
        /// </summary>
        /// <value>The completion time, or null if execution has not completed.</value>
        DateTimeOffset? CompletedAt { get; }

        /// <summary>
        /// Gets the total execution duration.
        /// </summary>
        /// <value>The duration of execution, or null if not yet completed.</value>
        TimeSpan? Duration { get; }
    }

    /// <summary>
    /// Represents an object that can be executed asynchronously with result tracking.
    /// </summary>
    /// <typeparam name="TResult">The type of result produced by the execution.</typeparam>
    public interface IExecutable<TResult> : IExecutable
    {
        /// <summary>
        /// Executes the operation asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous execution operation.</returns>
        Task<TResult> Execute(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Represents an object that can be executed asynchronously with input and result.
    /// </summary>
    /// <typeparam name="TInput">The type of input required for execution.</typeparam>
    /// <typeparam name="TResult">The type of result produced by the execution.</typeparam>
    public interface IExecutable<TInput, TResult> : IExecutable
    {
        /// <summary>
        /// Executes the operation asynchronously with the specified input.
        /// </summary>
        /// <param name="input">The input data for the execution.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous execution operation.</returns>
        Task<TResult> Execute(TInput input, CancellationToken cancellationToken = default);
    }
}
