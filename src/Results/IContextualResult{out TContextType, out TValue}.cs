// <copyright file="IContextualResult{out TContextType, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;

namespace Zentient.Abstractions.Results
{
    /// <summary>
    /// Represents the result of an operation that includes contextual information and produces a value.
    /// </summary>
    /// <typeparam name="TContextType">
    /// The specific <see cref="IContextType"/> that defines the context for this result.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type of the value produced by the operation.
    /// </typeparam>
    /// <remarks>
    /// This interface extends <see cref="IContextualResult{TContextType}"/> and <see cref="IResult{TValue}"/>,
    /// combining contextual data with a typed result value.
    /// </remarks>
    public interface IContextualResult<out TContextType, out TValue>
        : IContextualResult<TContextType>, IResult<TValue>
        where TContextType : IContextType
    { }
}
