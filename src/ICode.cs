// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents a universal, protocol-agnostic code for an operation outcome or detail.
    /// </summary>
    public interface ICode
    {
        /// <summary>
        /// Gets the symbolic name of the code (e.g., "NotFound", "ValidationError", "Success", "InsufficientFunds").
        /// This provides a human-readable or machine-interpretable identifier for the specific situation.
        /// </summary>
        /// <value>The symbolic name of the code.</value>
        string Name { get; }

        /// <summary>Default recommended severity for this code.</summary>
        /// <value>The default severity level for this code.</value>
        ErrorSeverity? DefaultSeverity { get; }

        /// <summary>Optional error category for classification.</summary>
        /// <value>The category of the error, providing additional context for diagnostics.</value>
        ErrorCategory? Category { get; }

        /// <summary>Human-readable description of the code.</summary>
        /// <value>The description of the code, providing additional context or explanation.</value>
        string? Description { get; }

        /// <summary>Extensible metadata for diagnostics, integration, or future use.</summary>
        /// <value>
        /// The metadata associated with this code, which can include additional information such as error 
        /// codes, timestamps, or other relevant details.
        /// </value>
        IReadOnlyDictionary<string, object?>? Metadata { get; }
    }
}