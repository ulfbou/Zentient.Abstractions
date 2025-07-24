// <copyright file="IContext.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents a structured, immutable, type-safe contextual data container.
    /// This abstraction wraps a strongly-typed context value (<typeparamref name="TContext"/>)
    /// and allows for the inclusion of unstructured metadata via <see cref="IMetadata"/>.
    /// </summary>
    /// <typeparam name="TContext">
    /// The specific type of the domain-level context, which must implement <see cref="IContextType"/>.
    /// Examples: CorrelationContext, TenantContext, UserSessionContext.
    /// </typeparam>
    public interface IContext<out TContext> : IContext
        where TContext : IContextType
    {
        /// <summary>
        /// Gets the strongly-typed, domain-specific context value.
        /// </summary>
        TContext TypedValue { get; }

        // Note: The 'Metadata' property is inherited directly from IContext.
        // All fluent methods for manipulating IContext (e.g., CreateChild, WithMetadata, WithType, Merge)
        // are also inherited and will operate on the operational properties, returning IContext<TContext>
        // if the operation preserves the TContext type, or IContext if it becomes more generic.
        // Additional fluent methods for manipulating TypedValue (e.g., WithTypedValue)
        // will be provided as extension methods in Zentient.Core.Extensions.ContextExtensions
        // to maintain immutability and create new IContext<TNewContext> instances.
    }
}
