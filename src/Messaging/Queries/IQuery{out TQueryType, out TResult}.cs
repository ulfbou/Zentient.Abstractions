// <copyright file="IQuery{out TQueryType, out TResult}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Queries
{
    /// <summary>
    /// Represents a base contract for a query. A query is a request for data
    /// and should not change the state of the application.
    /// </summary>
    /// <typeparam name="TQueryType">The type definition of the query.</typeparam>
    /// <typeparam name="TResult">The expected result of the query.</typeparam>
    public interface IQuery<out TQueryType, out TResult>
    where TQueryType : IQueryType
    where TResult : IResult
    {
        /// <summary>Gets the type definition for this query.</summary>
        TQueryType Definition { get; }
    }
}
