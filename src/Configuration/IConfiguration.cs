// <copyright file="IConfiguration.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Configuration.Definitions;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;

namespace Zentient.Abstractions.Configuration
{
    /// <summary>
    /// Represents a read-only, structured view of configuration data loaded into memory.
    /// </summary>
    /// <remarks>
    /// This interface is the primary entry point for a consumer to retrieve strongly-typed
    /// configuration sections, using an <see cref="IConfigurationSectionDefinition"/> definition.
    /// It also provides a mechanism for subscribing to configuration changes.
    /// </remarks>
    public interface IConfiguration
    {
        /// <summary>
        /// Gets a specific configuration section and binds it to the specified type.
        /// </summary>
        /// <typeparam name="TValue">The type to bind the configuration section to.</typeparam>
        /// <param name="definition">The type definition of the configuration section to retrieve.</param>
        /// <returns>
        /// An instance of the bound type, or null if the section cannot be found or bound.
        /// </returns>
        TValue? GetSection<TValue>(IConfigurationSectionDefinition definition);

        /// <summary>
        /// Gets a specific configuration section and binds it to the specified type,
        /// using a context.
        /// </summary>
        /// <typeparam name="TValue">The type to bind to.</typeparam>
        /// <typeparam name="TContextDefinition">The type of the context definition.</typeparam>
        /// <param name="definition">The type definition of the configuration section to retrieve.</param>
        /// <param name="context">The context instance to guide binding behavior.</param>
        /// <returns>An instance of the bound type or null if binding fails.</returns>
        TValue? GetSection<TValue, TContextDefinition>(IConfigurationSectionDefinition definition, IContext<TContextDefinition> context)
            where TContextDefinition : IContextDefinition;

        /// <summary>Gets the value associated with the specified configuration key.</summary>
        /// <param name="key">The configuration key string.</param>
        /// <returns>
        /// The configuration value, or<see langword = "null" /> if the key does not exist.
        /// </returns>
        string? this[string key] { get; }

        /// <summary>
        /// Gets a token that can be used to listen for changes to this configuration.
        /// </summary>
        /// <returns>A change token that can be used to subscribe to change notifications.</returns>
        Zentient.Abstractions.Configuration.IChangeToken GetReloadToken();
    }
}
