// <copyright file="CachePolicy.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Zentient.Abstractions.Caching
{
    /// <summary>
    /// Defines caching policies that control how data is cached and retrieved.
    /// </summary>
    /// <remarks>
    /// Cache policies determine the behavior of caching operations, including
    /// read/write patterns, consistency guarantees, and performance characteristics.
    /// </remarks>
    public enum CachePolicy
    {
        /// <summary>
        /// No caching is performed.
        /// All operations bypass the cache and go directly to the underlying data source.
        /// </summary>
        [Description("No caching - all operations bypass cache")]
        None = 0,

        /// <summary>
        /// Read-only caching policy.
        /// Data is cached for read operations, but writes bypass the cache.
        /// Cache is populated on cache misses and invalidated externally.
        /// </summary>
        [Description("Read-only caching - writes bypass cache")]
        ReadOnly = 1,

        /// <summary>
        /// Write-only caching policy.
        /// Writes go to cache only, reads bypass the cache.
        /// Useful for buffering writes before batch processing.
        /// </summary>
        [Description("Write-only caching - reads bypass cache")]
        WriteOnly = 2,

        /// <summary>
        /// Read-write caching policy.
        /// Both reads and writes use the cache with immediate consistency.
        /// Cache is updated synchronously on writes.
        /// </summary>
        [Description("Read-write caching with immediate consistency")]
        ReadWrite = 3,

        /// <summary>
        /// Refresh-ahead caching policy.
        /// Cache is proactively refreshed before expiration to avoid cache misses.
        /// Provides better performance by avoiding expensive cache miss operations.
        /// </summary>
        [Description("Proactive cache refresh before expiration")]
        RefreshAhead = 4,

        /// <summary>
        /// Write-behind caching policy.
        /// Writes are acknowledged immediately to cache, persisted asynchronously.
        /// Provides better write performance but eventual consistency.
        /// </summary>
        [Description("Asynchronous write persistence with immediate acknowledgment")]
        WriteBehind = 5,

        /// <summary>
        /// Write-through caching policy.
        /// Writes are synchronized to both cache and underlying store before acknowledgment.
        /// Provides strong consistency but slower write performance.
        /// </summary>
        [Description("Synchronous write to cache and store")]
        WriteThrough = 6
    }

    /// <summary>
    /// Provides extension methods for working with CachePolicy values.
    /// </summary>
    public static class CachePolicyExtensions
    {
        /// <summary>
        /// Determines whether this cache policy allows read operations from cache.
        /// </summary>
        /// <param name="policy">The cache policy to check.</param>
        /// <returns>True if reads are allowed from cache; otherwise, false.</returns>
        public static bool AllowsReads(this CachePolicy policy)
        {
            return policy is CachePolicy.ReadOnly or CachePolicy.ReadWrite or 
                   CachePolicy.RefreshAhead or CachePolicy.WriteBehind or CachePolicy.WriteThrough;
        }

        /// <summary>
        /// Determines whether this cache policy allows write operations to cache.
        /// </summary>
        /// <param name="policy">The cache policy to check.</param>
        /// <returns>True if writes are allowed to cache; otherwise, false.</returns>
        public static bool AllowsWrites(this CachePolicy policy)
        {
            return policy is CachePolicy.WriteOnly or CachePolicy.ReadWrite or 
                   CachePolicy.RefreshAhead or CachePolicy.WriteBehind or CachePolicy.WriteThrough;
        }

        /// <summary>
        /// Determines whether this cache policy provides strong consistency.
        /// </summary>
        /// <param name="policy">The cache policy to check.</param>
        /// <returns>True if the policy provides strong consistency; otherwise, false.</returns>
        public static bool ProvidesStrongConsistency(this CachePolicy policy)
        {
            return policy is CachePolicy.None or CachePolicy.ReadWrite or CachePolicy.WriteThrough;
        }

        /// <summary>
        /// Determines whether this cache policy uses asynchronous operations.
        /// </summary>
        /// <param name="policy">The cache policy to check.</param>
        /// <returns>True if the policy uses async operations; otherwise, false.</returns>
        public static bool UsesAsyncOperations(this CachePolicy policy)
        {
            return policy is CachePolicy.RefreshAhead or CachePolicy.WriteBehind;
        }

        /// <summary>
        /// Gets the consistency level provided by this cache policy.
        /// </summary>
        /// <param name="policy">The cache policy.</param>
        /// <returns>The consistency level as a descriptive string.</returns>
        public static string GetConsistencyLevel(this CachePolicy policy)
        {
            return policy switch
            {
                CachePolicy.None or CachePolicy.WriteThrough => "Strong",
                CachePolicy.ReadWrite => "Strong",
                CachePolicy.RefreshAhead => "Eventually Strong",
                CachePolicy.WriteBehind => "Eventual",
                CachePolicy.ReadOnly => "Read Consistent",
                CachePolicy.WriteOnly => "Write Consistent",
                _ => "Unknown"
            };
        }

        /// <summary>
        /// Gets the performance characteristics of this cache policy.
        /// </summary>
        /// <param name="policy">The cache policy.</param>
        /// <returns>A tuple indicating read and write performance (High, Medium, Low).</returns>
        public static (string ReadPerformance, string WritePerformance) GetPerformanceCharacteristics(this CachePolicy policy)
        {
            return policy switch
            {
                CachePolicy.None => ("Low", "Low"),
                CachePolicy.ReadOnly => ("High", "Low"),
                CachePolicy.WriteOnly => ("Low", "High"),
                CachePolicy.ReadWrite => ("High", "Medium"),
                CachePolicy.RefreshAhead => ("High", "Medium"),
                CachePolicy.WriteBehind => ("High", "High"),
                CachePolicy.WriteThrough => ("High", "Low"),
                _ => ("Medium", "Medium")
            };
        }

        /// <summary>
        /// Determines whether this policy is compatible with another policy for composition.
        /// </summary>
        /// <param name="policy">The cache policy to check.</param>
        /// <param name="otherPolicy">The other policy to check compatibility with.</param>
        /// <returns>True if the policies can be composed; otherwise, false.</returns>
        public static bool IsCompatibleWith(this CachePolicy policy, CachePolicy otherPolicy)
        {
            // None is compatible with nothing
            if (policy == CachePolicy.None || otherPolicy == CachePolicy.None)
                return false;

            // Write-only and read-only are complementary
            if ((policy == CachePolicy.WriteOnly && otherPolicy == CachePolicy.ReadOnly) ||
                (policy == CachePolicy.ReadOnly && otherPolicy == CachePolicy.WriteOnly))
                return true;

            // Same policies are compatible
            return policy == otherPolicy;
        }
    }
}
