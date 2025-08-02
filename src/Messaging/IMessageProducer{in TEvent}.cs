// <copyright file="IMessageProducer{in TEvent}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Messaging.Events;
using Zentient.Abstractions.Messaging.Options;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging
{
    /// <summary>
    /// Represents a producer that can publish events of a specific type.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to publish.</typeparam>
    public interface IMessageProducer<in TEvent>
        where TEvent : IEvent
    {
        /// <summary>
        /// Publishes the specified event message asynchronously.
        /// </summary>
        /// <param name="message">The event message to publish.</param>
        /// <param name="options">The options for the message, if any.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that resolves to a result indicating the outcome of the publish operation.</returns>
        Task<IResult> Publish<TValue>(
            TEvent message,
            IMessagingOptions<IMessagingOptionsType, TValue>? options = default,
            CancellationToken cancellationToken = default);
    }
}
