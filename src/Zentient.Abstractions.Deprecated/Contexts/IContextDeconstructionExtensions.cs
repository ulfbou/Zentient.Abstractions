// <copyright file="IContextDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Contexts
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="IContext{TContextDefinition}" /> and related types.
    /// </summary>
    public static class IContextDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="IContext{TContextDefinition}"/> into its definition, metadata, parent context, and correlation ID.
        /// </summary>
        /// <typeparam name="TContextDefinition">The specific type of the context definition.</typeparam>
        /// <param name="context">The context instance to deconstruct.</param>
        /// <param name="definition">The context type definition.</param>
        /// <param name="metadata">The metadata associated with the context.</param>
        /// <param name="parent">The parent context, or <c>null</c> if this is a root context.</param>
        /// <param name="correlationId">The correlation identifier for the context.</param>
        public static void Deconstruct<TContextDefinition>(
            this IContext<TContextDefinition> context,
            out TContextDefinition definition,
            out IMetadata metadata,
            out IContext<IContextDefinition>? parent,
            out string correlationId)
            where TContextDefinition : IContextDefinition
        {
            Guard.AgainstNull(context, nameof(context));
            definition = context.Definition;
            metadata = context.Metadata;
            parent = context.Parent;
            correlationId = context.CorrelationId;
        }

        /// <summary>
        /// Deconstructs an <see cref="IContext{TContextDefinition}"/> into its definition and metadata.
        /// </summary>
        /// <typeparam name="TContextDefinition">The specific type of the context definition.</typeparam>
        /// <param name="context">The context instance to deconstruct.</param>
        /// <param name="definition">The context type definition.</param>
        /// <param name="metadata">The metadata associated with the context.</param>
        public static void Deconstruct<TContextDefinition>(
            this IContext<TContextDefinition> context,
            out TContextDefinition definition,
            out IMetadata metadata)
            where TContextDefinition : IContextDefinition
        {
            Guard.AgainstNull(context, nameof(context));
            definition = context.Definition;
            metadata = context.Metadata;
        }

        /// <summary>
        /// Deconstructs an <see cref="IContext{TContextDefinition}"/> into its definition, metadata, and correlation ID.
        /// </summary>
        /// <typeparam name="TContextDefinition">The specific type of the context definition.</typeparam>
        /// <param name="context">The context instance to deconstruct.</param>
        /// <param name="definition">The context type definition.</param>
        /// <param name="metadata">The metadata associated with the context.</param>
        /// <param name="correlationId">The correlation identifier for the context.</param>
        public static void Deconstruct<TContextDefinition>(
            this IContext<TContextDefinition> context,
            out TContextDefinition definition,
            out IMetadata metadata,
            out string correlationId)
            where TContextDefinition : IContextDefinition
        {
            Guard.AgainstNull(context, nameof(context));
            definition = context.Definition;
            metadata = context.Metadata;
            correlationId = context.CorrelationId;
        }

        /// <summary>
        /// Deconstructs an <see cref="IContext{TContextDefinition}"/> into its definition, metadata, and parent context.
        /// </summary>
        /// <typeparam name="TContextDefinition">The specific type of the context definition.</typeparam>
        /// <param name="context">The context instance to deconstruct.</param>
        /// <param name="definition">The context type definition.</param>
        /// <param name="metadata">The metadata associated with the context.</param>
        /// <param name="parent">The parent context, or <c>null</c> if this is a root context.</param>
        public static void Deconstruct<TContextDefinition>(
            this IContext<TContextDefinition> context,
            out TContextDefinition definition,
            out IMetadata metadata,
            out IContext<IContextDefinition>? parent)
            where TContextDefinition : IContextDefinition
        {
            Guard.AgainstNull(context, nameof(context));
            definition = context.Definition;
            metadata = context.Metadata;
            parent = context.Parent;
        }

        /// <summary>
        /// Deconstructs an <see cref="IContext{TContextDefinition}"/> into its definition only.
        /// </summary>
        /// <typeparam name="TContextDefinition">The specific type of the context definition.</typeparam>
        /// <param name="context">The context instance to deconstruct.</param>
        /// <param name="definition">The context type definition.</param>
        public static void Deconstruct<TContextDefinition>(
            this IContext<TContextDefinition> context,
            out TContextDefinition definition)
            where TContextDefinition : IContextDefinition
        {
            Guard.AgainstNull(context, nameof(context));
            definition = context.Definition;
        }
    }
}
