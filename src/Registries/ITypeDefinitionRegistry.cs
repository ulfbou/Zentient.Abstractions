// <copyright file="ITypeDefinitionRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Registries
{
    /// <summary>
    /// Provides a registry for resolving known <see cref="ITypeDefinition"/> instances at runtime.
    /// </summary>
    /// <remarks>
    /// This interface facilitates reflectionless discovery and retrieval of type definitions
    /// across the system, enabling dynamic behavior, tooling support, and centralized management.
    /// Implementations would typically be populated via dependency injection at application
    /// startup.
    /// </remarks>
    public interface ITypeDefinitionRegistry
    {
        /// <summary>
        /// Retrieves all known <see cref="ITypeDefinition"/> instances registered in the system.
        /// </summary>
        /// <returns>An enumerable collection of all registered type definitions.</returns>
        IEnumerable<ITypeDefinition> GetAll();

        /// <summary>
        /// Attempts to retrieve a <see cref="ITypeDefinition"/> by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the type definition to retrieve. Must not be null or empty.
        /// </param>
        /// <param name="definition">
        /// When this method returns, contains the <see cref="ITypeDefinition"/> associated
        /// with the specified ID, if found; otherwise, <see langword="null"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the type definition with the specified ID is found;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="id"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="id"/> is empty or whitespace.
        /// </exception>
        bool TryGetById(string id, [MaybeNullWhen(false)] out ITypeDefinition definition);

        /// <summary>
        /// Attempts to retrieve a specific type of <see cref="ITypeDefinition"/> by its
        /// unique identifier.
        /// </summary>
        /// <typeparam name="TDefinition">
        /// The specific type of definition to retrieve (must be an <see cref="ITypeDefinition"/>).
        /// </typeparam>
        /// <param name="id">
        /// The unique identifier of the type definition to retrieve. Must not be null or empty.
        /// </param>
        /// <param name="definition">
        /// When this method returns, contains the <typeparamref name="TDefinition"/> associated
        /// with the specified ID, if found and castable; otherwise, <see langword="null"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the type definition with the specified ID is found and is of
        /// the specified type; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="id"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="id"/> is empty or whitespace.
        /// </exception>
        bool TryGetById<TDefinition>(string id, [MaybeNullWhen(false)] out TDefinition definition) where TDefinition : ITypeDefinition;

        /// <summary>
        /// Retrieves a <see cref="ITypeDefinition"/> by its unique identifier,
        /// returning <see langword="null"/> if not found.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the type definition to retrieve. Must not be null or empty.
        /// </param>
        /// <returns>
        /// The <see cref="ITypeDefinition"/> associated with the specified ID, or <see langword="null"/> if not found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="id"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="id"/> is empty or whitespace.
        /// </exception>
        ITypeDefinition? GetById(string id);

        /// <summary>
        /// Retrieves a specific type of <see cref="ITypeDefinition"/> by its unique identifier,
        /// throwing an exception if not found or not of the specified type.
        /// </summary>
        /// <typeparam name="TDefinition">
        /// The specific type of definition to retrieve (must be an <see cref="ITypeDefinition"/>).
        /// </typeparam>
        /// <param name="id">
        /// The unique identifier of the type definition to retrieve. Must not be null or empty.
        /// </param>
        /// <returns>
        /// The <typeparamref name="TDefinition"/> associated with the specified ID.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="id"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="id"/> is empty or whitespace.
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if the type definition with the specified ID is not found.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// Thrown if the found type definition cannot be cast to
        /// <typeparamref name="TDefinition"/>.
        /// </exception>
        TDefinition GetById<TDefinition>(string id) where TDefinition : ITypeDefinition;
    }
}
