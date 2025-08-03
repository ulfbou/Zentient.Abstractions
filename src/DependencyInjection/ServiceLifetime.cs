// <copyright file="ServiceLifetime.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection
{
    /// <summary>Defines the possible lifetimes for a registered service.</summary>
    public enum ServiceLifetime
    {
        /// <summary>
        /// A new instance is created every time the service is requested.
        /// Ideal for lightweight, stateless services or those with mutable state
        /// that should not be shared.
        /// </summary>
        Transient,

        /// <summary>
        /// A single instance is created per scope (e.g., per web request, or manually created
        /// scope). 
        /// Ideal for services that need to maintain state within a logical operation or
        /// rely on other scoped services.
        /// </summary>
        Scoped,

        /// <summary>
        /// A single instance is created for the entire application lifetime.
        /// Ideal for stateless utility services, expensive resources, or global coordination.
        /// </summary>
        Singleton
    }
}
