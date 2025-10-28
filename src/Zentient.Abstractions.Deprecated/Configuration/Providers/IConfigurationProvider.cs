// <copyright file="IConfigurationProvider.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Configuration.Providers
{
    /// <summary>Provides configuration values from a specific source.</summary>
    /// <remarks>
    /// An <see cref="IConfigurationProvider"/> is responsible for loading configuration data and
    /// retrieving values by key. Implementations may support various sources such as files,
    /// environment variables, or external services.
    /// </remarks>
    public interface IConfigurationProvider
    {
        /// <summary>Loads configuration data from the underlying source.</summary>
        /// <returns>A task that represents the asynchronous load operation.</returns>
        /// <remarks>
        /// This method should be called to initialize or refresh the provider's data.
        /// </remarks>
        Task Load();

        /// <summary>
        /// Attempts to retrieve the value associated with the specified configuration key.
        /// </summary>
        /// <param name="key">The configuration key to look up.</param>
        /// <param name="value">
        /// When this method returns, contains the value associated with the specified key,
        /// or <see langword="null" /> if the key is not found.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the key was found and a value was returned;
        /// otherwise, <see langword="false" />.
        /// </returns>
        bool TryGet(string key, out string? value);
    }
}
