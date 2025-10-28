// <copyright file="IValidatorFactory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Validation.Definitions;

namespace Zentient.Abstractions.Validation.Factories
{
    /// <summary>Provides methods for creating instances of validators.</summary>
    public interface IValidatorFactory
    {
        /// <summary>Creates a validator for a given validation type definition.</summary>
        /// <typeparam name="TIn">The type of the input the validator will process.</typeparam>
        /// <typeparam name="TCodeDefinition">The type of the code for the validation result.</typeparam>
        /// <typeparam name="TErrorDefinition">
        /// The type of the error for the validation result.
        /// </typeparam>
        /// <param name="definition">The type definition of the validator to create.</param>
        /// <returns>A new instance of a validator.</returns>
        IValidator<TIn, TCodeDefinition, TErrorDefinition> Create<TIn, TCodeDefinition, TErrorDefinition>(IValidationDefinition definition)
            where TCodeDefinition : IValidationCodeDefinition
            where TErrorDefinition : IValidationErrorDefinition;

        /// <summary>
        /// Creates a validator by inferring its type from the generic parameters.
        /// </summary>
        /// <typeparam name="TIn">The type of the input the validator will process.</typeparam>
        /// <typeparam name="TCodeDefinition">The type of the code for the validation result.</typeparam>
        /// <typeparam name="TErrorDefinition">
        /// The type of the error for the validation result.
        /// </typeparam>
        /// <returns>A new instance of a validator.</returns>
        IValidator<TIn, TCodeDefinition, TErrorDefinition> Create<TIn, TCodeDefinition, TErrorDefinition>()
            where TCodeDefinition : IValidationCodeDefinition
            where TErrorDefinition : IValidationErrorDefinition;

        /// <summary>Creates a validator based on its unique identifier.</summary>
        /// <typeparam name="TIn">The type of the input the validator will process.</typeparam>
        /// <typeparam name="TCodeDefinition">The type of the code for the validation result.</typeparam>
        /// <typeparam name="TErrorDefinition">The type of the error for the validation result.
        /// </typeparam>
        /// <param name="validatorTypeId">The unique identifier of the validator type.</param>
        /// <returns>A new instance of a validator.</returns>
        IValidator<TIn, TCodeDefinition, TErrorDefinition> Create<TIn, TCodeDefinition, TErrorDefinition>(
            string validatorTypeId)
            where TCodeDefinition : IValidationCodeDefinition
            where TErrorDefinition : IValidationErrorDefinition;
    }
}
