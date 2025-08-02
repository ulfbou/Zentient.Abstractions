// <copyright file="ICacheKey.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Caching
{
    /// <summary>Represents a cache key with a specific type definition.</summary>
    /// <typeparam name="TKeyType">The specific type definition of the cache key.</typeparam>
    public interface ICacheKey<out TKeyType> : IHasMetadata
        where TKeyType : ICacheKeyType
    {
        /// <summary>Gets the type definition for the cache key.</summary>
        TKeyType Definition { get; }
    }
}
