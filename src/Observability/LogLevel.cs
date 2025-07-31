// <copyright file="LogLevel.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Observability
{
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
