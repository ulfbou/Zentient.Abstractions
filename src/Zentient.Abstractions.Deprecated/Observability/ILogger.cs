// <copyright file="ILogger{TContextDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Observability
{
    /// <summary>Provides structured logging methods tied to a specific context type.</summary>
    /// <typeparam name="TContextDefinition">
    /// The ambient context (e.g., service or component) associated with this logger.
    /// </typeparam>
    public interface ILogger<out TContextDefinition>
        where TContextDefinition : IContextDefinition
    {
        /// <summary>Checks if the specified log level is enabled.</summary>
        /// <param name="level">The log level to check.</param>
        /// <returns>
        /// <see langword="true"/> if the specified log level is enabled; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsEnabled(LogLevel level);

        /// <summary>Logs a structured message asynchronously.</summary>
        /// <param name="level">The severity level of the log entry.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">An optional exception associated with the log entry.</param>
        /// <param name="metadata">Optional metadata to enrich the log entry.</param>
        /// <returns>A task representing the asynchronous logging operation.</returns>
        Task Log(
            LogLevel level,
            string message,
            Exception? exception = null,
            IMetadata? metadata = null);

        /// <summary>Logs a structured message with formatting and arguments asynchronously.</summary>
        /// <param name="level">The severity level of the log entry.</param>
        /// <param name="format">The format string for the log message.</param>
        /// <param name="args">The arguments to format the message.</param>
        /// <returns>Task representing the asynchronous logging operation.</returns>
        Task Log(
            LogLevel level,
            string format,
            object?[] args);
    }
}
