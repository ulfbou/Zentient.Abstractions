// <copyright file="IContainerBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection.Builders
{
    /// <summary>
    /// Represents a builder that constructs a DI container from a set of service descriptors.
    /// </summary>
    public interface IContainerBuilder
    {
        /// <summary>
        /// Adds a registry of service descriptors to the builder.
        /// </summary>
        /// <param name="registry">The <see cref="IServiceRegistry"/> to add.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        IContainerBuilder AddRegistry(IServiceRegistry registry);

        /// <summary>
        /// Adds a container-specific resolver adapter to the builder.
        /// </summary>
        /// <param name="resolverAdapter">
        /// The <see cref="IServiceResolver"/> adapter to use for the underlying container.
        /// </param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        IContainerBuilder AddResolver(IServiceResolver resolverAdapter);

        /// <summary>Builds and returns the finalized service resolver.</summary>
        /// <returns>The constructed <see cref="IServiceResolver"/>.</returns>
        IServiceResolver Build();
    }
}
