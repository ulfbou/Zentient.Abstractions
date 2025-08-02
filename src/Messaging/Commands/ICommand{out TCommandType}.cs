// <copyright file="ICommand{out TCommandType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Commands
{
    /// <summary>
    /// Represents a command instance with a strongly-typed definition, correlation ID, and metadata.
    /// </summary>
    /// <typeparam name="TCommandType">The specific <see cref="ICommandType"/> that defines this command.</typeparam>
    public interface ICommand<out TCommandType> : IHasCorrelationId, IHasMetadata
        where TCommandType : ICommandType
    {
        /// <summary>
        /// Gets the specific <see cref="ICommandType"/> definition associated with this command instance.
        /// </summary>
        /// <value>The command type definition.</value>
        TCommandType Definition { get; }
    }
}
