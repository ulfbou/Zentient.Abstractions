// <copyright file="IConfigurationScope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Configuration;
using Zentient.Abstractions.Execution;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Configuration.Scopes
{
    /// <summary>
    /// Represents an ambient configuration scope that can provide context-specific overrides.
    /// This scope is typically managed implicitly and is tied to a specific execution context.
    /// </summary>
    public interface IConfigurationScope : IDisposable, IHasMetadata
    {
        /// <summary>
        /// Gets the parent configuration scope, or <see langword="null"/> if this is the root scope.
        /// </summary>
        /// <value>
        /// The parent <see cref="IConfigurationScope"/> instance, or <see langword="null"/> 
        /// if this is the root scope.
        /// </value>
        IConfigurationScope? Parent { get; }

        /// <summary>
        /// Attempts to retrieve a configuration value associated with the specified key from this scope.
        /// If the key is not found in the current scope, the search is delegated to the parent scope.
        /// </summary>
        /// <param name="key">The configuration key to look up.</param>
        /// <param name="value">
        /// When this method returns, contains the configuration value associated with the specified key,
        /// if the key is found; otherwise, <see langword="null"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the key was found and the value was retrieved;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        bool TryGet(string key, out string? value);
    }
}
