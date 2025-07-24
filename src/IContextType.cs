// <copyright file="IContextType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Marker interface for specific context domains or types.
    /// Provides an identifier primarily for diagnostics and satisfying static analysis rules.
    /// This allows <see langword="IContext{TContext}" /> to enforce type safety on the contextual data it carries.
    /// </summary>
    public interface IContextType
    {
        /// <summary>
        /// Gets a unique identifier for this context type.
        /// E.g., "HttpRequest", "RpcCall", "BackgroundTask", "DomainEvent".
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets a human-readable name for this context type.
        /// This name is used for documentation, diagnostics, and user interfaces.
        /// It should be descriptive enough to convey the purpose of the context type.
        /// </summary>
        /// <value>The human-readable name for this context type.</value>
        string Name { get; }
    }
}
