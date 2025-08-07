// <copyright file="IMetadataPredicate.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Registration;

namespace Zentient.Abstractions.DependencyInjection.Predicates
{
    /// <summary>Represents a structured predicate for filtering service descriptors.</summary>
    /// <remarks>
    /// This abstraction provides a more composable alternative to a raw
    /// <see cref="Func{T, TResult}"/> by encapsulating filtering logic with support for
    /// logical operations and performance optimizations.
    /// </remarks>
    public interface IMetadataPredicate
    {
        /// <summary>
        /// Gets a human-readable description of what this predicate evaluates.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets an estimated performance cost of evaluating this predicate.
        /// Lower values indicate faster evaluation.
        /// </summary>
        int EstimatedCost { get; }

        /// <summary>
        /// Evaluates whether a given service descriptor matches the predicate's criteria.
        /// </summary>
        /// <param name="descriptor">The service descriptor to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the descriptor matches; otherwise, <see langword="false"/>.
        /// </returns>
        bool Match(IServiceDescriptor descriptor);

        /// <summary>
        /// Evaluates whether a given service descriptor matches the predicate's criteria asynchronously.
        /// </summary>
        /// <param name="descriptor">The service descriptor to evaluate.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous evaluation operation, returning
        /// <see langword="true"/> if the descriptor matches; otherwise, <see langword="false"/>.
        /// </returns>
        Task<bool> MatchAsync(IServiceDescriptor descriptor, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a logical AND operation with another predicate.
        /// </summary>
        /// <param name="other">The predicate to combine with this one using AND logic.</param>
        /// <returns>A new predicate that returns true only when both predicates match.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="other"/> is null.</exception>
        IMetadataPredicate And(IMetadataPredicate other);

        /// <summary>
        /// Creates a logical OR operation with another predicate.
        /// </summary>
        /// <param name="other">The predicate to combine with this one using OR logic.</param>
        /// <returns>A new predicate that returns true when either predicate matches.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="other"/> is null.</exception>
        IMetadataPredicate Or(IMetadataPredicate other);

        /// <summary>
        /// Creates a logical NOT operation for this predicate.
        /// </summary>
        /// <returns>A new predicate that returns the opposite result of this predicate.</returns>
        IMetadataPredicate Not();

        /// <summary>
        /// Optimizes the predicate for better performance when evaluated multiple times.
        /// </summary>
        /// <returns>An optimized version of this predicate that may cache results or reorder operations.</returns>
        IMetadataPredicate Optimize();

        /// <summary>
        /// Checks if this predicate can be optimized or combined with another predicate.
        /// </summary>
        /// <param name="other">The predicate to check compatibility with.</param>
        /// <returns>True if the predicates can be efficiently combined; otherwise, false.</returns>
        bool CanOptimizeWith(IMetadataPredicate other);
    }

    /// <summary>
    /// Provides factory methods and common predicates for service descriptor filtering.
    /// </summary>
    public static class MetadataPredicates
    {
        /// <summary>
        /// Creates a predicate that always returns true.
        /// </summary>
        /// <returns>A predicate that matches all service descriptors.</returns>
        public static IMetadataPredicate Always => new AlwaysPredicate();

        /// <summary>
        /// Creates a predicate that always returns false.
        /// </summary>
        /// <returns>A predicate that matches no service descriptors.</returns>
        public static IMetadataPredicate Never => new NeverPredicate();

        /// <summary>
        /// Creates a predicate that matches services with a specific metadata key.
        /// </summary>
        /// <param name="key">The metadata key to check for.</param>
        /// <returns>A predicate that matches services containing the specified metadata key.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
        public static IMetadataPredicate HasMetadataKey(string key)
        {
            throw new NotImplementedException("This method should be implemented by a concrete DI container provider. " +
                "This is part of the Zentient.Abstractions framework and requires an implementation library.");
        }

        /// <summary>
        /// Creates a predicate that matches services with a specific metadata key-value pair.
        /// </summary>
        /// <typeparam name="TValue">The type of the metadata value.</typeparam>
        /// <param name="key">The metadata key to check for.</param>
        /// <param name="value">The expected metadata value.</param>
        /// <returns>A predicate that matches services with the specified metadata key-value pair.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
        public static IMetadataPredicate HasMetadataValue<TValue>(string key, TValue value)
        {
            throw new NotImplementedException("This method should be implemented by a concrete DI container provider. " +
                "This is part of the Zentient.Abstractions framework and requires an implementation library.");
        }

