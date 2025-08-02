using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zentient.Abstractions.Messaging.Options;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Commands
{
    /// <summary>Represents a command bus for sending commands and receiving a result.</summary>
    /// <typeparam name="TCommand">The type of the command to send.</typeparam>
    /// <typeparam name="TResult">The expected type of the command's result.</typeparam>
    public interface ICommandBus<TCommand, TResult>
        where TCommand : ICommand<ICommandType>
        where TResult : IResult
    {
        Task<TResult> Send<TValue>(
            TCommand command,
            IMessagingOptions<IMessagingOptionsType, TValue>? options = default,
            CancellationToken cancellationToken = default);
    }
}
