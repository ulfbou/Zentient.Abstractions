// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Marker interface for code domains/types. 
    /// This interface is used to categorize and identify different types of codes within the Zentient framework.
    /// It provides a way to define unique identifiers and human-readable names for code types.
    /// </summary>
    public interface ICodeType {
        /// <summary>
        /// Gets a unique identifier for this code type.
        /// This property is primarily for identification, diagnostics, and satisfying static analysis rules.
        /// </summary>
        /// <value>The unique identifier for this code type.</value>
        string Id { get; }

        /// <summary>
        /// Gets a human-readable name for this code type.
        /// This name is used for documentation, diagnostics, and user interfaces.
        /// It should be descriptive enough to convey the purpose of the code type.
        /// </summary>
        /// <value>The human-readable name for this code type.</value>
        string Name { get; }
    }
}
