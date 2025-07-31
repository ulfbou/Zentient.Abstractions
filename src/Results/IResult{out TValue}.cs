// <copyright file="IResult{out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Results
{
    /// <summary>Represents the result of an operation that produces a value.</summary>
    /// <typeparam name="TValue">The type of the value produced by the operation.</typeparam>
    public interface IResult<out TValue> : IResult
    {
        /// <summary>Gets the value of the result.</summary>
        /// <value>
        /// The value produced by the operation if successful;
        /// otherwise, the default value for <typeparamref name="TValue" />.
        /// </value>
        TValue Value { get; }
    }
}
