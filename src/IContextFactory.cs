// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Factory for creating new instances of the base <see cref="IContext"/> (operational context).
    /// This provides a centralized and consistent way to construct root context objects for new execution flows.
    /// </summary>
    public interface IContextFactory
    {
        /// <summary>
        /// Creates a new root <see cref="IContext"/> instance with the specified type, optional initial metadata, and optional correlation ID.
        /// This instance will have no parent context.
        /// </summary>
        /// <param name="type">The logical type or name of the root context (e.g., "HttpRequest", "BackgroundTask", "CommandExecution").</param>
        /// <param name="initialMetadata">Optional initial metadata to associate with the context's <see cref="IContext.Metadata"/> property.</param>
        /// <param name="correlationId">Optional correlation ID for distributed tracing. If <see langword="null"/>, a new one may be generated.</param>
        /// <returns>A new root <see cref="IContext"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="type"/> is <see langword="null"/> or empty.</exception>
        IContext CreateRoot(string type, IMetadata? initialMetadata = null, string? correlationId = null);

        // Note: Creation of IContext<TContext> instances will be handled either directly by specific
        // factories or via extension methods on IContextFactory or IContext<TContext> (e.g., CreateTypedChild).
        // The SetCurrent method has been moved to IContextAccessor, as it pertains to ambient context management, not creation.
    }

    /// <summary>
    /// Factory for creating new instances of specific type-safe contexts (<see cref="IContext{TContext}"/>).
    /// This allows for specialized creation logic for different <see cref="IContextType"/>s.
    /// </summary>
    /// <typeparam name="TContext">The specific type of context to create, which must implement <see cref="IContextType"/>.</typeparam>
    public interface IContextFactory<TContext>
        where TContext : IContextType
    {
        /// <summary>
        /// Gets an empty, default <see cref="IContext{TContext}"/> instance representing the absence of specific contextual data.
        /// This typically requires the <typeparamref name="TContext"/> type to have a default constructor.
        /// </summary>
        IContext<TContext> Empty { get; }

        /// <summary>
        /// Creates a new <see cref="IContext{TContext}"/> instance with the specified strongly-typed value.
        /// This new typed context will inherit operational properties (Id, Type, Parent, CorrelationId, Metadata)
        /// from the ambient <see cref="IContext"/> if one is present, or create a new root operational context.
        /// </summary>
        /// <param name="value">The strongly-typed context value.</param>
        /// <param name="metadata">Optional <see cref="IMetadata"/> to associate with this context instance (merging with inherited metadata).</param>
        /// <param name="parentOperationalContext">Optional explicit parent <see cref="IContext"/> to derive operational properties from. If null, ambient context is used.</param>
        /// <returns>A new <see cref="IContext{TContext}"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <see langword="null"/>.</exception>
        IContext<TContext> Create(TContext value, IMetadata? metadata = null, IContext? parentOperationalContext = null);
    }
}
