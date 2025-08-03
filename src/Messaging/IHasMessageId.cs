// <copyright file="IHasMessageId.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Messaging
{
    /// <summary>Represents an entity that carries a message identifier.</summary>
    /// <remarks>
    /// A message ID is used to link together messages, events, or operations
    /// that are part of the same logical flow or transaction. 
    /// </remarks>
    public interface IHasMessageId
    {
        /// <summary>Gets the message identifier for the message.</summary>
        /// <value>A non-null, non-empty string representing the message ID.</value>
        string MessageId { get; }
    }
}
