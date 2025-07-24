// <copyright file="IContextAccessor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zentient.Abstractions
{
    /// <summary>
    /// Provides access to and management of the ambient (thread-local or asynchronous flow-local) context.
    /// This interface allows components to retrieve or temporarily establish a context
    /// without explicit parameter passing, facilitating cross-cutting concerns for both
    /// the base operational context and specialized typed contexts.
    /// </summary>
    public interface IContextAccessor
    {
        /// <summary>
        /// Gets the current ambient <see cref="IContext"/> instance for the current execution flow.
        /// This represents the primary operational context.
        /// </summary>
        /// <returns>The current <see cref="IContext"/> instance, or <see langword="null"/> if no context is established.</returns>
        IContext? Current { get; }

        /// <summary>
        /// Gets the current ambient <see cref="IContext{TContext}"/> instance for the specified context type
        /// within the current execution flow.
        /// </summary>
        /// <typeparam name="TContext">The type of the context to retrieve, implementing <see cref="IContextType"/>.</typeparam>
        /// <returns>The current <see cref="IContext{TContext}"/> instance, or <see langword="null"/> if no context of that type is established.</returns>
        // Renamed to 'CurrentContext' to avoid conflict with the non-generic 'Current' property.
        IContext<TContext>? GetCurrentContext<TContext>()
            where TContext : IContextType;

        /// <summary>
        /// Establishes a new ambient <see cref="IContext"/> instance for the current execution flow
        /// for the duration of the returned <see cref="IDisposable"/>'s lifetime.
        /// Upon disposal, the previous context for that type is restored.
        /// </summary>
        /// <param name="context">The <see cref="IContext"/> instance to set as current.</param>
        /// <returns>An <see cref="IDisposable"/> that, when disposed, restores the previous context.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="context"/> is <see langword="null"/>.</exception>
        IDisposable UseContext(IContext context);

        /// <summary>
        /// Establishes a new ambient <see cref="IContext{TContext}"/> instance for the current execution flow
        /// for the duration of the returned <see cref="IDisposable"/>'s lifetime.
        /// Upon disposal, the previous context for that type is restored.
        /// </summary>
        /// <typeparam name="TContext">The type of the context to establish, implementing <see cref="IContextType"/>.</typeparam>
        /// <param name="context">The <see cref="IContext{TContext}"/> instance to set as current.</param>
        /// <returns>An <see cref="IDisposable"/> that, when disposed, restores the previous context.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="context"/> is <see langword="null"/>.</exception>
        IDisposable UseContext<TContext>(IContext<TContext> context)
            where TContext : IContextType;

        /// <summary>
        /// Executes an asynchronous function within a specific ambient <see cref="IContext"/> scope.
        /// The context is established before the function executes and restored afterwards.
        /// </summary>
        /// <param name="context">The <see cref="IContext"/> instance to establish for the scope.</param>
        /// <param name="func">The asynchronous function to execute within the established context.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, returning the result of <paramref name="func"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="context"/> or <paramref name="func"/> is <see langword="null"/>.</exception>
        Task<TResult> RunInContext<TResult>(IContext context, Func<Task<TResult>> func);

        /// <summary>
        /// Executes an asynchronous action within a specific ambient <see cref="IContext"/> scope.
        /// The context is established before the action executes and restored afterwards.
        /// </summary>
        /// <param name="context">The <see cref="IContext"/> instance to establish for the scope.</param>
        /// <param name="action">The asynchronous action to execute within the established context.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="context"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
        Task RunInContext(IContext context, Func<Task> action);

        /// <summary>
        /// Executes an asynchronous function within a specific ambient <see cref="IContext{TContext}"/> scope.
        /// The context is established before the function executes and restored afterwards.
        /// </summary>
        /// <typeparam name="TContext">The type of the context to establish, implementing <see cref="IContextType"/>.</typeparam>
        /// <typeparam name="TResult">The type of the result returned by the function.</typeparam>
        /// <param name="context">The <see cref="IContext{TContext}"/> instance to establish for the scope.</param>
        /// <param name="func">The asynchronous function to execute within the established context.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, returning the result of <paramref name="func"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="context"/> or <paramref name="func"/> is <see langword="null"/>.</exception>
        Task<TResult> RunInContext<TContext, TResult>(IContext<TContext> context, Func<Task<TResult>> func)
            where TContext : IContextType;

        /// <summary>
        /// Executes an asynchronous action within a specific ambient <see cref="IContext{TContext}"/> scope.
        /// The context is established before the action executes and restored afterwards.
        /// </summary>
        /// <typeparam name="TContext">The type of the context to establish, implementing <see cref="IContextType"/>.</typeparam>
        /// <param name="context">The <see cref="IContext{TContext}"/> instance to establish for the scope.</param>
        /// <param name="action">The asynchronous action to execute within the established context.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="context"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
        Task RunInContext<TContext>(IContext<TContext> context, Func<Task> action)
            where TContext : IContextType;
    }
}
