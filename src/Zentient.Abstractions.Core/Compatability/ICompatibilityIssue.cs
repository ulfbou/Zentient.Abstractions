// <copyright file="ICompatibilityIssue.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Compatability
{
    using Zentient.Core;

    /// <summary>
    /// Represents a compatibility issue found during a comparison of two concepts or specifications.
    /// </summary>
    public interface ICompatibilityIssue : IConcept
    {
        /// <summary>
        /// Gets the semantic path (dot-separated) indicating where the issue occurred.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Gets a concise, actionable message describing the issue.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Gets the severity of the issue (for example, "Info", "Warning", "Error").
        /// </summary>
        string Severity { get; }

        /// <summary>
        /// Gets auxiliary metadata providing context about the issue.
        /// </summary>
        IReadOnlyDictionary<string, object?> Metadata { get; }
    }
}
