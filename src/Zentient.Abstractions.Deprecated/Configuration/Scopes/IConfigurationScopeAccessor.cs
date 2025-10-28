// <copyright file="IConfigurationScopeAccessor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Configuration;

namespace Zentient.Abstractions.Configuration.Scopes
{
    /// <summary>Provides access to the current ambient <see cref="IConfigurationScope"/>.</summary>
    public interface IConfigurationScopeAccessor
    {
        /// <summary>
        /// Gets the current ambient configuration scope, or <see langword="null"/> if no scope is active.
        /// </summary>
        IConfigurationScope? Current { get; }
    }
}
