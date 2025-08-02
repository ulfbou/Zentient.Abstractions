// <copyright file="IHasTimestamp.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Represents an entity that has a timestamp indicating when an event (such as a check) completed.
    /// </summary>
    public interface IHasTimestamp
    {
        /// <summary>Gets the UTC timestamp when the log event occurred.</summary>
        /// <value>The timestamp of the log event.</value>
        DateTimeOffset Timestamp { get; }
    }
}
