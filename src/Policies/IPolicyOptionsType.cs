// <copyright file="IPolicyOptionsType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;

namespace Zentient.Abstractions.Policies
{
    /// <summary>
    /// Represents a strongly-typed options type for policy configuration.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="IOptionsType"/> and is used to provide type information
    /// for policy options in advanced policy scenarios.
    /// </remarks>
    public interface IPolicyOptionsType : IOptionsType
    { }
}
