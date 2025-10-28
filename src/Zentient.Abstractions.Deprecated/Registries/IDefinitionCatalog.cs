// <copyright file="IDefinitionCatalog.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Registries
{
    /// <summary>
    /// Provides a base registry interface for all definition registries,
    /// supporting broad introspection and retrieval.
    /// </summary>
    public interface IDefinitionRegistry
    {
        /// <summary>
        /// Retrieves all definitions of the specified type.
        /// </summary>
        /// <typeparam name="TDefinition">
        /// The type of definition to retrieve. Must implement <see cref="IDefinition"/>.
        /// </typeparam>
        /// <param name="predicate">
        /// An optional predicate to filter definitions. If <see langword="null"/>,
        /// all definitions are returned.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a
        /// read-only collection of all matching definitions. The result is empty if there are no
        /// matching definitions.
        /// </returns>
        Task<IReadOnlyCollection<TDefinition>> GetAll<TDefinition>(
            Func<IDefinition, bool>? predicate = default,
            CancellationToken cancellationToken = default)
            where TDefinition : IDefinition;
    }

    /// <summary>
    /// A generic registry for all definitions, allowing for broad introspection and retrieval.
    /// </summary>
    public interface IDefinitionCatalog : IDefinitionRegistry
    {
        /// <summary>Retrieves all definitions that implement a specific type.</summary>
        /// <typeparam name="TDefinition">
        /// The definition type to filter by. Must implement <see cref="IDefinition"/>.
        /// </typeparam>
        /// <param name="predicate">
        /// An optional predicate to filter definitions. If <see langword="null"/>, all definitions of
        /// the specified type are returned.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a read-only
        /// collection of all matching definitions. The result is empty if there are no matching
        /// definitions.
        /// </returns>
        Task<IReadOnlyCollection<TDefinition>> GetByType<TDefinition>(
            Func<IDefinition, bool>? predicate = default,
            CancellationToken cancellationToken = default)
            where TDefinition : IDefinition;
    }

    /// <summary>A specialized registry for definitions that are uniquely identifiable.</summary>
    public interface IIdentifiableDefinitionRegistry : IDefinitionRegistry
    {
        /// <summary>Retrieves a definition by its unique identifier.</summary>
        /// <param name="id">The unique identifier of the definition.</param>
        /// <param name="cancellationToken">
        /// Cancellation token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing the identifiable
        /// definition if found, or <see langword="null"/> if not found.
        /// </returns>
        Task<IIdentifiableDefinition?> GetById(
            string id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all identifiable definitions, optionally filtered by a predicate.
        /// </summary>
        /// <param name="predicate">
        /// An optional predicate to filter definitions based on their <see cref="ITypeDefinition"/> properties. If <c>null</c>, all definitions are returned.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing an enumerable of
        /// <see cref="IIdentifiableDefinition"/> instances that match the predicate, or all if no
        /// predicate is provided. If no definitions match, the result is empty.
        /// </returns>
        Task<IEnumerable<IIdentifiableDefinition>> GetAll(
            Func<ITypeDefinition, bool>? predicate = null,
            CancellationToken cancellationToken = default);

        /// <summary>Registers an identifiable definition.</summary>
        /// <param name="def">The definition to register.</param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete.
        /// </param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Register(
            IIdentifiableDefinition def,
            CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Provides a registry for resolving known <see cref="ITypeDefinition"/> instances at runtime.
    /// </summary>
    /// <remarks>
    /// This interface facilitates reflectionless discovery and retrieval of type definitions
    /// across the system, enabling dynamic behavior, tooling support, and centralized management.
    /// Implementations would typically be populated via dependency injection at application
    /// startup.
    /// </remarks>
    public interface ITypeDefinitionRegistry : IDefinitionRegistry
    {
        /// <summary>
        /// Retrieves all known <see cref="ITypeDefinition"/> instances registered in the system.
        /// </summary>
        /// <param name="predicate">
        /// An optional predicate to filter type definitions. If <see langword="null"/>, all type
        /// definitions are returned.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a read-only
        /// collection of all matching type definitions. The result is empty if there are no
        /// matching definitions.
        /// </returns>
        Task<IReadOnlyCollection<ITypeDefinition>> GetAll(
            Func<ITypeDefinition, bool>? predicate = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Attempts to retrieve a <see cref="ITypeDefinition"/> by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the type definition to retrieve. Must not be null or empty.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing the
        /// <see cref="ITypeDefinition"/> associated with the specified ID, or
        /// <see langword="null"/> if not found.
        /// </returns>
        Task<ITypeDefinition?> GetById(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Attempts to retrieve a specific type of <see cref="ITypeDefinition"/> by its unique
        /// identifier.
        /// </summary>
        /// <typeparam name="TDefinition">
        /// The specific type of definition to retrieve (must be an <see cref="ITypeDefinition"/>).
        /// </typeparam>
        /// <param name="id">
        /// The unique identifier of the type definition to retrieve. Must not be null or empty.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing the
        /// <typeparamref name="TDefinition"/> associated with the specified ID, or
        /// <see langword="null"/> if not found or not castable.
        /// </returns>
        Task<TDefinition?> GetById<TDefinition>(
            string id,
            CancellationToken cancellationToken = default)
            where TDefinition : ITypeDefinition;
    }
}
