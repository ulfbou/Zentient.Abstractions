// <copyright file="IEventHandler.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Events
{
    /// <summary>
    /// Represents a handler for a specific event type.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to handle.</typeparam>
    /// <typeparam name="TResult">The type of result produced by the event handler.</typeparam>
    [SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "<Pending>")]
    public interface IEventHandler<TEvent, TResult>
        where TEvent : IEvent
        where TResult : IResult
    {
        /// <summary>
        /// Handles the specified event message asynchronously.
        /// </summary>
        /// <param name="eventMessage">The event message to handle.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<TResult> Handle(TEvent eventMessage);
    }
}
