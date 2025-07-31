// <copyright file="IValidator{in TIn, out TOut}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Validation
{
    /// <summary>
    /// Represents a validation error that is specific to a validation type.
    /// </summary>
    public interface IValidationError : IErrorInfo<IValidationErrorType>
    {
        /// <summary>
        /// Gets the validation type associated with this error.
        /// </summary>
        /// <value>
        /// The <see cref="IValidationType"/> that defines the validation strategy for this error instance.
        /// </value>
        IValidationType ValidationType { get; }
    }
}
