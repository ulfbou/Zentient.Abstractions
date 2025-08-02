// <copyright file="IMessageCodeType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging
{
    /// <summary>
    /// Represents the type definition for a message code in the Zentient messaging system.
    /// </summary>
    public interface IMessageCodeType : ICodeType { }
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
