// <copyright file="IQueryHandler{in TQuery, out TResult}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Messaging.Queries.Definitions;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Queries
{
    /// <summary>Represents a handler for a specific query.</summary>
    /// <typeparam name="TQuery">The type of the query to handle.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the query.</typeparam>
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<IQueryDefinition, TResult>
        where TResult : IResult
    {
        /// <summary>Asynchronously handles the given query and returns a result.</summary>
        /// <param name="query">The query to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The result of the query.</returns>
        Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
