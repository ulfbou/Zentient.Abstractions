// <copyright file="IContextualResult{out TContextDefinition, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;

namespace Zentient.Abstractions.Results
{
    /// <summary>
    /// Represents the result of an operation that includes contextual information and produces a value.
    /// </summary>
    /// <typeparam name="TContextDefinition">
    /// The specific <see cref="IContextDefinition"/> that defines the context for this result.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type of the value produced by the operation.
    /// </typeparam>
    /// <remarks>
    /// This interface extends <see cref="IContextualResult{TContextDefinition}"/> and <see cref="IResult{TValue}"/>,
    /// combining contextual data with a typed result value.
    /// </remarks>
    public interface IContextualResult<out TContextDefinition, out TValue>
        : IContextualResult<TContextDefinition>, IResult<TValue>
        where TContextDefinition : IContextDefinition
    { }
}
