// <copyright file="InternalResult.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Endpoints.Internal
{
    /// <summary>
    /// Defines a contract for endpoint outcomes that encapsulate an internal business operation result.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the internal result, which must implement <see cref="Zentient.Abstractions.Results.IResult"/>.
    /// </typeparam>
    internal interface IInternalResult<out TResult>
        where TResult : IResult
    {
        /// <summary>Gets the internal business operation result encapsulated by this endpoint outcome.</summary>
        /// <value>The internal result of type <typeparamref name="TResult"/>.</value>
        internal TResult InternalResult { get; }
    }
}
