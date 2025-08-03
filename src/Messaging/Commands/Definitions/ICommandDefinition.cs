// <copyright file="ICommandDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Commands.Definitions
{
    /// <summary>Represents a type definition for a command.</summary>
    /// <remarks>
    /// This is a non-generic marker interface that inherits from ITypeDefinition.
    /// </remarks>
    public interface ICommandDefinition : ITypeDefinition { }
}
