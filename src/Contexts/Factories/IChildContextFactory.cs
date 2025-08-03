// <copyright file="IChildContextFactory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts.Builders;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Contexts.Factories
{
    /// <summary>
    /// Factory for creating child context instances, extending an existing parent context.
    /// </summary>
    /// <remarks>
    /// Child contexts inherit properties like correlation ID from their parent
    /// and form a hierarchical chain, useful for tracking nested operations.
    /// </remarks>
    public interface IChildContextFactory
    {
        /// <summary>
        /// Creates a new child context instance with the specified type and parent.
        /// </summary>
        /// <typeparam name="TContextDefinition">The specific <see cref="IContextDefinition"/> of the child context.</typeparam>
        /// <param name="parentContext">The parent context from which this child context derives.</param>
        /// <param name="correlationId">An optional correlation ID for the child context (defaults to parent's if null).</param>
        /// <param name="metadata">Optional initial metadata for the child context.</param>
        /// <returns>A new <see cref="IContext{TContextDefinition}"/> instance representing the child context.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="parentContext"/> is null.</exception>
        IContext<TContextDefinition> CreateChild<TContextDefinition>(IContext<IContextDefinition> parentContext, string? correlationId = null, IMetadata? metadata = null)
            where TContextDefinition : IContextDefinition;

        /// <summary>
        /// Creates a new child context instance using a builder for more detailed configuration.
        /// </summary>
        /// <typeparam name="TContextDefinition">The specific <see cref="IContextDefinition"/> of the child context.</typeparam>
        /// <param name="parentContext">The parent context from which this child context derives.</param>
        /// <param name="builderAction">An action to configure the <see cref="IContextBuilder{TContextDefinition}"/>.</param>
        /// <returns>A new <see cref="IContext{TContextDefinition}"/> instance representing the child context.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="parentContext"/> is null.</exception>
        IContext<TContextDefinition> CreateChild<TContextDefinition>(IContext<IContextDefinition> parentContext, Action<IContextBuilder<TContextDefinition>> builderAction)
            where TContextDefinition : IContextDefinition;
    }
}
