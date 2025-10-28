// <copyright file="IRootContextFactory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Builders;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Contexts.Factories
{
    /// <summary>
    /// Factory for creating root (top-level) context instances.
    /// </summary>
    /// <remarks>
    /// Root contexts do not have a parent and serve as the starting point
    /// for a new operational flow or transaction.
    /// </remarks>
    public interface IRootContextFactory
    {
        /// <summary>
        /// Creates a new root context instance with the specified type.
        /// </summary>
        /// <typeparam name="TContextDefinition">The specific <see cref="IContextDefinition"/> of the root context.</typeparam>
        /// <param name="correlationId">An optional correlation ID for the root context.</param>
        /// <param name="metadata">Optional initial metadata for the root context.</param>
        /// <returns>A new <see cref="IContext{TContextDefinition}"/> instance representing the root context.</returns>
        IContext<TContextDefinition> CreateRoot<TContextDefinition>(string? correlationId = null, IMetadata? metadata = null)
            where TContextDefinition : IContextDefinition;

        /// <summary>
        /// Creates a new root context instance using a builder for more detailed configuration.
        /// </summary>
        /// <typeparam name="TContextDefinition">The specific <see cref="IContextDefinition"/> of the root context.</typeparam>
        /// <param name="builderAction">An action to configure the <see cref="IContextBuilder{TContextDefinition}"/>.</param>
        /// <returns>A new <see cref="IContext{TContextDefinition}"/> instance representing the root context.</returns>
        IContext<TContextDefinition> CreateRoot<TContextDefinition>(Action<IContextBuilder<TContextDefinition>> builderAction)
            where TContextDefinition : IContextDefinition;
    }
}
