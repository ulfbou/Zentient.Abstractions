// <copyright file="IServiceScopeFactory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection.Scopes
{
    /// <summary>A factory for creating new instances of <see cref="IServiceScope"/>.</summary>
    /// <remarks>
    /// This abstraction allows a consumer to create isolated service scopes, typically for
    /// handling a single logical operation, such as a web request or a message processing job.
    /// </remarks>
    public interface IServiceScopeFactory
    {
        /// <summary>
        /// Creates a new <see cref="IServiceScope"/> that can be used to resolve scoped services.
        /// </summary>
        /// <returns>A new <see cref="IServiceScope"/> instance.</returns>
        IServiceScope CreateScope();
    }
}
