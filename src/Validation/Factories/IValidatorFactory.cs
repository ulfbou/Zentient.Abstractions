// <copyright file="IValidatorFactory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Validation.Factories
{
    /// <summary>Provides methods for creating instances of validators.</summary>
    public interface IValidatorFactory
    {
        /// <summary>Creates a validator for a given validation type definition.</summary>
        /// <typeparam name="TIn">The type of the input the validator will process.</typeparam>
        /// <typeparam name="TCodeType">The type of the code for the validation result.</typeparam>
        /// <typeparam name="TErrorType">
        /// The type of the error for the validation result.
        /// </typeparam>
        /// <param name="definition">The type definition of the validator to create.</param>
        /// <returns>A new instance of a validator.</returns>
        IValidator<TIn, TCodeType, TErrorType> Create<TIn, TCodeType, TErrorType>(IValidationType definition)
            where TCodeType : IValidationCodeType
            where TErrorType : IValidationErrorType;

        /// <summary>
        /// Creates a validator by inferring its type from the generic parameters.
        /// </summary>
        /// <typeparam name="TIn">The type of the input the validator will process.</typeparam>
        /// <typeparam name="TCodeType">The type of the code for the validation result.</typeparam>
        /// <typeparam name="TErrorType">
        /// The type of the error for the validation result.
        /// </typeparam>
        /// <returns>A new instance of a validator.</returns>
        IValidator<TIn, TCodeType, TErrorType> Create<TIn, TCodeType, TErrorType>()
            where TCodeType : IValidationCodeType
            where TErrorType : IValidationErrorType;

        /// <summary>Creates a validator based on its unique identifier.</summary>
        /// <typeparam name="TIn">The type of the input the validator will process.</typeparam>
        /// <typeparam name="TCodeType">The type of the code for the validation result.</typeparam>
        /// <typeparam name="TErrorType">The type of the error for the validation result.
        /// </typeparam>
        /// <param name="validatorTypeId">The unique identifier of the validator type.</param>
        /// <returns>A new instance of a validator.</returns>
        IValidator<TIn, TCodeType, TErrorType> Create<TIn, TCodeType, TErrorType>(
            string validatorTypeId)
            where TCodeType : IValidationCodeType
            where TErrorType : IValidationErrorType;
    }
}
