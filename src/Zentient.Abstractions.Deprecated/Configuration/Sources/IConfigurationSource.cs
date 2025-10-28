// <copyright file="IConfigurationSource.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Configuration.Builders;
using Zentient.Abstractions.Configuration.Providers;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Configuration.Sources
{
    /// <summary>
    /// Represents a source of configuration, such as a file, environment variables,
    /// or a remote service.
    /// </summary>
    /// <remarks>
    /// This is the primary abstraction for defining where configuration data originates.
    /// It acts as a factory for creating a concrete <see cref="IConfigurationProvider"/>.
    /// </remarks>
    public interface IConfigurationSource
    {
        /// <summary>
        /// Gets the name of the configuration source
        /// (e.g., "JsonFileSource", "EnvironmentVariables").
        /// </summary>
        string Name { get; }

        /// <summary>Gets the metadata associated with this configuration source.</summary>
        IMetadata Metadata { get; }

        /// <summary>Builds an <see cref="IConfigurationProvider"/> for this source.</summary>
        /// <param name="context">
        /// The context for building the configuration,
        /// providing access to global metadata and services.
        /// </param>
        /// <returns>
        /// A new, configured instance of an <see cref="IConfigurationProvider" />.
        /// </returns>
        IConfigurationProvider Build(IConfigurationBuilderContext context);
    }
}
