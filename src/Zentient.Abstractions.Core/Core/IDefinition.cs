// <copyright file="IDefinition.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Represents a declarative definition or schema that is addressable by a string identifier.
    /// Definitions are typically blueprints (abstract concepts) rather than runtime instances.
    /// </summary>
    public interface IDefinition : IAddressable<string> { }
}
