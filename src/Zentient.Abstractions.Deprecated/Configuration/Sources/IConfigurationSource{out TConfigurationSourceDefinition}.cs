// <copyright file="IConfigurationSource{out TConfigurationSourceDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Zentient.Abstractions.Configuration.Definitions;
using Zentient.Abstractions.Configuration.Providers;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Configuration.Sources
{
    /// <summary>Represents an abstraction for a source of raw configuration data.</summary>
    /// <remarks>
    /// An <see cref="IConfigurationSource{TConfigurationSourceType}"/> is responsible for
    /// providing configuration data from a specific origin, such as files, environment variables,
    /// or external services.
    /// </remarks>
    /// <typeparam name="TConfigurationSourceDefinition">
    /// The specific type definition for this configuration source.
    /// </typeparam>
    public interface IConfigurationSource<out TConfigurationSourceDefinition>
        : IConfigurationSource
        where TConfigurationSourceDefinition : IConfigurationSourceDefinition
    {
        /// <summary>Gets the type definition for this configuration source.</summary>
        TConfigurationSourceDefinition SourceType { get; }
    }
}
