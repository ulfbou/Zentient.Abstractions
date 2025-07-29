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
    /// <summary>
    /// Core abstraction for validating inputs of type <typeparamref name="TIn"/>,
    /// yielding a standard envelope result whose Value is true when valid.
    /// </summary>
    /// <typeparam name="TIn">The type to validate.</typeparam>
    /// <typeparam name="TCodeType">
    /// Semantic code categorizing success/failure (e.g. Success, InvalidInput,
    /// BusinessRuleViolation).
    /// </typeparam>
    /// <typeparam name="TErrorType">Enumerates detailed validation errors.</typeparam>
    public interface IValidator<in TIn, TCodeType, TErrorType>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        /// <summary>Descriptor for this validator (identifier, version, docs).</summary>
        IValidationType Type { get; }

        /// <summary>Performs validation asynchronously.</summary>
        /// <param name="input">Input to validate.</param>
        /// <param name="context">
        /// Optional context for metadata, localization, correlation, etc.
        /// </param>
        /// <param name="cancellationToken">Token to cancel validation early.</param>
        /// <returns>
        /// Envelope containing:
        ///   – <typeparamref name="TCodeType"/> code  
        ///   – zero or more <typeparamref name="TErrorType"/> entries  
        ///   – <c>bool</c> indicating overall validity  
        /// </returns>
        Task<IEnvelope<TCodeType, TErrorType, bool>> Validate(
            TIn input,
            IValidationContext? context = default,
            CancellationToken cancellationToken = default);
    }
}
