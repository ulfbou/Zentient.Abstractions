// <copyright file="IConfigurationSource{out TConfigurationSourceType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace Zentient.Abstractions.Configuration
{
    /// <summary>Represents an abstraction for a source of raw configuration data.</summary>
    /// <remarks>
    /// An <see cref="IConfigurationSource{TConfigurationSourceType}"/> is responsible for
    /// providing configuration data from a specific origin, such as files, environment variables,
    /// or external services.
    /// </remarks>
    /// <typeparam name="TConfigurationSourceType">
    /// The specific type definition for this configuration source.
    /// </typeparam>
    public interface IConfigurationSource<out TConfigurationSourceType>
        where TConfigurationSourceType : IConfigurationSourceType
    {
        /// <summary>Gets the type definition for this configuration source.</summary>
        TConfigurationSourceType Type { get; }
    }
}
