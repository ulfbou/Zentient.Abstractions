// <copyright file="IQueryProcessor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Messaging.Options;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Queries
{
    /// <summary>Represents a processor for dispatching queries to their handlers.</summary>
    public interface IQueryProcessor
    {
        /// <summary>Asynchronously processes a query and returns the result.</summary>
        /// <typeparam name="TQueryType">The type definition of the query.</typeparam>
        /// <typeparam name="TValue">The type of the value being queried.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query to process.</param>
        /// <param name="options">
        /// Optional messaging options, such as destination or headers.
        /// </param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The result of the query.</returns>
        Task<TResult> Process<TQueryType, TValue, TResult>(
            IQuery<TQueryType, TResult> query,
            IMessagingOptions<IMessagingOptionsType, TValue>? options = default,
            CancellationToken cancellationToken = default)
            where TQueryType : IQueryType
            where TResult : IResult;
    }
}
