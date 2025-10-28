// <copyright file="IEvent.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Diagnostics;

namespace Zentient.Abstractions.Messaging.Events
{
    /// <summary>
    /// Represents an event in the Zentient messaging system, including message ID, timestamp, correlation ID, and metadata.
    /// </summary>
    public interface IEvent : IHasMessageId, IHasTimestamp, IHasCorrelationId, IHasMetadata
    {
        /// <summary>
        /// Gets the event type name for this event instance.
        /// </summary>
        /// <value>
        /// The full type name of the event, or the type name if the full name is not available.
        /// </value>
#if NETSTANDARD2_0
        string EventType { get; }
#else
        string EventType => GetType().FullName ?? GetType().Name;
#endif
    }
}
