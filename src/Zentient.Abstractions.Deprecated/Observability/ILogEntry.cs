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
    public interface ILogEntry : IHasMetadata, IHasTimestamp
    {
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
}
