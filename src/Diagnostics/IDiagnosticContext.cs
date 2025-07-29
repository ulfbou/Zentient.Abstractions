// <copyright file="IDiagnosticContext.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>
    /// Carries parameters and options for a diagnostic execution run.
    /// </summary>
    public interface IDiagnosticContext : IHasMetadata
    {
        /// <summary>
        /// Gets the correlation identifier associated with this diagnostic run.
        /// </summary>
        Guid CorrelationId { get; }

        /// <summary>
        /// Gets the name of the diagnostic profile or scenario (e.g., "ProductionReadiness").
        /// </summary>
        string DiagnosticProfile { get; }

        /// <summary>
        /// Gets an optional timeout for the diagnostic check.
        /// </summary>
        TimeSpan? Timeout { get; }

        /// <summary>
        /// Gets additional, arbitrary options for diagnostic execution.
        /// </summary>
        IDictionary<string, object>? Options { get; }
    }
}
