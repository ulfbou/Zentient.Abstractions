// <copyright file="IContextAccessor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Diagnostics;

namespace Zentient.Abstractions.Contexts.Accessors
{
    /// <summary>
    /// Provides access to the ambient (thread/async flow local) current operational context.
    /// </summary>
    /// <remarks>
    /// This accessor allows components to retrieve the currently active context without
    /// explicit passing, simplifying APIs in certain scenarios. Its usage should be carefully
    /// considered to avoid implicit dependencies.
    /// </remarks>
    public interface IContextAccessor
    {
        /// <summary>
        /// Gets the current ambient operational context.
        /// </summary>
        /// <value>The current <see cref="IContext{IContexTDefinition}"/>, or <see langword="null"/> if no context is active.</value>
        IContext<IContextDefinition>? CurrentContext { get; }

        /// <summary>
        /// Sets a new context as the current ambient context for the duration of the returned scope.
        /// </summary>
        /// <param name="context">The context to set as current. Can be null to clear the current context.</param>
        /// <returns>An <see cref="IDisposable"/> scope. Disposing it restores the previous context.</returns>
        IDisposable UseContext(IContext<IContextDefinition>? context);
    }
}
