// <copyright file="IHasDescription.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common
{
    /// <summary>Represents an entity or definition that includes a descriptive text.</summary>
    /// <remarks>
    /// This description provides more detailed information about the purpose,
    /// usage, or characteristics of the entity than its simple name.
    /// </remarks>
    public interface IHasDescription
    {
        /// <summary>Gets the description of the entity or definition.</summary>
        /// <value>A non-null, non-empty string providing a description.</value>
        string Description { get; }
    }
}
