// <copyright file="IContextBuilder{TContextDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Contexts.Builders
{
    /// <summary>
    /// Provides a fluent API for building immutable <see cref="IContext{TContextDefinition}"/> instances.
    /// </summary>
    /// <typeparam name="TContextDefinition">The specific <see cref="IContextDefinition"/> this builder is for.</typeparam>
    public interface IContextBuilder<TContextDefinition>
        where TContextDefinition : IContextDefinition
    {
        /// <summary>
        /// Sets the specific <typeparamref name="TContextDefinition"/> definition for the context.
        /// </summary>
        /// <param name="definition">The context type definition.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextDefinition> WithDefinition(TContextDefinition definition);

        /// <summary>
        /// Sets the correlation ID for the context.
        /// </summary>
        /// <param name="correlationId">The correlation ID.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextDefinition> WithCorrelationId(string correlationId);

        /// <summary>
        /// Sets the parent context for this context, establishing a hierarchy.
        /// </summary>
        /// <param name="parentContext">The parent context.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextDefinition> WithParent(IContext<IContextDefinition> parentContext);

        /// <summary>
        /// Adds or updates a metadata entry for the context.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextDefinition> WithMetadata(string key, object? value);

        /// <summary>
        /// Sets the entire metadata collection for the context. Existing metadata will be replaced.
        /// </summary>
        /// <param name="metadata">The metadata collection.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextDefinition> WithMetadata(IMetadata metadata);

        /// <summary>
        /// Builds an immutable <see cref="IContext{TContextDefinition}"/> instance.
        /// </summary>
        /// <returns>A new <see cref="IContext{TContextDefinition}"/> instance.</returns>
        IContext<TContextDefinition> Build();
    }
}
