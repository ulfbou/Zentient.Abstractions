// <copyright file="ICacheItem{out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Caching
{
    /// <summary>Represents a single item stored in the cache.</summary>
    /// <typeparam name="TValue">The type of the value stored in the cache item.</typeparam>
    public interface ICacheItem<out TValue>
    {
        /// <summary>Gets the value from the cache item.</summary>
        TValue Value { get; }

        /// <summary>Gets the absolute expiration time of the cache item.</summary>
        DateTimeOffset? AbsoluteExpiration { get; }
    }
}
