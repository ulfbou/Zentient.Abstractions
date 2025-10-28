// <copyright file="IExecutionScopeAccessor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Execution.Accessors
{
    /// <summary>
    /// Provides access to the current ambient <see cref="IExecutionScope"/>.
    /// </summary>
    public interface IExecutionScopeAccessor
    {
        /// <summary>
        /// Gets the current ambient execution scope, or <see langword="null"/> if no scope is active.
        /// </summary>
        IExecutionScope? Current { get; }
    }
}
