// <copyright file="DeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Options;

namespace Zentient.Abstractions.Observability
{
    /// <summary>
    /// Provides extension methods for deconstructing Observability-related types.
    /// </summary>
    public static class IObservabilityDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="ILogEntry"/> into all its properties.
        /// </summary>
        /// <param name="logEntry">The log entry instance to deconstruct.</param>
        /// <param name="timestamp">The UTC timestamp when the log event occurred.</param>
        /// <param name="level">The severity level of the log event.</param>
        /// <param name="message">The human-readable message describing the event.</param>
        /// <param name="exception">The exception, if any, that occurred during the event.</param>
        /// <param name="activityId">The correlation or activity identifier for tracing linkage.</param>
        /// <param name="metadata">The metadata associated with the log entry.</param>
        public static void Deconstruct(
            this ILogEntry logEntry,
            out DateTimeOffset timestamp,
            out LogLevel level,
            out string message,
            out Exception? exception,
            out string? activityId,
            out IMetadata metadata)
        {
            ArgumentNullException.ThrowIfNull(logEntry, nameof(logEntry));
            timestamp = logEntry.Timestamp;
            level = logEntry.Level;
            message = logEntry.Message;
            exception = logEntry.Exception;
            activityId = logEntry.ActivityId;
            metadata = logEntry.Metadata;
        }

        /// <summary>
        /// Deconstructs an <see cref="ILogEntry"/> into its timestamp, level, and message (basic logging subset).
        /// </summary>
        /// <param name="logEntry">The log entry instance to deconstruct.</param>
        /// <param name="timestamp">The UTC timestamp when the log event occurred.</param>
        /// <param name="level">The severity level of the log event.</param>
        /// <param name="message">The human-readable message describing the event.</param>
        public static void Deconstruct(
            this ILogEntry logEntry,
            out DateTimeOffset timestamp,
            out LogLevel level,
            out string message)
        {
            ArgumentNullException.ThrowIfNull(logEntry, nameof(logEntry));
            timestamp = logEntry.Timestamp;
            level = logEntry.Level;
            message = logEntry.Message;
        }

        /// <summary>
        /// Deconstructs an <see cref="ILogEntry"/> into its timestamp, level, message, and activity ID (contextual logging subset).
        /// </summary>
        /// <param name="logEntry">The log entry instance to deconstruct.</param>
        /// <param name="timestamp">The UTC timestamp when the log event occurred.</param>
        /// <param name="level">The severity level of the log event.</param>
        /// <param name="message">The human-readable message describing the event.</param>
        /// <param name="activityId">The correlation or activity identifier for tracing linkage.</param>
        public static void Deconstruct(
            this ILogEntry logEntry,
            out DateTimeOffset timestamp,
            out LogLevel level,
            out string message,
            out string? activityId)
        {
            ArgumentNullException.ThrowIfNull(logEntry, nameof(logEntry));
            timestamp = logEntry.Timestamp;
            level = logEntry.Level;
            message = logEntry.Message;
            activityId = logEntry.ActivityId;
        }

        /// <summary>
        /// Deconstructs an <see cref="ILogEntry"/> into its timestamp, level, message, and exception (detailed for analysis subset).
        /// </summary>
        /// <param name="logEntry">The log entry instance to deconstruct.</param>
        /// <param name="timestamp">The UTC timestamp when the log event occurred.</param>
        /// <param name="level">The severity level of the log event.</param>
        /// <param name="message">The human-readable message describing the event.</param>
        /// <param name="exception">The exception, if any, that occurred during the event.</param>
        public static void Deconstruct(
            this ILogEntry logEntry,
            out DateTimeOffset timestamp,
            out LogLevel level,
            out string message,
            out Exception? exception)
        {
            ArgumentNullException.ThrowIfNull(logEntry, nameof(logEntry));
            timestamp = logEntry.Timestamp;
            level = logEntry.Level;
            message = logEntry.Message;
            exception = logEntry.Exception;
        }

        /// <summary>
        /// Deconstructs an <see cref="ILogEntry"/> into its message only (DX overload).
        /// </summary>
        /// <param name="logEntry">The log entry instance to deconstruct.</param>
        /// <param name="message">The human-readable message describing the event.</param>
        public static void Deconstruct(
            this ILogEntry logEntry,
            out string message)
        {
            ArgumentNullException.ThrowIfNull(logEntry, nameof(logEntry));
            message = logEntry.Message;
        }

        /// <summary>
        /// Deconstructs an <see cref="ILogEntry"/> into its level and message (DX overload).
        /// </summary>
        /// <param name="logEntry">The log entry instance to deconstruct.</param>
        /// <param name="level">The severity level of the log event.</param>
        /// <param name="message">The human-readable message describing the event.</param>
        public static void Deconstruct(
            this ILogEntry logEntry,
            out LogLevel level,
            out string message)
        {
            ArgumentNullException.ThrowIfNull(logEntry, nameof(logEntry));
            level = logEntry.Level;
            message = logEntry.Message;
        }
    }
}
