// <copyright file="ICache{TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Caching.Definitions;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Caching
{
    /// <summary>Represents a generic cache client that is vendor-agnostic.</summary>
    /// <typeparam name="TValue">The type of the value to be cached.</typeparam>
    public interface ICache<TValue>
    {
        /// <summary>Asynchronously retrieves a cache item.</summary>
        /// <param name="key">The key of the cache item to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The result contains the cache item if found, otherwise null.
        /// </returns>
        Task<IResult<ICacheItem<TValue>?>> Get(
            ICacheKey<ICacheKeyDefinition> key,
            CancellationToken cancellationToken);

        /// <summary>Asynchronously sets a cache item.</summary>
        /// <param name="key">The key of the cache item to set.</param>
        /// <param name="value">The value to be stored.</param>
        /// <param name="expiration">The absolute expiration time for the cache item.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous set operation.</returns>
        Task<IResult> Set(
            ICacheKey<ICacheKeyDefinition> key,
            TValue value,
            DateTimeOffset? expiration = default,
            CancellationToken cancellationToken = default);

        /// <summary>Asynchronously removes a cache item.</summary>
        /// <param name="key">The key of the cache item to remove.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous removal operation.</returns>
        Task<IResult> Remove(
            ICacheKey<ICacheKeyDefinition> key,
            CancellationToken cancellationToken);
    }
}
