// <copyright file="IExecutionScopeFactory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Execution.Accessors;

namespace Zentient.Abstractions.Execution.Factories
{
    /// <summary>
    /// Factory for creating and activating new <see cref="IExecutionScope"/> instances.
    /// </summary>
    public interface IExecutionScopeFactory
    {
        /// <summary>
        /// Creates and activates a new execution scope, optionally with an initial primary context and parent scope.
        /// The returned scope *must* be disposed to end its lifecycle and restore the previous ambient scope.
        /// </summary>
        /// <param name="initialContext">The initial primary operational context for this scope. This context's correlation ID will be used if not explicitly overridden.</param>
        /// <param name="parentScope">Optional parent scope if this is a nested scope creation. Its context and metadata can be inherited.</param>
        /// <param name="correlationId">Optional correlation ID to explicitly set for this scope. If null, derived from <paramref name="initialContext"/>.</param>
        /// <param name="initialMetadata">Optional initial metadata to attach directly to this scope.</param>
        /// <returns>A new, active <see cref="IExecutionScope"/> instance.</returns>
        /// <remarks>
        /// The new scope becomes the <see cref="IExecutionScopeAccessor.Current"/> for the duration of its lifecycle
        /// (typically managed via an <see cref="System.Threading.AsyncLocal{T}"/> mechanism in the implementation).
        /// </remarks>
        IExecutionScope BeginScope<TContextDefinition>(
            IContext<TContextDefinition>? initialContext = null,
            IExecutionScope? parentScope = null,
            string? correlationId = null,
            Zentient.Abstractions.Metadata.IMetadata? initialMetadata = null)
            where TContextDefinition : IContextDefinition;

        /// <summary>
        /// Begins a new execution scope with the specified name.
        /// This is a convenience method that allows for naming the scope, which can be useful for logging or tracing.
        /// The name is typically used to identify the scope in logs or traces, but does not affect the scope's functionality.
        /// </summary>
        /// <param name="name">The name of the scope to begin.</param>
        /// <param name="initialContext">The initial primary operational context for this scope. This context's correlation ID will be used if not explicitly overridden.</param>
        /// <param name="parentScope">Optional parent scope if this is a nested scope creation. Its context and metadata can be inherited.</param>
        /// <param name="correlationId">Optional correlation ID to explicitly set for this scope. If null, derived from <paramref name="initialContext"/>.</param>
        /// <param name="initialMetadata">Optional initial metadata to attach directly to this scope.</param>
        /// <returns>A new, active <see cref="IExecutionScope"/> instance with the specified name.</returns>
        /// <remarks>
        /// The new scope becomes the <see cref="IExecutionScopeAccessor.Current"/> for the duration of its lifecycle
        /// (typically managed via an <see cref="System.Threading.AsyncLocal{T}"/> mechanism in the implementation).
        /// The name is primarily for identification purposes in logs or traces and does not affect the scope's functionality.
        /// </remarks>
        public IExecutionScope BeginScopeWithName<TContextDefinition>(
            string name,
            IContext<TContextDefinition>? initialContext = null,
            IExecutionScope? parentScope = null,
            string? correlationId = null,
            Zentient.Abstractions.Metadata.IMetadata? initialMetadata = null)
            where TContextDefinition : IContextDefinition;
    }
}
