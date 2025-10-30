// <copyright file="ICompatibilityChecker.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Compatability
{
    /// <summary>
    /// Compares two specification versions and reports semantic compatibility.
    /// </summary>
    /// <typeparam name="TOld">The older specification type.</typeparam>
    /// <typeparam name="TNew">The newer specification type.</typeparam>
    public interface ICompatibilityChecker<in TOld, in TNew>
    {
        /// <summary>
        /// Determines whether <paramref name="oldSpec"/> is compatible with <paramref name="newSpec"/>.
        /// </summary>
        /// <param name="oldSpec">The previous specification instance.</param>
        /// <param name="newSpec">The candidate new specification instance.</param>
        /// <returns><c>true</c> if compatible; otherwise <c>false</c>.</returns>
        bool IsCompatible(TOld oldSpec, TNew newSpec);

        /// <summary>
        /// Produces a human-readable compatibility report describing compatibility issues.
        /// </summary>
        /// <param name="oldSpec">The previous specification instance.</param>
        /// <param name="newSpec">The candidate new specification instance.</param>
        /// <returns>A string describing found compatibility issues and rationale.</returns>
        string GetCompatibilityReport(TOld oldSpec, TNew newSpec);
    }
}
