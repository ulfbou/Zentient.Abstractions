// <copyright file="IConfigurationBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Configuration.Definitions;
using Zentient.Abstractions.Configuration.Sources;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.DependencyInjection;

namespace Zentient.Abstractions.Configuration.Builders
{
    /// <summary>
    /// Represents a builder for aggregating multiple configuration sources and properties.
    /// </summary>
    /// <remarks>
    /// The <see cref="IConfigurationBuilder"/> interface provides methods for adding sources and
    /// building a complete <see cref="IConfiguration"/> instance.
    /// </remarks>
    public interface IConfigurationBuilder
    {
        /// <summary>Gets a dictionary of properties associated with the configuration builder.</summary>
        /// <value>
        /// An <see cref="IDictionary{TKey, TValue}"/> containing key-value pairs of
        /// builder properties.
        /// </value>
        IDictionary<string, object> Properties { get; }

        /// <summary>Gets the list of configuration sources added to the builder.</summary>
        /// <value>
        /// An <see cref="IList{T}"/> of
        /// <see cref="IConfigurationSource{TConfigurationSourceDefinition}"/> instances representing
        /// the sources.
        /// </value>
        IList<IConfigurationSource<IConfigurationSourceDefinition>> Sources { get; }

        /// <summary>Adds a configuration source to the builder.</summary>
        /// <param name="source">
        /// The <see cref="IConfigurationSource{TConfigurationSourceDefinition}"/> to add.
        /// </param>
        /// <returns>
        /// The current <see cref="IConfigurationBuilder"/> instance for chaining.
        /// </returns>
        IConfigurationBuilder Add<TConfigurationSourceDefinition>(IConfigurationSource<TConfigurationSourceDefinition> source)
            where TConfigurationSourceDefinition : IConfigurationSourceDefinition;

        /// <summary>
        /// Builds and returns a complete <see cref="IConfiguration"/> object from the
        /// added sources.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IConfiguration"/> containing the
        /// aggregated configuration data.
        /// </returns>
        IConfiguration Build();
    }
}
