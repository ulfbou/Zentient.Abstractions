// <copyright file="IConcept.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// The absolute root contract for every entity with conceptual meaning in Zentient.
    /// This marker interface is the base of the semantic model and does not prescribe any members.
    /// </summary>
    public interface IConcept { }
}

namespace Zentient.Core.Registries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Zentient.Core;

    /// <summary>
    /// Asynchronous registry abstraction that supports basic lifecycle operations.
    /// Implementations should be thread-safe and resilient to transient failures.
    /// </summary>
    /// <typeparam name="TValue">The type of value stored; must implement <see cref="IConcept"/>.</typeparam>
    public interface IAsyncRegistry<TValue> : IRegistry<TValue> where TValue : IConcept
    {
        /// <summary>
        /// Registers an item asynchronously.
        /// </summary>
        ValueTask RegisterAsync(TValue item, CancellationToken ct = default);

        /// <summary>
        /// Unregisters an item asynchronously.
        /// </summary>
        ValueTask<bool> UnregisterAsync(TValue item, CancellationToken ct = default);

        /// <summary>
        /// Retrieves an item by identifier asynchronously.
        /// </summary>
        /// <typeparam name="TId">The identifier type.</typeparam>
        ValueTask<TValue?> GetAsync<TId>(TId id, CancellationToken ct = default) where TId : notnull;

        /// <summary>
        /// Asynchronously enumerates all registered items.
        /// </summary>
        IAsyncEnumerable<TValue> GetAllAsync(CancellationToken ct = default);
    }

    /// <summary>
    /// Asynchronous key/value registry abstraction.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type, must implement <see cref="IConcept"/>.</typeparam>
    public interface IAsyncRegistry<in TKey, TValue> : IRegistry<TKey, TValue>
        where TKey : notnull where TValue : IConcept
    {
        /// <summary>
        /// Registers a key/value pair asynchronously.
        /// </summary>
        ValueTask RegisterAsync(TKey key, TValue value, CancellationToken ct = default);

        /// <summary>
        /// Unregisters the specified key asynchronously.
        /// </summary>
        ValueTask<bool> UnregisterAsync(TKey key, CancellationToken ct = default);

        /// <summary>
        /// Retrieves a value for the specified key asynchronously.
        /// </summary>
        ValueTask<TValue?> GetAsync(TKey key, CancellationToken ct = default);

        /// <summary>
        /// Asynchronously enumerates all values.
        /// </summary>
        IAsyncEnumerable<TValue> GetAllAsync(CancellationToken ct = default);
    }

    /// <summary>
    /// Synchronous registry abstraction for registering and resolving concept instances.
    /// </summary>
    /// <typeparam name="TValue">The type of stored values; must implement <see cref="IConcept"/>.</typeparam>
    public interface IRegistry<TValue> where TValue : IConcept
    {
        /// <summary>
        /// Registers an item in the registry.
        /// </summary>
        void Register(TValue item);

        /// <summary>
        /// Unregisters an item from the registry.
        /// </summary>
        bool Unregister(TValue item);

        /// <summary>
        /// Attempts to retrieve an item by identifier.
        /// </summary>
        /// <typeparam name="TId">The identifier type.</typeparam>
        bool TryGet<TId>(TId id, out TValue? item) where TId : notnull;

        /// <summary>
        /// Returns all registered items.
        /// </summary>
        IEnumerable<TValue> GetAll();
    }

    /// <summary>
    /// Synchronous key/value registry abstraction.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type; must implement <see cref="IConcept"/>.</typeparam>
    public interface IRegistry<in TKey, TValue>
        where TKey : notnull
        where TValue : IConcept
    {
        /// <summary>
        /// Registers a key/value pair.
        /// </summary>
        void Register(TKey key, TValue value);

        /// <summary>
        /// Unregisters the specified key.
        /// </summary>
        bool Unregister(TKey key);

        /// <summary>
        /// Attempts to resolve a value by key.
        /// </summary>
        bool TryGet(TKey key, out TValue? value);

        /// <summary>
        /// Enumerates all registered values.
        /// </summary>
        IEnumerable<TValue> GetAll();
    }
}

namespace Zentient.Core.Builders
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Asynchronous builder abstraction that supports cancellation.
    /// </summary>
    /// <typeparam name="TBuilt">The type produced by the builder. Must be non-nullable.</typeparam>
    public interface IAsyncBuilder<TBuilt> : IBuilder<TBuilt> where TBuilt : notnull
    {
        /// <summary>
        /// Builds the instance asynchronously.
        /// </summary>
        ValueTask<TBuilt> BuildAsync(CancellationToken ct = default);
    }

    /// <summary>
    /// Synchronous builder abstraction.
    /// </summary>
    /// <typeparam name="TBuilt">The type produced by the builder.</typeparam>
    public interface IBuilder<out TBuilt>
    {
        /// <summary>
        /// Builds and returns the configured instance.
        /// </summary>
        TBuilt Build();
    }
}

namespace Zentient.Abstractions.Core.Equality
{
    using Zentient.Core;

    /// <summary>
    /// A typed equality comparer for concepts. Implementers should provide semantic equality consistent
    /// with the conceptual identity model (for example, comparing stable identifiers or value equality).
    /// </summary>
    /// <typeparam name="T">The concept type being compared.</typeparam>
    public interface IConceptEqualityComparer<T> : System.Collections.Generic.IEqualityComparer<T> where T : IConcept { }
}
