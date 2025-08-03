// <copyright file="IExecutionScope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Observability;
using Zentient.Abstractions.Observability.Metrics;
using Zentient.Abstractions.Observability.Tracing;
using Zentient.Abstractions.Validation;

namespace Zentient.Abstractions.Execution
{
    /// <summary>
    /// Represents an ambient execution scope that holds context-relevant artifacts
    /// for the current operation.
    /// This scope is typically managed implicitly (e.g., using AsyncLocal) and must be disposed.
    /// </summary>
    public interface IExecutionScope : IDisposable, IHasCorrelationId, IHasMetadata
    {
        /// <summary>
        /// Gets the unique identifier for this specific execution scope instance.
        /// </summary>
        string ScopeId { get; }

        /// <summary>
        /// Gets the primary operational context associated with this execution scope.
        /// </summary>
        IContext<IContextDefinition>? CurrentContext { get; }

        /// <summary>
        /// Gets the current validation context active within this execution scope, if any.
        /// </summary>
        IValidationContext? CurrentValidationContext { get; }

        /// <summary>
        /// Gets the primary operational context associated with this execution scope.
        /// </summary>
        /// <typeparam name="TContextDefinition">The type definition of the current context.</typeparam>
        /// <returns>The current operational context instance, or <see langword="null"/> if no context of that type is active in this scope.</returns>
        [return: NotNullIfNotNull("CurrentContext")]
        IContext<TContextDefinition>? GetContext<TContextDefinition>() where TContextDefinition : IContextDefinition;

        /// <summary>
        /// Pushes a new validation context onto the scope's internal stack.
        /// </summary>
        /// <param name="context">The validation context to push.</param>
        void PushValidationContext(IValidationContext context);

        /// <summary>
        /// Removes the current validation context from the scope's internal stack.
        /// </summary>
        void PopValidationContext();

        /// <summary>
        /// Gets a logger instance that is aware of the current execution scope's context.
        /// </summary>
        /// <typeparam name="TContextDefinition">The type definition of the context for which to get the logger.</typeparam>
        /// <returns>An <see cref="ILogger{TContextDefinition}"/> instance.</returns>
        ILogger<TContextDefinition> GetLogger<TContextDefinition>() where TContextDefinition : IContextDefinition;

        /// <summary>
        /// Gets a tracer instance that is aware of the current execution scope's context.
        /// </summary>
        /// <typeparam name="TContextDefinition">The type definition of the context for which to get the tracer.</typeparam>
        /// <returns>An <see cref="ITracer{TContextDefinition}"/> instance.</returns>
        ITracer<TContextDefinition> GetTracer<TContextDefinition>() where TContextDefinition : IContextDefinition;

        /// <summary>
        /// Gets a meter instance for general application metrics,
        /// usually shared across the application.
        /// </summary>
        /// <returns>An <see cref="IMeter"/> instance.</returns>
        IMeter GetMeter();
    }
}
