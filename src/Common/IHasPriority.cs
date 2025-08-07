// <copyright file="IHasPriority.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Represents an object that has a priority level.
    /// </summary>
    /// <remarks>
    /// This interface provides a standard way to assign and query priority levels
    /// across different types of operations, requests, and resources in the framework.
    /// </remarks>
    public interface IHasPriority
    {
        /// <summary>
        /// Gets the priority level of the object.
        /// </summary>
        /// <value>The priority level that determines processing order and resource allocation.</value>
        Priority Priority { get; }
    }
}
