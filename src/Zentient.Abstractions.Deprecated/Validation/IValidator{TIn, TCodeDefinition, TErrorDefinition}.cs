// <copyright file="IValidator{TIn, TCodeDefinition, TErrorDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Validation.Definitions;

namespace Zentient.Abstractions.Validation
{
    /// <summary>Represents a validator for a specific input type.</summary>
    /// <typeparam name="TIn">The type of the input to validate.</typeparam>
    /// <typeparam name="TCodeDefinition">
    /// The type of the code associated with the validation result.
    /// </typeparam>
    /// <typeparam name="TErrorDefinition">
    /// The type of the error associated with the validation result.
    /// </typeparam>
    /// <remarks>
    /// The validator's primary method, Validate, returns a specialized IEnvelope to
    /// ensure a consistent result model across the entire framework.
    /// </remarks>
    public interface IValidator<TIn, TCodeDefinition, TErrorDefinition>
        where TCodeDefinition : IValidationCodeDefinition
        where TErrorDefinition : IValidationErrorDefinition
    {
        /// <summary>Gets the type definition for this validator.</summary>
        IValidationDefinition definition { get; }

        /// <summary>Asynchronously validates the specified input.</summary>
        /// <param name="input">The object to validate.</param>
        /// <param name="metadata">
        /// An optional set of metadata and options for the validation.
        /// </param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous validation operation. The task's result is an
        /// IEnvelope containing the validated input, a validation code, and any errors.
        /// </returns>
        Task<IEnvelope<TCodeDefinition, TErrorDefinition, TIn>> Validate(
            TIn input,
            IValidationContext? metadata = default,
            CancellationToken cancellationToken = default);
    }
}
