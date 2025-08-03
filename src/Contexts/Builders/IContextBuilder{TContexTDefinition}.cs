// <copyright file="IContextBuilder{TContexTDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Contexts.Builders
{
    /// <summary>
    /// Provides a fluent API for building immutable <see cref="IContext{TContexTDefinition}"/> instances.
    /// </summary>
    /// <typeparam name="TContexTDefinition">The specific <see cref="IContexTDefinition"/> this builder is for.</typeparam>
    public interface IContextBuilder<TContexTDefinition>
        where TContexTDefinition : IContexTDefinition
    {
        /// <summary>
        /// Sets the specific <typeparamref name="TContexTDefinition"/> definition for the context.
        /// </summary>
        /// <param name="definition">The context type definition.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContexTDefinition> WithDefinition(TContexTDefinition definition);

        /// <summary>
        /// Sets the correlation ID for the context.
        /// </summary>
        /// <param name="correlationId">The correlation ID.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContexTDefinition> WithCorrelationId(string correlationId);

        /// <summary>
        /// Sets the parent context for this context, establishing a hierarchy.
        /// </summary>
        /// <param name="parentContext">The parent context.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContexTDefinition> WithParent(IContext<IContexTDefinition> parentContext);

        /// <summary>
        /// Adds or updates a metadata entry for the context.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContexTDefinition> WithMetadata(string key, object? value);

        /// <summary>
        /// Sets the entire metadata collection for the context. Existing metadata will be replaced.
        /// </summary>
        /// <param name="metadata">The metadata collection.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContexTDefinition> WithMetadata(IMetadata metadata);

        /// <summary>
        /// Builds an immutable <see cref="IContext{TContexTDefinition}"/> instance.
        /// </summary>
        /// <returns>A new <see cref="IContext{TContexTDefinition}"/> instance.</returns>
        IContext<TContexTDefinition> Build();
    }
}
