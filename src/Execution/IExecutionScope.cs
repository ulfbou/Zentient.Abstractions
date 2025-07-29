// <copyright file="IExecutionScope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Observability;
using Zentient.Abstractions.Observability.Metrics;
using Zentient.Abstractions.Observability.Providers;
using Zentient.Abstractions.Observability.Tracing;
using Zentient.Abstractions.Validation;

namespace Zentient.Abstractions.Execution
{
    /// <summary>
    /// Represents an ambient execution scope that holds context-relevant artifacts for the current operation.
    /// This scope is typically managed implicitly (e.g., using AsyncLocal) and must be disposed.
    /// </summary>
    /// <remarks>
    /// It provides a unified surface to access the current operational context, correlation ID,
    /// dynamic scope-specific metadata, and allows for managing nested validation contexts
    /// and convenient access to observability primitives.
    /// </remarks>
    public interface IExecutionScope : IDisposable, IHasCorrelationId, IHasMetadata
    {
        /// <summary>
        /// Gets the unique identifier for this specific execution scope instance.
        /// Useful for correlating sub-operations or for debugging the flow within this scope.
        /// </summary>
        string ScopeId { get; }

        /// <summary>
        /// Gets the primary operational context associated with this execution scope.
        /// This is the overarching context (e.g., HTTP Request, Background Job context).
        /// </summary>
        /// <typeparam name="TContextType">The type definition of the current context.</typeparam>
        /// <returns>The current operational context instance, or <see langword="null"/> if no context of that type is active in this scope.</returns>
        /// <remarks>
        /// This method allows retrieving the context in a type-safe manner for the consumer's needs.
        /// Implementations should return <see langword="null"/> or throw if the requested type
        /// does not match the active context. A non-generic <see cref="IContext{TContextType}"/> property
        /// could also be added if a generic accessor isn't always convenient.
        /// </remarks>
        IContext<TContextType>? GetContext<TContextType>() where TContextType : IContextType;

        /// <summary>
        /// Gets the primary operational context associated with this execution scope.
        /// This is the overarching context (e.g., HTTP Request, Background Job context).
        /// </summary>
        /// <value>The current <see langword="IContext{IContextType}" />.</value>
        IContext<IContextType>? CurrentContext { get; }

        /// <summary>
        /// Gets the current validation context active within this execution scope, if any.
        /// This allows for hierarchical management of validation options within a single operation.
        /// </summary>
        IValidationContext? CurrentValidationContext { get; }

        /// <summary>
        /// Pushes a new validation context onto the scope's internal stack.
        /// This new context becomes the <see cref="CurrentValidationContext"/>.
        /// </summary>
        /// <param name="context">The validation context to push.</param>
        /// <exception cref="ArgumentNullException">Thrown if the provided context is null.</exception>
        void PushValidationContext(IValidationContext context);

        /// <summary>
        /// Removes the current validation context from the scope's internal stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if there is no validation context to pop.</exception>
        void PopValidationContext();

        /// <summary>
        /// Gets a logger instance that is aware of the current execution scope's context.
        /// </summary>
        /// <typeparam name="TContextType">The type definition of the context for which to get the logger.</typeparam>
        /// <returns>An <see cref="ILogger{TContextType}"/> instance.</returns>
        /// <remarks>
        /// This method routes to the underlying <see cref="IObservabilityProvider"/> but ensures the logger
        /// is associated with the active scope.
        /// </remarks>
        ILogger<TContextType> GetLogger<TContextType>() 
            where TContextType : IContextType;

        /// <summary>
        /// Gets a tracer instance that is aware of the current execution scope's context.
        /// </summary>
        /// <typeparam name="TContextType">The type definition of the context for which to get the tracer.</typeparam>
        /// <returns>An <see cref="ITracer{TContextType}"/> instance.</returns>
        /// <remarks>
        /// This method routes to the underlying <see cref="IObservabilityProvider"/> but ensures the tracer
        /// is associated with the active scope.
        /// </remarks>
        ITracer<TContextType> GetTracer<TContextType>() where TContextType : IContextType;

        /// <summary>
        /// Gets a meter instance for general application metrics, usually shared across the application.
        /// </summary>
        /// <returns>An <see cref="IMeter"/> instance.</returns>
        /// <remarks>
        /// This method routes to the underlying <see cref="IObservabilityProvider"/>.
        /// </remarks>
        IMeter GetMeter();
    }
}
