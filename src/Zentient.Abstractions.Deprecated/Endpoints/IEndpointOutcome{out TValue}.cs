// <copyright file="IEndpointOutcome{out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Endpoints.Internal;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Results;
using Zentient.Abstractions.Validation;

namespace Zentient.Abstractions.Endpoints
{
    /// <summary>
    /// Represents the outcome of an endpoint operation that produces a value,
    /// encapsulating an internal <see cref="Zentient.Abstractions.Results.IResult{TValue}"/> with endpoint-specific semantics.
    /// </summary>
    /// <typeparam name="TValue">The type of the value produced by the operation.</typeparam>
    public interface IEndpointOutcome<out TValue> : IEndpointOutcome
    {
        /// <summary>
        /// Gets the value produced by the endpoint operation.
        /// </summary>
        /// <remarks>
        /// This property is only valid if the operation was successful.
        /// </remarks>
        TValue Value { get; }
    }
}
