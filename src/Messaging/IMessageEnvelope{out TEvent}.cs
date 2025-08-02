// <copyright file="IMessageEnvelope{out TEvent}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Messaging.Events;

namespace Zentient.Abstractions.Messaging
{
    /// <summary>
    /// Represents an envelope for a message event, including code, errors, messages, and the event body.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event contained in the envelope.</typeparam>
    /// <typeparam name="TCodeType">The type of the code associated with the message.</typeparam>
    /// <typeparam name="TErrorType">The type of the error associated with the message.</typeparam>
    public interface IMessageEnvelope<out TEvent, out TCodeType, TErrorType> : IEnvelope<TCodeType, TErrorType, TEvent>
        where TEvent : IEvent
        where TCodeType : ICodeType
        where TErrorType : IMessageErrorType
    {
        /// <summary>
        /// Gets the strongly-typed event body contained in the envelope.
        /// </summary>
        /// <value>
        /// The event body, or <c>null</c> if not present.
        /// </value>
        TEvent? Body => Value;
    }
}
