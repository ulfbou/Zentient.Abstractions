// <copyright file="ICommandHandler{in TCommand, TResult}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Commands.Definitions
{
    /// <summary>Represents a handler for a specific command.</summary>
    /// <typeparam name="TCommand">The type of the command to handle.</typeparam>
    /// <typeparam name="TResult">The expected type of the command's result.</typeparam>
    /// <remarks>
    /// Command handlers are the core business logic for executing commands and returning a result.
    /// </remarks>
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand : ICommand<ICommandDefinition>
        where TResult : IResult
    {
        /// <summary>Asynchronously handles the specified command and returns a result.</summary>
        /// <param name="command">The command to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task's result is the command result.</returns>
        Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
