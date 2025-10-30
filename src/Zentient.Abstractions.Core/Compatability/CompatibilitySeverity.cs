// <copyright file="CompatibilitySeverity.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Compatability
{
    /// <summary>
    /// Severity classifications used by compatibility reports.
    /// </summary>
    public enum CompatibilitySeverity
    {
        /// <summary>
        /// Informational note; no action required.
        /// </summary>
        Info,

        /// <summary>
        /// Non-fatal issue that should be reviewed; may require attention.
        /// </summary>
        Warning,

        /// <summary>
        /// Breaking or critical issue that must be addressed.
        /// </summary>
        Error
    }
}
