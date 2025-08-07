// <copyright file="ConsistencyLevel.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Defines consistency levels for data operations and distributed systems.
    /// </summary>
    /// <remarks>
    /// Consistency levels provide a way to specify the trade-offs between
    /// consistency guarantees, performance, and availability in distributed operations.
    /// </remarks>
    public enum ConsistencyLevel
    {
        /// <summary>
        /// Eventual consistency.
        /// Data will become consistent over time, but immediate consistency is not guaranteed.
        /// Highest availability and performance, lowest consistency guarantees.
        /// </summary>
        [Description("Data becomes consistent over time")]
        Eventual = 0,

        /// <summary>
        /// Session consistency.
        /// Consistency is guaranteed within a single session or client connection.
        /// Moderate consistency with good performance for single-client scenarios.
        /// </summary>
        [Description("Consistency within a single session")]
        Session = 1,

        /// <summary>
        /// Bounded staleness consistency.
        /// Data staleness is bounded by time or version lag.
        /// Provides predictable staleness bounds while maintaining availability.
        /// </summary>
        [Description("Bounded staleness by time or version")]
        BoundedStaleness = 2,

        /// <summary>
        /// Monotonic read consistency.
        /// Guarantees that reads will never see older versions of data than previously read.
        /// Prevents reading stale data but allows eventual consistency.
        /// </summary>
        [Description("Reads never return older versions")]
        MonotonicRead = 3,

        /// <summary>
        /// Read-your-writes consistency.
        /// Guarantees that a client will always read its own writes.
        /// Ensures that writes are immediately visible to the writer.
        /// </summary>
        [Description("Clients always read their own writes")]
        ReadYourWrites = 4,

        /// <summary>
        /// Causal consistency.
        /// Maintains causal relationships between operations.
        /// Causally related operations are seen in the same order by all clients.
        /// </summary>
        [Description("Maintains causal relationships between operations")]
        Causal = 5,

        /// <summary>
        /// Strong consistency.
        /// All operations appear to occur atomically and in a global order.
        /// Highest consistency guarantees but may impact availability and performance.
        /// </summary>
        [Description("All operations appear atomic and ordered")]
        Strong = 6,

        /// <summary>
        /// Linearizable consistency.
        /// Strongest consistency level - operations appear to execute atomically
        /// and in real-time order. Equivalent to sequential consistency with
        /// real-time constraints.
        /// </summary>
        [Description("Atomic operations in real-time order")]
        Linearizable = 7
    }

    /// <summary>
    /// Provides extension methods for working with ConsistencyLevel values.
    /// </summary>
    public static class ConsistencyLevelExtensions
    {
        /// <summary>
        /// Gets the strength ranking of the consistency level.
        /// </summary>
        /// <param name="level">The consistency level.</param>
        /// <returns>The strength ranking (higher numbers indicate stronger consistency).</returns>
        public static int GetStrength(this ConsistencyLevel level)
        {
            return (int)level;
        }

        /// <summary>
        /// Determines whether this consistency level is stronger than another.
        /// </summary>
        /// <param name="level">The consistency level to check.</param>
        /// <param name="otherLevel">The level to compare against.</param>
        /// <returns>True if this level is stronger; otherwise, false.</returns>
        public static bool IsStrongerThan(this ConsistencyLevel level, ConsistencyLevel otherLevel)
        {
            return level.GetStrength() > otherLevel.GetStrength();
        }

        /// <summary>
        /// Determines whether this consistency level provides strong guarantees.
        /// </summary>
        /// <param name="level">The consistency level to check.</param>
        /// <returns>True if the level provides strong consistency; otherwise, false.</returns>
        public static bool IsStrong(this ConsistencyLevel level)
        {
            return level is ConsistencyLevel.Strong or ConsistencyLevel.Linearizable;
        }

        /// <summary>
        /// Determines whether this consistency level provides weak guarantees.
        /// </summary>
        /// <param name="level">The consistency level to check.</param>
        /// <returns>True if the level provides weak consistency; otherwise, false.</returns>
        public static bool IsWeak(this ConsistencyLevel level)
        {
            return level is ConsistencyLevel.Eventual or ConsistencyLevel.Session;
        }

        /// <summary>
        /// Gets the expected performance impact of this consistency level.
        /// </summary>
        /// <param name="level">The consistency level.</param>
        /// <returns>A tuple indicating read and write performance impact (Low, Medium, High).</returns>
        public static (string ReadImpact, string WriteImpact) GetPerformanceImpact(this ConsistencyLevel level)
        {
            return level switch
            {
                ConsistencyLevel.Eventual => ("Low", "Low"),
                ConsistencyLevel.Session => ("Low", "Low"),
                ConsistencyLevel.BoundedStaleness => ("Low", "Medium"),
                ConsistencyLevel.MonotonicRead => ("Medium", "Low"),
                ConsistencyLevel.ReadYourWrites => ("Medium", "Medium"),
                ConsistencyLevel.Causal => ("Medium", "Medium"),
                ConsistencyLevel.Strong => ("High", "High"),
                ConsistencyLevel.Linearizable => ("High", "High"),
                _ => ("Medium", "Medium")
            };
        }

        /// <summary>
        /// Gets the availability characteristics of this consistency level.
        /// </summary>
        /// <param name="level">The consistency level.</param>
        /// <returns>The availability level (High, Medium, Low).</returns>
        public static string GetAvailabilityLevel(this ConsistencyLevel level)
        {
            return level switch
            {
                ConsistencyLevel.Eventual or ConsistencyLevel.Session => "High",
                ConsistencyLevel.BoundedStaleness or ConsistencyLevel.MonotonicRead or 
                ConsistencyLevel.ReadYourWrites or ConsistencyLevel.Causal => "Medium",
                ConsistencyLevel.Strong or ConsistencyLevel.Linearizable => "Low",
                _ => "Medium"
            };
        }

        /// <summary>
        /// Determines the appropriate timeout for operations at this consistency level.
        /// </summary>
        /// <param name="level">The consistency level.</param>
        /// <returns>The recommended timeout for operations.</returns>
        public static TimeSpan GetRecommendedTimeout(this ConsistencyLevel level)
        {
            return level switch
            {
                ConsistencyLevel.Eventual => TimeSpan.FromSeconds(1),
                ConsistencyLevel.Session => TimeSpan.FromSeconds(2),
                ConsistencyLevel.BoundedStaleness => TimeSpan.FromSeconds(5),
                ConsistencyLevel.MonotonicRead => TimeSpan.FromSeconds(5),
                ConsistencyLevel.ReadYourWrites => TimeSpan.FromSeconds(10),
                ConsistencyLevel.Causal => TimeSpan.FromSeconds(15),
                ConsistencyLevel.Strong => TimeSpan.FromSeconds(30),
                ConsistencyLevel.Linearizable => TimeSpan.FromMinutes(1),
                _ => TimeSpan.FromSeconds(10)
            };
        }

        /// <summary>
        /// Combines two consistency levels, returning the stronger requirement.
        /// </summary>
        /// <param name="level1">The first consistency level.</param>
        /// <param name="level2">The second consistency level.</param>
        /// <returns>The stronger of the two consistency levels.</returns>
        public static ConsistencyLevel Max(this ConsistencyLevel level1, ConsistencyLevel level2)
        {
            return level1.IsStrongerThan(level2) ? level1 : level2;
        }
    }
}
