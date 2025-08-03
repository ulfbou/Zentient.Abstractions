// <copyright file="IConfigBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Configuration.Sources;

namespace Zentient.Abstractions.Configuration.Builders
{
    /// <summary>
    /// Represents a fluent builder for aggregating multiple configuration sources.
    /// </summary>
    public interface IConfigurationComposer
    {
        /// <summary>
        /// Adds a JSON file as a configuration source.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <param name="optional">If set to true, the file is not required to exist.</param>
        /// <param name="reloadOnChange">If set to true, the file will be reloaded on change.</param>
        /// <returns>The current <see cref="IConfigurationComposer"/> instance for chaining.</returns>
        IConfigurationComposer WithJsonFile(string path, bool optional = false, bool reloadOnChange = false);

        /// <summary>
        /// Adds environment variables as a configuration source.
        /// </summary>
        /// <param name="prefix">A prefix to filter environment variables by.</param>
        /// <returns>The current <see cref="IConfigurationComposer"/> instance for chaining.</returns>
        IConfigurationComposer WithEnvironmentVariables(string prefix = "");

        /// <summary>
        /// Adds command-line arguments as a configuration source.
        /// </summary>
        /// <param name="args">The command-line arguments to use.</param>
        /// <returns>The current <see cref="IConfigurationComposer"/> instance for chaining.</returns>
        IConfigurationComposer WithCommandLine(string[] args);

        /// <summary>
        /// Adds a custom configuration source to the builder.
        /// </summary>
        /// <param name="source">The custom IConfigurationSource to add.</param>
        /// <returns>The current <see cref="IConfigurationComposer"/> instance for chaining.</returns>
        IConfigurationComposer WithSource(IConfigurationSource source);

        /// <summary>
        /// Builds a final IConfigurationRoot from all the added sources.
        /// </summary>
        /// <returns>The fully constructed and aggregated IConfigurationRoot.</returns>
        IConfigurationRoot Build();
    }
}
