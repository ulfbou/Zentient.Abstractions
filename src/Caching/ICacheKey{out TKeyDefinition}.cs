// <copyright file="ICacheKey{out TKeyDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Caching.Definitions;
using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Caching
{
    /// <summary>Represents a cache key with a specific type definition.</summary>
    /// <typeparam name="TKeyDefinition">The specific type definition of the cache key.</typeparam>
    public interface ICacheKey<out TKeyDefinition> : IHasMetadata
        where TKeyDefinition : ICacheKeyDefinition
    {
        /// <summary>Gets the type definition for the cache key.</summary>
        TKeyDefinition Definition { get; }
    }
}
