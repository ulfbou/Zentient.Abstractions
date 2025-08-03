// <copyright file="IContextualResult{out TContextDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;

namespace Zentient.Abstractions.Results
{
    /// <summary>
    /// Represents the result of an operation that includes contextual information.
    /// </summary>
    /// <typeparam name="TContextDefinition">
    /// The specific <see cref="IContextDefinition"/> that defines the context for this result.
    /// </typeparam>
    /// <remarks>
    /// This interface extends <see cref="IResult"/> by associating the result with a strongly-typed context,
    /// providing additional environmental and operational data relevant to the result.
    /// </remarks>
    public interface IContextualResult<out TContextDefinition> : IResult
        where TContextDefinition : IContextDefinition
    {
        /// <summary>
        /// Gets the context associated with this result.
        /// </summary>
        /// <value>
        /// An instance of <see cref="IContext{TContextDefinition}"/> providing ambient information for the operation.
        /// </value>
        IContext<TContextDefinition> Context { get; }
    }
}
