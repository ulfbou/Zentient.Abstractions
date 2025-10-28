// <copyright file="OperationMode.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.ComponentModel;
using Zentient.Abstractions.Policies;

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Defines operation modes that control execution behavior and characteristics.
    /// </summary>
    /// <remarks>
    /// Operation modes provide a standardized way to specify how operations should
    /// be executed, including performance characteristics, reliability guarantees,
    /// and resource usage patterns.
    /// </remarks>
    public enum OperationMode
    {
        /// <summary>
        /// Standard operation mode.
        /// Balanced approach with normal performance and reliability guarantees.
        /// Default mode for most operations.
        /// </summary>
        [Description("Standard balanced operation mode")]
        Standard = 0,

        /// <summary>
        /// High-performance operation mode.
        /// Optimized for speed and throughput, may reduce reliability guarantees.
        /// Suitable for non-critical operations requiring fast execution.
        /// </summary>
        [Description("High-performance mode with reduced reliability")]
        HighPerformance = 1,

        /// <summary>
        /// High-reliability operation mode.
        /// Emphasizes consistency and durability, may impact performance.
        /// Suitable for critical operations requiring strong guarantees.
        /// </summary>
        [Description("High-reliability mode with performance trade-offs")]
        HighReliability = 2,

        /// <summary>
        /// Low-latency operation mode.
        /// Optimized for minimal response time, may use more resources.
        /// Suitable for real-time and interactive operations.
        /// </summary>
        [Description("Low-latency mode optimized for response time")]
        LowLatency = 3,

        /// <summary>
        /// Batch operation mode.
        /// Optimized for throughput over individual operation latency.
        /// Suitable for bulk processing and background operations.
        /// </summary>
        [Description("Batch mode optimized for throughput")]
        Batch = 4,

        /// <summary>
        /// Background operation mode.
        /// Low-priority execution that yields to other operations.
        /// Suitable for maintenance, cleanup, and non-urgent tasks.
        /// </summary>
        [Description("Background mode with low priority")]
        Background = 5,

        /// <summary>
        /// Debug operation mode.
        /// Enhanced logging, validation, and diagnostic information.
        /// Suitable for development and troubleshooting scenarios.
        /// </summary>
        [Description("Debug mode with enhanced diagnostics")]
        Debug = 6,

        /// <summary>
        /// Testing operation mode.
        /// Modified behavior for testing scenarios and validation.
        /// May include additional assertions and test-specific behavior.
        /// </summary>
        [Description("Testing mode with validation enhancements")]
        Testing = 7
    }

    /// <summary>
    /// Provides extension methods for working with OperationMode values.
    /// </summary>
    public static class OperationModeExtensions
    {
        /// <summary>
        /// Gets the recommended priority level for this operation mode.
        /// </summary>
        /// <param name="mode">The operation mode.</param>
        /// <returns>The recommended priority level.</returns>
        public static Priority GetRecommendedPriority(this OperationMode mode)
        {
            return mode switch
            {
                OperationMode.LowLatency => Priority.Highest,
                OperationMode.HighReliability => Priority.High,
                OperationMode.HighPerformance => Priority.High,
                OperationMode.Standard => Priority.Normal,
                OperationMode.Batch => Priority.Low,
                OperationMode.Background => Priority.Lowest,
                OperationMode.Debug => Priority.Normal,
                OperationMode.Testing => Priority.Normal,
                _ => Priority.Normal
            };
        }

        /// <summary>
        /// Gets the recommended consistency level for this operation mode.
        /// </summary>
        /// <param name="mode">The operation mode.</param>
        /// <returns>The recommended consistency level.</returns>
        public static ConsistencyLevel GetRecommendedConsistencyLevel(this OperationMode mode)
        {
            return mode switch
            {
                OperationMode.HighReliability => ConsistencyLevel.Strong,
                OperationMode.Standard => ConsistencyLevel.Session,
                OperationMode.HighPerformance => ConsistencyLevel.Eventual,
                OperationMode.LowLatency => ConsistencyLevel.Eventual,
                OperationMode.Batch => ConsistencyLevel.BoundedStaleness,
                OperationMode.Background => ConsistencyLevel.Eventual,
                OperationMode.Debug => ConsistencyLevel.Strong,
                OperationMode.Testing => ConsistencyLevel.Strong,
                _ => ConsistencyLevel.Session
            };
        }

        /// <summary>
        /// Gets the recommended cache policy for this operation mode.
        /// </summary>
        /// <param name="mode">The operation mode.</param>
        /// <returns>The recommended cache policy.</returns>
        public static Caching.CachePolicy GetRecommendedCachePolicy(this OperationMode mode)
        {
            return mode switch
            {
                OperationMode.HighPerformance => Caching.CachePolicy.ReadWrite,
                OperationMode.LowLatency => Caching.CachePolicy.RefreshAhead,
                OperationMode.HighReliability => Caching.CachePolicy.WriteThrough,
                OperationMode.Standard => Caching.CachePolicy.ReadWrite,
                OperationMode.Batch => Caching.CachePolicy.WriteBehind,
                OperationMode.Background => Caching.CachePolicy.ReadOnly,
                OperationMode.Debug => Caching.CachePolicy.None,
                OperationMode.Testing => Caching.CachePolicy.None,
                _ => Caching.CachePolicy.ReadWrite
            };
        }

        /// <summary>
        /// Gets the recommended retry policy for this operation mode.
        /// </summary>
        /// <param name="mode">The operation mode.</param>
        /// <returns>The recommended retry policy.</returns>
        public static RetryPolicy GetRecommendedRetryPolicy(this OperationMode mode)
        {
            return mode switch
            {
                OperationMode.HighReliability => RetryPolicy.ExponentialBackoff,
                OperationMode.Standard => RetryPolicy.LinearBackoff,
                OperationMode.HighPerformance => RetryPolicy.FixedInterval,
                OperationMode.LowLatency => RetryPolicy.None,
                OperationMode.Batch => RetryPolicy.ExponentialBackoff,
                OperationMode.Background => RetryPolicy.RandomJitter,
                OperationMode.Debug => RetryPolicy.FixedInterval,
                OperationMode.Testing => RetryPolicy.FixedInterval,
                _ => RetryPolicy.LinearBackoff
            };
        }

        /// <summary>
        /// Gets the recommended timeout for operations in this mode.
        /// </summary>
        /// <param name="mode">The operation mode.</param>
        /// <returns>The recommended timeout duration.</returns>
        public static TimeSpan GetRecommendedTimeout(this OperationMode mode)
        {
            return mode switch
            {
                OperationMode.LowLatency => TimeSpan.FromSeconds(1),
                OperationMode.HighPerformance => TimeSpan.FromSeconds(5),
                OperationMode.Standard => TimeSpan.FromSeconds(30),
                OperationMode.HighReliability => TimeSpan.FromMinutes(2),
                OperationMode.Batch => TimeSpan.FromMinutes(30),
                OperationMode.Background => TimeSpan.FromHours(1),
                OperationMode.Debug => TimeSpan.FromMinutes(5),
                OperationMode.Testing => TimeSpan.FromMinutes(1),
                _ => TimeSpan.FromSeconds(30)
            };
        }

        /// <summary>
        /// Determines whether this operation mode prioritizes performance over reliability.
        /// </summary>
        /// <param name="mode">The operation mode to check.</param>
        /// <returns>True if performance is prioritized; otherwise, false.</returns>
        public static bool PrioritizesPerformance(this OperationMode mode)
        {
            return mode is OperationMode.HighPerformance or OperationMode.LowLatency or OperationMode.Batch;
        }

        /// <summary>
        /// Determines whether this operation mode prioritizes reliability over performance.
        /// </summary>
        /// <param name="mode">The operation mode to check.</param>
        /// <returns>True if reliability is prioritized; otherwise, false.</returns>
        public static bool PrioritizesReliability(this OperationMode mode)
        {
            return mode is OperationMode.HighReliability or OperationMode.Debug or OperationMode.Testing;
        }

        /// <summary>
        /// Determines whether this operation mode is suitable for production use.
        /// </summary>
        /// <param name="mode">The operation mode to check.</param>
        /// <returns>True if suitable for production; otherwise, false.</returns>
        public static bool IsProductionSuitable(this OperationMode mode)
        {
            return mode is not (OperationMode.Debug or OperationMode.Testing);
        }
    }
}
