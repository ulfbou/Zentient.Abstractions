// <copyright file="IValidatorFactory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Validation.Factories
{
    /// <summary>
    /// Resolves or creates validators by type, input type, or identifier.
    /// Mirrors IFormatterFactory / IOptionsProvider patterns.
    /// </summary>
    public interface IValidatorFactory
    {
        /// <summary>
        /// Create a validator instance for the given validation definition.
        /// </summary>
        IValidator<TIn, TCodeType, TErrorType> Create<TIn, TCodeType, TErrorType>(
            IValidationType definition)
            where TCodeType : ICodeType
            where TErrorType : IErrorType;

        /// <summary>
        /// Auto-resolve the best-matching validator for inputs of type TIn.
        /// </summary>
        IValidator<TIn, TCodeType, TErrorType> Create<TIn, TCodeType, TErrorType>()
            where TCodeType : ICodeType
            where TErrorType : IErrorType;

        /// <summary>
        /// Create a validator by its well-known string identifier.
        /// </summary>
        IValidator<TIn, TCodeType, TErrorType> Create<TIn, TCodeType, TErrorType>(
            string validatorTypeId)
            where TCodeType : ICodeType
            where TErrorType : IErrorType;
    }
}
