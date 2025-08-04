// <copyright file="IIdentifiableDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common.Definitions
{
    /// <summary>
    /// Represents a definition that is uniquely identifiable.
    /// All identifiable definitions must implement this interface, which adds
    /// a unique string identifier.
    /// </summary>
    public interface IIdentifiableDefinition : IDefinition, IIdentifiable { }
}
