// <copyright file="ICacheable.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Caching
{
    /// <summary>
    /// Represents an object that can be cached according to a specific policy.
    /// </summary>
    /// <remarks>
    /// This interface provides a standard way to specify caching behavior
    /// for objects, operations, and data throughout the framework.
    /// </remarks>
    public interface ICacheable
    {
        /// <summary>
        /// Gets the cache policy that governs how this object should be cached.
        /// </summary>
        /// <value>The caching policy to apply.</value>
        CachePolicy CachePolicy { get; }

        /// <summary>
        /// Gets the cache expiration time for this object.
        /// </summary>
        /// <value>The time when the cached value should expire, or null for no expiration.</value>
        DateTimeOffset? ExpiresAt { get; }

        /// <summary>
        /// Gets the cache key used to identify this object in the cache.
        /// </summary>
        /// <value>The unique cache key.</value>
        string CacheKey { get; }
    }

    /// <summary>
    /// Represents a cacheable object with a specific value type.
    /// </summary>
    /// <typeparam name="TValue">The type of the cacheable value.</typeparam>
    public interface ICacheable<out TValue> : ICacheable
    {
        /// <summary>
        /// Gets the value that can be cached.
        /// </summary>
        /// <value>The cacheable value.</value>
        TValue Value { get; }
    }
}
