// <copyright file="IValidatorError.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Validation
{
    /// <summary>Represents a validation error.</summary>
    /// <typeparam name="TErrorType">The specific type of the validation error.</typeparam>
    /// <remarks>
    /// This abstraction composes from IErrorInfo, providing a rich, consistent way to represent
    /// validation failures with metadata, messages, and a reference to the validator's type.
    /// </remarks>
    public interface IValidationError<out TErrorType> : IErrorInfo<TErrorType>
        where TErrorType : IValidationErrorType
    {
        /// <summary>Gets the definition of the validation type that generated this error.</summary>
        IValidationType ValidationType { get; }
    }
}
