// <copyright file="IContextBuilder{TContextType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Contexts.Builders
{
    /// <summary>
    /// Provides a fluent API for building immutable <see cref="IContext{TContextType}"/> instances.
    /// </summary>
    /// <typeparam name="TContextType">The specific <see cref="IContextType"/> this builder is for.</typeparam>
    public interface IContextBuilder<TContextType>
        where TContextType : IContextType
    {
        /// <summary>
        /// Sets the specific <typeparamref name="TContextType"/> definition for the context.
        /// </summary>
        /// <param name="definition">The context type definition.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextType> WithDefinition(TContextType definition);

        /// <summary>
        /// Sets the correlation ID for the context.
        /// </summary>
        /// <param name="correlationId">The correlation ID.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextType> WithCorrelationId(string correlationId);

        /// <summary>
        /// Sets the parent context for this context, establishing a hierarchy.
        /// </summary>
        /// <param name="parentContext">The parent context.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextType> WithParent(IContext<IContextType> parentContext);

        /// <summary>
        /// Adds or updates a metadata entry for the context.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextType> WithMetadata(string key, object? value);

        /// <summary>
        /// Sets the entire metadata collection for the context. Existing metadata will be replaced.
        /// </summary>
        /// <param name="metadata">The metadata collection.</param>
        /// <returns>The current builder instance.</returns>
        IContextBuilder<TContextType> WithMetadata(IMetadata metadata);

        /// <summary>
        /// Builds an immutable <see cref="IContext{TContextType}"/> instance.
        /// </summary>
        /// <returns>A new <see cref="IContext{TContextType}"/> instance.</returns>
        IContext<TContextType> Build();
    }
}