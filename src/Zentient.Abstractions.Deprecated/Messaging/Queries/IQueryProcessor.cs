// <copyright file="IQueryProcessor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Messaging.Definitions;
using Zentient.Abstractions.Messaging.Options;
using Zentient.Abstractions.Messaging.Queries.Definitions;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Queries
{
    /// <summary>Represents a processor for dispatching queries to their handlers.</summary>
    public interface IQueryProcessor
    {
        /// <summary>Asynchronously processes a query and returns the result.</summary>
        /// <typeparam name="TQueryDefinition">The type definition of the query.</typeparam>
        /// <typeparam name="TValue">The type of the value being queried.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query to process.</param>
        /// <param name="options">
        /// Optional messaging options, such as destination or headers.
        /// </param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The result of the query.</returns>
        Task<TResult> Process<TQueryDefinition, TValue, TResult>(
            IQuery<TQueryDefinition, TResult> query,
            IMessagingOptions<IMessagingOptionsDefinition, TValue>? options = default,
            CancellationToken cancellationToken = default)
            where TQueryDefinition : IQueryDefinition
            where TResult : IResult;
    }
}
