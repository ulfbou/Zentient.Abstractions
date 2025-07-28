// <copyright file="IIdentifiable.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Represents an entity or definition that possesses a unique programmatic identifier.
    /// </summary>
    /// <remarks>
    /// This interface is foundational for identifying various components within the system,
    /// such as code types, context types, relation types, or specific instances where a
    /// distinct, machine-readable identifier is required.
    /// </remarks>
    public interface IIdentifiable
    {
        /// <summary>Gets the unique identifier for the entity or definition.</summary>
        /// <value>A non-null, non-empty string representing the unique identifier.</value>
        string Id { get; }
    }
}
