// <copyright file="DiagnosticStatus.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>
    /// Indicates the overall result status of a diagnostic check.
    /// </summary>
    public enum DiagnosticStatus
    {
        /// <summary>Check did not run or result is unknown.</summary>
        Unknown,

        /// <summary>No issues detected; component is healthy.</summary>
        Healthy,

        /// <summary>Some issues detected; component is degraded but operational.</summary>
        Degraded,

        /// <summary>Critical issues detected; component is unhealthy or non-operational.</summary>
        Unhealthy,

        /// <summary>Check was intentionally skipped.</summary>
        Skipped
    }
}
