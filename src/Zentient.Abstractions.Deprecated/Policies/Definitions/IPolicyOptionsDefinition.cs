// <copyright file="IPolicyOptionsDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;
using Zentient.Abstractions.Options.Definitions;

namespace Zentient.Abstractions.Policies.Definitions
{
    /// <summary>
    /// Represents a strongly-typed options type for policy configuration.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="IOptionsDefinition"/> and is used to provide type information
    /// for policy options in advanced policy scenarios.
    /// </remarks>
    public interface IPolicyOptionsDefinition : IOptionsDefinition
    { }
}
