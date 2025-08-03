// <copyright file="ICommandBus{in TCommand, TResult}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Messaging.Definitions;
using Zentient.Abstractions.Messaging.Options;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Commands.Definitions
{
    /// <summary>Represents a command bus for sending commands and receiving a result.</summary>
    /// <typeparam name="TCommand">The type of the command to send.</typeparam>
    /// <typeparam name="TResult">The expected type of the command's result.</typeparam>
    public interface ICommandBus<in TCommand, TResult>
        where TCommand : ICommand<ICommandDefinition>
        where TResult : IResult
    {
        Task<TResult> Send<TValue>(
            TCommand command,
            IMessagingOptions<IMessagingOptionsDefinition, TValue>? options = default,
            CancellationToken cancellationToken = default);
    }
}
