// <copyright file="IConfigurationBuilderContext.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Configuration.Definitions;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.DependencyInjection;

namespace Zentient.Abstractions.Configuration.Builders
{
    /// <summary>Represents the operational context for building configuration.</summary>
    /// <remarks>
    /// Provides access to ambient context information and a service resolver for dependency injection
    /// during configuration provider construction.
    /// </remarks>
    public interface IConfigurationBuilderContext : IContext<IConfigurationBuilderContexTDefinition>
    {
        /// <summary>
        /// Gets the service resolver for dependency injection within configuration providers.
        /// </summary>
        /// <value>
        /// An <see cref="IServiceResolver"/> instance used to resolve services required by configuration providers.
        /// </value>
        IServiceResolver Resolver { get; }
    }
}
