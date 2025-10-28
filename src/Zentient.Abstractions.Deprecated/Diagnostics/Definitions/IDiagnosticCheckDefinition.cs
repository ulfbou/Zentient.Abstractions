// <copyright file="IDiagnosticCheckDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Diagnostics.Definitions
{
    /// <summary>
    /// Defines the metadata for a diagnostic check, enabling discovery, categorization, and documentation.
    /// </summary>
    public interface IDiagnosticCheckDefinition : ITypeDefinition
    {
        /// <summary>
        /// Gets a human-friendly name for this diagnostic check.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the .NET type of the component or subject being diagnosed.
        /// </summary>
        Type TargetComponentType { get; }

        /// <summary>
        /// Gets the category of this check (e.g., Health, Performance, Configuration).
        /// </summary>
        string DiagnosticsCategory { get; }
    }
}
