// <copyright file="MessageEnvelopeExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Messaging.Definitions;
using Zentient.Abstractions.Messaging.Events;

namespace Zentient.Abstractions.Messaging
{
#if NETSTANDARD2_0
    public static class MessageEnvelopeExtensions
    {
        /// <summary>
        /// Gets the event body from the envelope.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <typeparam name="TCodeDefinition">The type of the code definition.</typeparam>
        /// <typeparam name="TErrorDefinition">The type of the error definition.</typeparam>
        /// <param name="envelope">The message envelope.</param>
        /// <returns>The event body, or <see langword="null"/> if not present.</returns>
        public static TEvent? GetEventBody<TEvent, TCodeDefinition, TErrorDefinition>(this IMessageEnvelope<TEvent, TCodeDefinition, TErrorDefinition> envelope)
            where TEvent : class, IEvent
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IMessageErrorDefinition
        {
            return envelope?.Body ?? envelope?.Value;
        }
    }
#endif
}
