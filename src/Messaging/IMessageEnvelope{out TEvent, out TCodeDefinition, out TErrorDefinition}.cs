// <copyright file="IMessageEnvelope{out TEvent, out TCodeDefinition, out TErrorDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Messaging.Definitions;
using Zentient.Abstractions.Messaging.Events;

namespace Zentient.Abstractions.Messaging
{
    /// <summary>
    /// Represents an envelope for a message event, including code, errors, messages, and the event body.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event contained in the envelope.</typeparam>
    /// <typeparam name="TCodeDefinition">The type of the code associated with the message.</typeparam>
    /// <typeparam name="TErrorDefinition">The type of the error associated with the message.</typeparam>
    public interface IMessageEnvelope<out TEvent, out TCodeDefinition, out TErrorDefinition> : IEnvelope<TCodeDefinition, TErrorDefinition, TEvent>
        where TEvent : IEvent
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IMessageErrorDefinition
    {
        /// <summary>
        /// Gets the strongly-typed event body contained in the envelope.
        /// </summary>
        /// <value>
        /// The event body, or <c>null</c> if not present.
        /// </value>
#if NETSTANDARD2_0
        TEvent? Body { get; }
#else
        TEvent? Body => Value;
#endif
    }
}
