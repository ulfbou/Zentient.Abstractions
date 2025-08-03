// <copyright file="IServiceResolver.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.DependencyInjection.Predicates;
using Zentient.Abstractions.DependencyInjection.Scopes;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.DependencyInjection
{
    /// <summary>
    /// Represents a DI-agnostic resolver for retrieving services from the container.
    /// </summary>
    /// <remarks>
    /// This is the primary abstraction for consumers to resolve services.
    /// It provides both exception-based and result-based resolution methods,
    /// with full support for asynchronous operations and metadata-driven queries.
    /// It also provides access to the <see cref="IServiceScopeFactory"/> for managing scoped
    /// services.
    /// </remarks>
    public interface IServiceResolver : IServiceProvider
    {
        /// <summary>Gets the factory for creating new service scopes.</summary>
        IServiceScopeFactory ScopeFactory { get; }

        /// <summary>
        /// Resolves a single instance of the specified contract using an optional metadata-based
        /// predicate.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to monitor for cancellation requests.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, returning an
        /// <see cref="IResult{TContract}"/> indicating success or failure of the resolution.
        /// </returns>
        Task<IResult<TContract>> ResolveSingle<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolves a single instance of the specified contract using a structured metadata
        /// predicate.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">A structured predicate to filter service descriptors.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, returning an
        /// <see cref="IResult{TContract}"/> indicating success or failure of the resolution.
        /// </returns>
        Task<IResult<TContract>> ResolveSingle<TContract>(
            IMetadataPredicate predicate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolves all registered instances of the specified contract asynchronously,
        /// using an optional metadata-based predicate.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">
        /// An optional function to filter service descriptors based on metadata.
        /// </param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// An asynchronous enumerable of all resolved instances matching the criteria.
        /// </returns>
        IAsyncEnumerable<TContract> ResolveMany<TContract>(
            Func<IServiceDescriptor, bool>? predicate = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolves all registered instances of the specified contract asynchronously,
        /// using a structured metadata predicate.
        /// </summary>
        /// <typeparam name="TContract">The contract type to resolve.</typeparam>
        /// <param name="predicate">A structured predicate to filter service descriptors.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// An asynchronous enumerable of all resolved instances matching the criteria.
        /// </returns>
        IAsyncEnumerable<TContract> ResolveMany<TContract>(
            IMetadataPredicate predicate,
            CancellationToken cancellationToken = default);
    }
}
