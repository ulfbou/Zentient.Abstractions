// <copyright file="IValidator{in TIn, out TOut}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Validation
{
    /// <summary>
    /// Represents the definition of a validation error type, associating it with a specific validation type.
    /// </summary>
    public interface IValidationErrorType : IErrorType
    {
        /// <summary>
        /// Gets the validation type associated with this error.
        /// </summary>
        /// <value>
        /// The <see cref="IValidationType"/> that defines the validation strategy for this error type.
        /// </value>
        IValidationType ValidationType { get; }
    }
}
