// <copyright file="ServiceLifetime.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection
{
    /// <summary>
    /// Defines the possible lifetimes for a registered service.
    /// </summary>
    public enum ServiceLifetime
    {
        /// <summary>
        /// A new instance is created every time the service is requested.
        /// </summary>
        Transient,

        /// <summary>
        /// A single instance is created per scope (e.g., per web request).
        /// </summary>
        Scoped,

        /// <summary>
        /// A single instance is created for the entire application lifetime.
        /// </summary>
        Singleton
    }
}
