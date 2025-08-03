// <copyright file="IMessagingPipeline{in TMessage}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Pipelines
{
    /// <summary>Represents a message processing pipeline.</summary>
    /// <typeparam name="TMessage">
    /// The type of the message being processed by the pipeline.
    /// </typeparam>
    public interface IMessagingPipeline<in TMessage>
        where TMessage : IMessage
    {
        /// <summary>Executes the middleware pipeline for a given message.</summary>
        /// <param name="message">The message to be processed.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        Task<IResult> Process(TMessage message, CancellationToken cancellationToken);
    }
}
