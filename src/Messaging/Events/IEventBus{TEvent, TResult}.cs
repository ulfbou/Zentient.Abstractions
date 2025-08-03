// <copyright file="IEventBus{TEvent}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Events
{
    /// <summary>
    /// Represents an event bus that can both produce and consume events of a specific type.
    /// </summary>
    /// <typeparam name="TEvent">The type of event handled by the bus.</typeparam>
    public interface IEventBus<TEvent> : IMessageProducer<TEvent, IResult>, IMessageConsumer<TEvent, IResult>
        where TEvent : IEvent
    { }
}
