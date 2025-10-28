// <copyright file="IConfigurationRoot.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Configuration.Options;

namespace Zentient.Abstractions.Configuration
{
    /// <summary>
    /// Represents the root of a structured configuration hierarchy,
    /// providing access to values, binding, and change notifications.
    /// </summary>
    /// <remarks>
    /// This is the primary consumer-facing interface for reading configuration data.
    /// It provides a unified view of data loaded from multiple providers.
    /// </remarks>
    public interface IConfigurationRoot : IHasMetadata, IHasVersion
    {
        /// <summary>
        /// Gets the names of all providers that contributed to this configuration root.
        /// </summary>
        IEnumerable<string> ProviderNames { get; }

        /// <summary>
        /// Gets or sets the configuration value associated with the specified key.
        /// </summary>
        /// <param name="key">
        /// The hierarchical configuration key (e.g., "MySettings:SubSection:Value").
        /// </param>
        /// <returns>
        /// The configuration value if present; otherwise, <see langword="null"/>.
        /// </returns>
        string? this[string key] { get; set; }

        /// <summary>
        /// Binds a section of configuration values into an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The target type to bind the configuration section into.</typeparam>
        /// <param name="section">The root key of the section to bind.</param>
        /// <param name="opts">An optional action to configure the binding options.</param>
        /// <returns>
        /// An instance of <typeparamref name="T"/> if the section exists and is bindable;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        T Bind<T>(string section, Action<IBinderOptions>? opts = null);

        /// <summary>Subscribes to change notifications for the configuration root.</summary>
        /// <param name="callback">The callback to invoke when a change occurs.</param>
        /// <returns>
        /// An <see cref="IDisposable"/> that unsubscribes the callback when disposed.
        /// </returns>
        IDisposable OnChange(Action<IConfigurationRoot> callback);
    }
}
