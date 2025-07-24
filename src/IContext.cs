// <copyright file="IContext.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents a flexible, hierarchical, and observable execution context for operations.
    /// Supports correlation, scope management, and immutable updates.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Gets the unique identifier for this specific context instance. Useful for debugging and tracing.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the logical name or type of the current context (e.g., "HttpRequest", "RpcCall", "BackgroundTask", "DomainEvent").
        /// This provides semantic categorization.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets an optional reference to the parent context, establishing a hierarchical relationship.
        /// </summary>
        IContext? Parent { get; }

        /// <summary>
        /// Gets the correlation ID that links related operations across different contexts and services.
        /// If not explicitly set, it can be inherited from the parent or generated.
        /// </summary>
        string CorrelationId { get; }

        /// <summary>
        /// Gets the structured metadata relevant to this context. Never null.
        /// </summary>
        IMetadata Metadata { get; }

        /// <summary>
        /// Creates a new child context that inherits from the current context.
        /// The child context will have a new Id and its Parent property set to this context.
        /// It will inherit CorrelationId if not explicitly provided.
        /// </summary>
        /// <param name="type">The type of the new child context.</param>
        /// <param name="initialMetadata">Optional initial metadata for the child context.</param>
        /// <param name="correlationId">Optional correlation ID for the child context. If null, inherits from parent.</param>
        /// <returns>A new <see cref="IContext"/> instance representing the child context.</returns>
        IContext CreateChild(string type, IMetadata? initialMetadata = null, string? correlationId = null);

        /// <summary>
        /// Returns a new context instance with updated metadata.
        /// </summary>
        IContext WithMetadata(Func<IMetadata, IMetadata> metadataUpdater);

        /// <summary>
        /// Returns a new context instance with a new type.
        /// </summary>
        IContext WithType(string newType);

        /// <summary>
        /// Returns a new context instance by merging with another <see cref="IContext"/> instance.
        /// The merging strategy (e.g., how Type and Metadata are combined) is implementation-dependent.
        /// </summary>
        IContext Merge(IContext other);
    }
}
