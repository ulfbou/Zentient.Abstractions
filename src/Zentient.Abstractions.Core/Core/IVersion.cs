// <copyright file="IVersion.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Represents a version token for a concept that follows semantic versioning principles.
    /// This interface is intended for conceptual/version metadata rather than CLR assembly versions.
    /// </summary>
    public interface IVersion : IConcept
    {
        /// <summary>
        /// Gets the major version component.
        /// </summary>
        int Major { get; }

        /// <summary>
        /// Gets the minor version component.
        /// </summary>
        int Minor { get; }

        /// <summary>
        /// Gets the patch version component.
        /// </summary>
        int Patch { get; }

        /// <summary>
        /// Gets optional build metadata (informational string).
        /// </summary>
        string? BuildMetadata { get; }

        /// <summary>
        /// Gets optional pre-release identifier (for example, "alpha", "beta.1").
        /// </summary>
        string? PreRelease { get; }

        /// <summary>
        /// Returns the semantic version formatted string.
        /// Implementations should follow the Semantic Versioning specification.
        /// </summary>
        /// <returns>A string representation of the semantic version.</returns>
        string ToSemanticString();
    }
}
