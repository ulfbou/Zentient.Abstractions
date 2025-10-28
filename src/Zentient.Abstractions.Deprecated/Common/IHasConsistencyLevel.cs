// <copyright file="IHasConsistencyLevel.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Represents an object that has a consistency level requirement.
    /// </summary>
    /// <remarks>
    /// This interface provides a standard way to specify consistency requirements
    /// for operations, data access, and distributed system interactions.
    /// </remarks>
    public interface IHasConsistencyLevel
    {
        /// <summary>
        /// Gets the consistency level requirement for the object.
        /// </summary>
        /// <value>The consistency level that must be maintained for operations.</value>
        ConsistencyLevel ConsistencyLevel { get; }
    }
}
