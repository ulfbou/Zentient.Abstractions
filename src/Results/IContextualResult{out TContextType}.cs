// <copyright file="IContextualResult{out TContextType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;

namespace Zentient.Abstractions.Results
{
    /// <summary>
    /// Represents the result of an operation that includes contextual information.
    /// </summary>
    /// <typeparam name="TContextType">
    /// The specific <see cref="IContextType"/> that defines the context for this result.
    /// </typeparam>
    /// <remarks>
    /// This interface extends <see cref="IResult"/> by associating the result with a strongly-typed context,
    /// providing additional environmental and operational data relevant to the result.
    /// </remarks>
    public interface IContextualResult<out TContextType> : IResult
        where TContextType : IContextType
    {
        /// <summary>
        /// Gets the context associated with this result.
        /// </summary>
        /// <value>
        /// An instance of <see cref="IContext{TContextType}"/> providing ambient information for the operation.
        /// </value>
        IContext<TContextType> Context { get; }
    }
}
