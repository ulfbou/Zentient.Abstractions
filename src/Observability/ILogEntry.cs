// <copyright file="ILogEntry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Observability
{
    /// <summary>
    /// Represents a structured log record with core properties and extensible metadata.
    /// </summary>
    public interface ILogEntry : IHasMetadata
    {
        /// <summary>The UTC timestamp when the log event occurred.</summary>
        /// <value>The timestamp of the log event.</value>
        DateTimeOffset Timestamp { get; }

        /// <summary>The severity level of the log event.</summary>
        /// <value>The log level indicating the severity of the event.</value>
        LogLevel Level { get; }

        /// <summary>The human-readable message describing the event.</summary>
        /// <value>The message associated with the log event.</value>
        string Message { get; }

        /// <summary>An optional exception associated with the log event.</summary>
        /// <value>The exception, if any, that occurred during the event.</value>
        Exception? Exception { get; }

        /// <summary>Correlation or activity identifier for tracing linkage.</summary>
        /// <value>The identifier used to correlate related log entries.</value>
        string? ActivityId { get; }
    }
    /// <summary>Defines standard log severity levels.</summary>
    public enum LogLevel
    {
        /// <summary>Represents the most detailed log messages, typically used for debugging.</summary>
        Trace,

        /// <summary>Represents detailed information useful for debugging, but not as verbose as Trace.</summary>
        Debug,

        /// <summary>Represents general information about application flow or state.</summary>
        Information,

        /// <summary>Represents a potential issue or unexpected situation that does not disrupt the application flow.</summary>
        Warning,

        /// <summary>Represents an error that occurred, but the application can continue running.</summary>
        Error,

        /// <summary>Represents a critical error that causes the application to stop or become unstable.</summary>
        Critical,

        /// <summary>Represents a log entry that is not categorized by severity, often used for informational purposes.</summary>
        None
    }
}
