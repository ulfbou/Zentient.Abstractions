// <copyright file="IMessagingOptionsDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;
using Zentient.Abstractions.Options.Definitions;

namespace Zentient.Abstractions.Messaging.Definitions
{
    /// <summary>Represents a type definition for messaging options.</summary>
    /// <remarks>
    /// This is a non-generic marker interface that inherits from IOptionsDefinition, ensuring
    /// consistency with the framework's core options pattern.
    /// </remarks>
    public interface IMessagingOptionsDefinition : IOptionsDefinition { }
}
