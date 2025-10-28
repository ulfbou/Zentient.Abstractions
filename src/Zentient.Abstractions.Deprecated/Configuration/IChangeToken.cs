// <copyright file="IChangeToken.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;

namespace Zentient.Abstractions.Configuration
{
    /// <summary>Represents a registration to a change notification source.</summary>
    public interface IChangeToken
    {
        /// <summary>
        /// Indicates if this token will proactively raise callbacks.
        /// If <see langword="false" />, the token will never fire.
        /// </summary>
        /// If <see langword="false" />, the token will never fire.
        bool ActiveChangeCallbacks { get; }

        /// <summary>Gets a value that indicates if a change has occurred.</summary>
        /// <value><see langword="true" /> if a change has occurred; otherwise, <see langword="false" />.</value>
        bool HasChanged { get; }

        /// <summary>
        /// Registers for a callback that will be invoked when the entry has changed.
        /// <see cref="HasChanged"/> MUST be checked before registering the callback.
        /// Callbacks should be called asynchronously.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <param name="state">State to be passed into the callback.</param>
        /// <returns>An <see cref="IDisposable"/> that is used to unregister the callback.</returns>
        IDisposable RegisterChangeCallback(Action<object?> callback, object? state);
    }
}
