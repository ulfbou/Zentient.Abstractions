// <copyright file="IOperation.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Diagnostics;

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Represents a comprehensive operation with full lifecycle and policy support.
    /// </summary>
    /// <remarks>
    /// This interface combines all the core abstractions to provide a complete
    /// operation abstraction with execution state, priority, consistency requirements,
    /// caching, retry policies, and metadata support.
    /// </remarks>
    public interface IOperation : 
        IExecutable, 
        IHasPriority, 
        IHasConsistencyLevel, 
        IHasMetadata, 
        IHasCorrelationId,
        IIdentifiable,
        IHasTimestamp
    {
        /// <summary>
        /// Gets the operation mode that controls execution characteristics.
        /// </summary>
        /// <value>The mode that determines performance and reliability trade-offs.</value>
        OperationMode Mode { get; }

        /// <summary>
        /// Gets the operation timeout.
        /// </summary>
        /// <value>The maximum time allowed for operation execution.</value>
        TimeSpan Timeout { get; }

        /// <summary>
        /// Gets the operation context.
        /// </summary>
        /// <value>Additional contextual information for the operation.</value>
        IDictionary<string, object> Context { get; }
    }

    /// <summary>
    /// Represents a typed operation with specific input and result types.
    /// </summary>
    /// <typeparam name="TInput">The type of input for the operation.</typeparam>
    /// <typeparam name="TResult">The type of result produced by the operation.</typeparam>
    public interface IOperation<TInput, TResult> : 
        IOperation, 
        IExecutable<TInput, TResult>,
        Caching.ICacheable<TResult>,
        Policies.IRetryable<TInput, TResult>
    {
        /// <summary>
        /// Gets the input data for the operation.
        /// </summary>
        /// <value>The operation input.</value>
        TInput Input { get; }

        /// <summary>
        /// Gets the operation result if execution has completed successfully.
        /// </summary>
        /// <value>The operation result, or default if not completed successfully.</value>
        TResult? Result { get; }

        /// <summary>
        /// Gets any exception that occurred during execution.
        /// </summary>
        /// <value>The exception, or null if no exception occurred.</value>
        Exception? Exception { get; }
    }
}
