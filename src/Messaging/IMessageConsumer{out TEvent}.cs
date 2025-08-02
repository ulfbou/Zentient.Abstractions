// <copyright file="IMessageConsumer{out TEvent}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Messaging.Events;

namespace Zentient.Abstractions.Messaging
{
    /// <summary>
    /// Represents a consumer that can subscribe to events of a specific type.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to consume.</typeparam>
    public interface IMessageConsumer<out TEvent>
        where TEvent : IEvent
    {
        /// <summary>
        /// Subscribes the specified event handler to receive events.
        /// </summary>
        /// <param name="handler">The event handler to subscribe.</param>
        /// <returns>An <see cref="IDisposable"/> that can be used to unsubscribe the handler.</returns>
        IDisposable Subscribe(IEventHandler<TEvent> handler);
    }
}
