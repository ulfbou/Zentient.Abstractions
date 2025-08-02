// <copyright file="IValidationErrorType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Validation
{
    /// <summary>Represents a type definition for a validation error.</summary>
    /// <remarks>
    /// Validation error types inherit from <see langword="IErrorType" /> 
    /// framework's standardized error handling.
    /// </remarks>
    public interface IValidationErrorType : IErrorType
    {
        /// <summary>Gets the definition of the validation type that generated this error.</summary>
        /// <value>
        /// The <see cref="IValidationType"/> that defines the validation strategy for this error type.
        /// </value>
        IValidationType ValidationType { get; }
    }
}
