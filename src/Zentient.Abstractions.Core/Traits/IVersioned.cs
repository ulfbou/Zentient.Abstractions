// <copyright file="IVersioned.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Traits 
{
    /// <summary>
    /// Describes that a concept is versioned and exposes lifecycle/version history information.
    /// </summary>
    public interface IVersioned : ITrait
    {
        /// <summary>
        /// Gets the current version of the concept.
        /// </summary>
        IVersion Version { get; }

        /// <summary>
        /// Gets the version in which this concept was marked as deprecated, or <c>null</c> if not deprecated.
        /// </summary>
        IVersion? DeprecatedIn { get; }

        /// <summary>
        /// Gets the version in which this concept was obsoleted, or <c>null</c> if not obsoleted.
        /// </summary>
        IVersion? ObsoletedIn { get; }

        /// <summary>
        /// Gets the version that supersedes this concept, or <c>null</c> if none.
        /// </summary>
        IVersion? SupersededIn { get; }

        /// <summary>
        /// Gets an optional changelog or release notes that describe notable changes.
        /// </summary>
        string? ChangeLog { get; }
    }
}
