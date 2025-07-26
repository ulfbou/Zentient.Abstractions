// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Errors
{
    /// <summary>
    /// Represents structured information about a specific error instance.
    /// </summary>
    /// <typeparam name="TErrorType">The specific <see cref="IErrorType"/> that defines this error.</typeparam>
    /// <remarks>
    /// This interface provides a detailed, type-safe representation of an error that occurred,
    /// including its definition, a specific message, a unique instance ID, and optional nested errors and metadata.
    /// It aligns with domain boundaries and contracts, making error handling and diagnostics more robust.
    /// </remarks>
    public interface IErrorInfo<out TErrorType> : IHasMetadata
        where TErrorType : IErrorType
    {
        /// <summary>
        /// Gets the specific <see cref="IErrorType"/> instance that defines this error.
        /// </summary>
        /// <value>The definition of this error, providing its semantic meaning and core characteristics.</value>
        TErrorType ErrorDefinition { get; }

        /// <summary>
        /// Gets a specific message detailing this particular occurrence of the error.
        /// </summary>
        /// <value>A human-readable message providing context for this error instance.</value>
        string Message { get; }

        /// <summary>
        /// Gets a unique identifier for this specific error occurrence.
        /// </summary>
        /// <value>A GUID or similar unique string to trace this individual error instance across logs and systems.</value>
        string InstanceId { get; }

        /// <summary>
        /// Gets a read-only collection of inner errors, if this error is a composite of multiple failures.
        /// </summary>
        /// <remarks>
        /// The <see cref="IErrorType"/> constraint on inner errors is deliberately loosened to a non-generic
        /// <see cref="IErrorType"/> to prevent excessive generic depth in complex nested error structures,
        /// allowing for simpler handling of compound errors.
        /// </remarks>
        IReadOnlyCollection<IErrorInfo<IErrorType>> InnerErrors { get; }
    }
}
