// <copyright file="IContainerBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection
{
    /// <summary>
    /// Represents a builder that constructs a DI container from a set of service descriptors.
    /// </summary>
    public interface IContainerBuilder
    {
        /// <summary>
        /// Adds a registry of service descriptors to the builder.
        /// </summary>
        IContainerBuilder AddRegistry(IServiceRegistry registry);

        /// <summary>
        /// Adds a container-specific resolver adapter to the builder.
        /// </summary>
        IContainerBuilder AddResolver(IServiceResolver resolverAdapter);

        /// <summary>
        /// Builds and returns the finalized service resolver.
        /// </summary>
        IServiceResolver Build();
    }
}
