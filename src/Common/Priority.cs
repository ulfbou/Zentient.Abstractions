// <copyright file="Priority.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Defines priority levels for operations, requests, and resource allocation.
    /// </summary>
    /// <remarks>
    /// This enum provides a standardized way to prioritize operations across the framework,
    /// enabling consistent scheduling, resource allocation, and processing order decisions.
    /// </remarks>
    public enum Priority
    {
        /// <summary>
        /// Lowest priority level.
        /// Used for background operations and non-critical tasks.
        /// </summary>
        [Description("Lowest priority for background operations")]
        Lowest = 0,

        /// <summary>
        /// Low priority level.
        /// Used for operations that can be deferred or processed when resources are available.
        /// </summary>
        [Description("Low priority for deferrable operations")]
        Low = 1,

        /// <summary>
        /// Normal priority level.
        /// Default priority for standard operations.
        /// </summary>
        [Description("Normal priority for standard operations")]
        Normal = 2,

        /// <summary>
        /// High priority level.
        /// Used for important operations that should be processed quickly.
        /// </summary>
        [Description("High priority for important operations")]
        High = 3,

        /// <summary>
        /// Highest priority level.
        /// Used for urgent operations that require immediate attention.
        /// </summary>
        [Description("Highest priority for urgent operations")]
        Highest = 4,

        /// <summary>
        /// Critical priority level.
        /// Used for emergency operations that must be processed immediately.
        /// </summary>
        [Description("Critical priority for emergency operations")]
        Critical = 5
    }

    /// <summary>
    /// Provides extension methods for working with Priority values.
    /// </summary>
    public static class PriorityExtensions
    {
        /// <summary>
        /// Determines whether the priority level is considered urgent.
        /// </summary>
        /// <param name="priority">The priority level to check.</param>
        /// <returns>True if the priority is High, Highest, or Critical; otherwise, false.</returns>
        public static bool IsUrgent(this Priority priority)
        {
            return priority >= Priority.High;
        }

        /// <summary>
        /// Determines whether the priority level can be deferred.
        /// </summary>
        /// <param name="priority">The priority level to check.</param>
        /// <returns>True if the priority is Lowest or Low; otherwise, false.</returns>
        public static bool CanBeDeferred(this Priority priority)
        {
            return priority <= Priority.Low;
        }

        /// <summary>
        /// Gets the relative weight for priority-based scheduling.
        /// </summary>
        /// <param name="priority">The priority level.</param>
        /// <returns>A numeric weight value for scheduling algorithms.</returns>
        public static int GetWeight(this Priority priority)
        {
            return priority switch
            {
                Priority.Lowest => 1,
                Priority.Low => 2,
                Priority.Normal => 4,
                Priority.High => 8,
                Priority.Highest => 16,
                Priority.Critical => 32,
                _ => 4
            };
        }

        /// <summary>
        /// Gets the maximum allowed processing time for this priority level.
        /// </summary>
        /// <param name="priority">The priority level.</param>
        /// <returns>The maximum processing time span.</returns>
        public static TimeSpan GetMaxProcessingTime(this Priority priority)
        {
            return priority switch
            {
                Priority.Critical => TimeSpan.FromSeconds(1),
                Priority.Highest => TimeSpan.FromSeconds(5),
                Priority.High => TimeSpan.FromSeconds(30),
                Priority.Normal => TimeSpan.FromMinutes(2),
                Priority.Low => TimeSpan.FromMinutes(10),
                Priority.Lowest => TimeSpan.FromHours(1),
                _ => TimeSpan.FromMinutes(2)
            };
        }

        /// <summary>
        /// Combines two priority levels, returning the higher priority.
        /// </summary>
        /// <param name="priority1">The first priority level.</param>
        /// <param name="priority2">The second priority level.</param>
        /// <returns>The higher of the two priority levels.</returns>
        public static Priority Max(this Priority priority1, Priority priority2)
        {
            return priority1 > priority2 ? priority1 : priority2;
        }

        /// <summary>
        /// Combines two priority levels, returning the lower priority.
        /// </summary>
        /// <param name="priority1">The first priority level.</param>
        /// <param name="priority2">The second priority level.</param>
        /// <returns>The lower of the two priority levels.</returns>
        public static Priority Min(this Priority priority1, Priority priority2)
        {
            return priority1 < priority2 ? priority1 : priority2;
        }
    }
}
