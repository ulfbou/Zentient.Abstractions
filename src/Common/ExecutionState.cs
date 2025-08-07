// <copyright file="ExecutionState.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Defines the possible execution states for operations, services, and processes.
    /// </summary>
    /// <remarks>
    /// This enum provides a standardized way to track the lifecycle state of any
    /// executable component within the framework, enabling consistent state management
    /// across different subsystems.
    /// </remarks>
    public enum ExecutionState
    {
        /// <summary>
        /// The operation has not been started yet.
        /// Initial state before any execution begins.
        /// </summary>
        [Description("Operation has not been started")]
        NotStarted = 0,

        /// <summary>
        /// The operation is in the process of initializing.
        /// Resources are being allocated and dependencies are being resolved.
        /// </summary>
        [Description("Operation is initializing")]
        Initializing = 1,

        /// <summary>
        /// The operation is currently running and processing.
        /// Main execution logic is active.
        /// </summary>
        [Description("Operation is running")]
        Running = 2,

        /// <summary>
        /// The operation has been temporarily paused.
        /// Can be resumed to continue execution.
        /// </summary>
        [Description("Operation is paused")]
        Paused = 3,

        /// <summary>
        /// The operation is in the process of completing.
        /// Cleanup and finalization activities are occurring.
        /// </summary>
        [Description("Operation is completing")]
        Completing = 4,

        /// <summary>
        /// The operation has completed successfully.
        /// All processing is finished and resources are cleaned up.
        /// </summary>
        [Description("Operation completed successfully")]
        Completed = 5,

        /// <summary>
        /// The operation has failed due to an error.
        /// Processing was interrupted by an exception or error condition.
        /// </summary>
        [Description("Operation failed")]
        Failed = 6,

        /// <summary>
        /// The operation was cancelled before completion.
        /// Cancellation was requested and processing was stopped.
        /// </summary>
        [Description("Operation was cancelled")]
        Cancelled = 7,

        /// <summary>
        /// The operation exceeded its allowed execution time.
        /// Processing was stopped due to timeout constraints.
        /// </summary>
        [Description("Operation timed out")]
        Timeout = 8
    }

    /// <summary>
    /// Provides extension methods for working with ExecutionState values.
    /// </summary>
    public static class ExecutionStateExtensions
    {
        /// <summary>
        /// Determines whether the execution state represents a terminal state.
        /// </summary>
        /// <param name="state">The execution state to check.</param>
        /// <returns>True if the state is terminal (cannot transition to other states); otherwise, false.</returns>
        public static bool IsTerminal(this ExecutionState state)
        {
            return state is ExecutionState.Completed or ExecutionState.Failed or ExecutionState.Cancelled or ExecutionState.Timeout;
        }

        /// <summary>
        /// Determines whether the execution state represents an active state.
        /// </summary>
        /// <param name="state">The execution state to check.</param>
        /// <returns>True if the state represents active processing; otherwise, false.</returns>
        public static bool IsActive(this ExecutionState state)
        {
            return state is ExecutionState.Initializing or ExecutionState.Running or ExecutionState.Completing;
        }

        /// <summary>
        /// Determines whether the execution state represents a successful outcome.
        /// </summary>
        /// <param name="state">The execution state to check.</param>
        /// <returns>True if the state represents successful completion; otherwise, false.</returns>
        public static bool IsSuccessful(this ExecutionState state)
        {
            return state == ExecutionState.Completed;
        }

        /// <summary>
        /// Determines whether the execution state represents an error condition.
        /// </summary>
        /// <param name="state">The execution state to check.</param>
        /// <returns>True if the state represents an error; otherwise, false.</returns>
        public static bool IsError(this ExecutionState state)
        {
            return state is ExecutionState.Failed or ExecutionState.Timeout;
        }

        /// <summary>
        /// Gets the priority level for state transition logging.
        /// </summary>
        /// <param name="state">The execution state.</param>
        /// <returns>The logging priority for this state.</returns>
        public static Priority GetLoggingPriority(this ExecutionState state)
        {
            return state switch
            {
                ExecutionState.Failed or ExecutionState.Timeout => Priority.High,
                ExecutionState.Cancelled => Priority.Normal,
                ExecutionState.Completed => Priority.Low,
                ExecutionState.Running => Priority.Lowest,
                _ => Priority.Normal
            };
        }
    }
}
