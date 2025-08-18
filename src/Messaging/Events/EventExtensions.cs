// <copyright file="EventExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Messaging.Events
{
#if NETSTANDARD2_0
    /// <summary>
    /// Provides extension methods for <see cref="IEvent"/> to retrieve the event type name.
    /// </summary>
    public static class EventExtensions
    {
        /// <summary>
        /// Gets the event type name for the specified event instance.
        /// </summary>
        /// <param name="eventInstance">The event instance.</param>
        /// <returns>The full type name of the event, or the type name if the full name is not available.</returns>
        public static string GetEventType(this IEvent eventInstance)
            => eventInstance?.GetType().FullName ?? eventInstance?.GetType().Name
            ?? throw new ArgumentNullException(nameof(eventInstance), "Event instance cannot be null.");
    }
#endif
}
