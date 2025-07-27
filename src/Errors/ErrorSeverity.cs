// <copyright file="ErrorSeverity.cs" company="Zentient Framework Team">
// Copyright Â© 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Errors
{
    /// <summary>
    /// Specifies the severity level of an error or operational outcome.
    /// </summary>
    public enum ErrorSeverity
    {
        /// <summary>
        /// The outcome conveys informational messages, not indicating an issue.
        /// </summary>
        Information,

        /// <summary>
        /// The outcome indicates a potential issue or non-critical problem.
        /// </summary>
        Warning,

        /// <summary>
        /// The outcome indicates a recoverable error that prevented a part of the operation from completing.
        /// </summary>
        Error,

        /// <summary>
        /// The outcome indicates a severe, unrecoverable error that likely halted the operation entirely.
        /// </summary>
        Critical
    }
}
