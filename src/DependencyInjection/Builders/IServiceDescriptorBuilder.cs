// <copyright file="IServiceDescriptorBuilder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Registration;

namespace Zentient.Abstractions.DependencyInjection.Builders
{
    /// <summary>
    /// Contract for a builder that constructs one or more IServiceDescriptor instances
    /// from a given service implementation type.
    /// </summary>
    public interface IServiceDescriptorBuilder
    {
        /// <summary>
        /// Builds service descriptors by inspecting attributes on the provided type.
        /// </summary>
        /// <param name="implementationType">The type to inspect for registration attributes.</param>
        /// <returns>An enumerable of service descriptors.</returns>
        IEnumerable<IServiceDescriptor> BuildFromAttributes(Type implementationType);
    }
}
