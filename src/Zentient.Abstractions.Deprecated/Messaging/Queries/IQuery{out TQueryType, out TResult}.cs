// <copyright file="IQuery{out TQueryDefinition, out TResult}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Messaging.Queries.Definitions;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Messaging.Queries
{
    /// <summary>
    /// Represents a base contract for a query. A query is a request for data
    /// and should not change the state of the application.
    /// </summary>
    /// <typeparam name="TQueryDefinition">The type definition of the query.</typeparam>
    /// <typeparam name="TResult">The expected result of the query.</typeparam>
    public interface IQuery<out TQueryDefinition, out TResult>
    where TQueryDefinition : IQueryDefinition
    where TResult : IResult
    {
        /// <summary>Gets the type definition for this query.</summary>
        TQueryDefinition Definition { get; }
    }
}
