// <copyright file="ICompatibilityReport.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Compatability
{
    using Zentient.Core;

    /// <summary>
    /// Aggregates compatibility results and issues for a pair of specifications.
    /// </summary>
    public interface ICompatibilityReport : IConcept
    {
        /// <summary>
        /// Gets a value indicating whether the two specifications are compatible.
        /// </summary>
        bool IsCompatible { get; }

        /// <summary>
        /// Gets the set of issues discovered during compatibility analysis.
        /// </summary>
        IReadOnlyCollection<ICompatibilityIssue> Issues { get; }
    }
}
