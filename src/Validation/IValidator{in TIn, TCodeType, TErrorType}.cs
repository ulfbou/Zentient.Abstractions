// <copyright file="IValidator{in TIn, TCodeType, TErrorType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Validation
{
    /// <summary>Represents a validator for a specific input type.</summary>
    /// <typeparam name="TIn">The type of the input to validate.</typeparam>
    /// <typeparam name="TCodeType">
    /// The type of the code associated with the validation result.
    /// </typeparam>
    /// <typeparam name="TErrorType">
    /// The type of the error associated with the validation result.
    /// </typeparam>
    /// <remarks>
    /// The validator's primary method, Validate, returns a specialized IEnvelope to
    /// ensure a consistent result model across the entire framework.
    /// </remarks>
    public interface IValidator<TIn, TCodeType, TErrorType>
        where TCodeType : IValidationCodeType
        where TErrorType : IValidationErrorType
    {
        /// <summary>Gets the type definition for this validator.</summary>
        IValidationType Type { get; }

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
        Task<IEnvelope<TCodeType, TErrorType, TIn>> Validate(
            TIn input,
            IValidationMetadata? metadata = default,
            CancellationToken cancellationToken = default);
    }
}
