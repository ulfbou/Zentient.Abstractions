// <copyright file="ICommand{out TCommandDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Messaging.Commands.Definitions;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Commands
{
    /// <summary>
    /// Represents a command instance with a strongly-typed definition, correlation ID, and metadata.
    /// </summary>
    /// <typeparam name="TCommandDefinition">The specific <see cref="ICommandDefinition"/> that defines this command.</typeparam>
    public interface ICommand<out TCommandDefinition> : IHasCorrelationId, IHasMetadata
        where TCommandDefinition : ICommandDefinition
    {
        /// <summary>
        /// Gets the specific <see cref="ICommandDefinition"/> definition associated with this command instance.
        /// </summary>
        /// <value>The command type definition.</value>
        TCommandDefinition Definition { get; }
    }
}