        /// <summary>
        /// Creates a predicate that matches services with a specific service lifetime.
        /// </summary>
        /// <param name="lifetime">The service lifetime to match.</param>
        /// <returns>A predicate that matches services with the specified lifetime.</returns>
        public static IMetadataPredicate HasLifetime(ServiceLifetime lifetime)
        {
            throw new NotImplementedException("This method should be implemented by a concrete DI container provider. " +
                "This is part of the Zentient.Abstractions framework and requires an implementation library.");
        }

        /// <summary>
        /// Creates a predicate that matches services implementing a specific interface or base type.
        /// </summary>
        /// <typeparam name="TContract">The contract type to check for.</typeparam>
        /// <returns>A predicate that matches services implementing the specified contract.</returns>
        public static IMetadataPredicate ImplementsContract<TContract>()
        {
            throw new NotImplementedException("This method should be implemented by a concrete DI container provider. " +
                "This is part of the Zentient.Abstractions framework and requires an implementation library.");
        }

        /// <summary>
        /// Creates a predicate that matches services implementing a specific interface or base type.
        /// </summary>
        /// <param name="contractType">The contract type to check for.</param>
        /// <returns>A predicate that matches services implementing the specified contract.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="contractType"/> is null.</exception>
        public static IMetadataPredicate ImplementsContract(Type contractType)
        {
            throw new NotImplementedException("This method should be implemented by a concrete DI container provider. " +
                "This is part of the Zentient.Abstractions framework and requires an implementation library.");
        }

        /// <summary>
        /// Creates a predicate from a custom function with performance metadata.
        /// </summary>
        /// <param name="predicate">The custom predicate function.</param>
        /// <param name="description">A description of what the predicate evaluates.</param>
        /// <param name="estimatedCost">The estimated performance cost of the predicate.</param>
        /// <returns>A metadata predicate wrapping the custom function.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> or <paramref name="description"/> is null.</exception>
        public static IMetadataPredicate FromFunction(Func<IServiceDescriptor, bool> predicate, string description, int estimatedCost = 1)
        {
            throw new NotImplementedException("This method should be implemented by a concrete DI container provider. " +
                "This is part of the Zentient.Abstractions framework and requires an implementation library.");
        }
    }

    /// <summary>
    /// Internal implementation of a predicate that always returns true.
    /// </summary>
    internal sealed class AlwaysPredicate : IMetadataPredicate
    {
        public string Description => "Always matches";
        public int EstimatedCost => 0;

        public bool Match(IServiceDescriptor descriptor) => true;
        public Task<bool> MatchAsync(IServiceDescriptor descriptor, CancellationToken cancellationToken = default) 
            => Task.FromResult(true);

        public IMetadataPredicate And(IMetadataPredicate other) => other ?? throw new ArgumentNullException(nameof(other));
        public IMetadataPredicate Or(IMetadataPredicate other) => this;
        public IMetadataPredicate Not() => MetadataPredicates.Never;
        public IMetadataPredicate Optimize() => this;
        public bool CanOptimizeWith(IMetadataPredicate other) => true;
    }

    /// <summary>
    /// Internal implementation of a predicate that always returns false.
    /// </summary>
    internal sealed class NeverPredicate : IMetadataPredicate
    {
        public string Description => "Never matches";
        public int EstimatedCost => 0;

        public bool Match(IServiceDescriptor descriptor) => false;
        public Task<bool> MatchAsync(IServiceDescriptor descriptor, CancellationToken cancellationToken = default) 
            => Task.FromResult(false);

        public IMetadataPredicate And(IMetadataPredicate other) => this;
        public IMetadataPredicate Or(IMetadataPredicate other) => other ?? throw new ArgumentNullException(nameof(other));
        public IMetadataPredicate Not() => MetadataPredicates.Always;
        public IMetadataPredicate Optimize() => this;
        public bool CanOptimizeWith(IMetadataPredicate other) => true;
    }
}
