// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents the severity of an error or issue.
    /// This enum provides a standardized way to classify errors based on their impact and urgency,
    /// allowing for better error handling and reporting in applications.
    /// The severity levels range from informational messages to critical and fatal errors,
    /// enabling developers to prioritize issues effectively.
    /// </summary>
    public enum ErrorSeverity
    {
        /// <summary>Indicates an informational message that does not indicate an error.</summary>
        Info = 0,

        /// <summary>Indicates a warning that something unexpected happened, but the operation can continue.</summary>
        Warning,

        /// <summary>Indicates an error that prevents the operation from completing successfully.</summary>
        Error,

        /// <summary>Indicates a critical error that requires immediate attention and may cause system instability.</summary>
        Critical,

        /// <summary>Indicates a fatal error that causes the application to crash or become unusable.</summary>
        Fatal
    }
}
