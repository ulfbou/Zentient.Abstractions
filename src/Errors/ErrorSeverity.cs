// <copyright file="ErrorSeverity.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Errors
{
    /// <summary>
    /// Specifies the severity level of an error or operational outcome.
    /// Defines the severity levels for an error, providing a qualitative measure of its impact.
    /// </summary>
    public enum ErrorSeverity
    {
        /// <summary>
        /// The outcome conveys informational messages, not indicating an issue.
        /// The error provides information about an operation, typically non-critical.
        /// </summary>
        Informational,

        /// <summary>
        /// The outcome indicates a potential issue or non-critical problem.
        /// The error indicates a potential problem or an undesirable state that might not halt execution but requires attention.
        /// </summary>
        Warning,

        /// <summary>
        /// The outcome indicates a recoverable error that prevented a part of the operation from completing.
        /// The error indicates a failure that prevents a specific operation from completing successfully.
        /// </summary>
        Error,

        /// <summary>
        /// The outcome indicates a severe, unrecoverable error that likely halted the operation entirely.
        /// The error indicates a severe failure that may affect system stability or require immediate intervention.
        /// </summary>
        Critical
    }
}
