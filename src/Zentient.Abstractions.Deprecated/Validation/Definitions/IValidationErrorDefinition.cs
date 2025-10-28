// <copyright file="IValidationErrorDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;
using Zentient.Abstractions.Validation.Definitions;

namespace Zentient.Abstractions.Validation.Definitions
{
    /// <summary>Represents a type definition for a validation error.</summary>
    /// <remarks>
    /// Validation error types inherit from <see langword="IErrorDefinition" /> 
    /// framework's standardized error handling.
    /// </remarks>
    public interface IValidationErrorDefinition : IErrorDefinition
    {
        /// <summary>Gets the definition of the validation type that generated this error.</summary>
        /// <value>
        /// The <see cref="IValidationDefinition"/> that defines the validation strategy for this error type.
        /// </value>
        IValidationDefinition ValidationDefinition { get; }
    }
}
