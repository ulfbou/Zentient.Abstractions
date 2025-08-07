// <copyright file="IPredicateFactory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Registration;

namespace Zentient.Abstractions.DependencyInjection.Predicates
{
    /// <summary>
    /// Factory for creating specialized metadata predicates with performance optimizations.
    /// </summary>
    public interface IPredicateFactory
    {
        /// <summary>
        /// Creates a predicate that matches services with specific metadata key.
        /// </summary>
        /// <param name="key">The metadata key to search for.</param>
        /// <returns>A predicate that matches services containing the specified key.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
        IMetadataPredicate HasMetadataKey(string key);

        /// <summary>
        /// Creates a predicate that matches services with specific metadata key-value pair.
        /// </summary>
        /// <typeparam name="TValue">The type of the metadata value.</typeparam>
        /// <param name="key">The metadata key to search for.</param>
        /// <param name="value">The expected metadata value.</param>
        /// <returns>A predicate that matches services with the specified key-value pair.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
        IMetadataPredicate HasMetadataValue<TValue>(string key, TValue value);

        /// <summary>
        /// Creates a predicate that matches services with specific lifetime.
        /// </summary>
        /// <param name="lifetime">The service lifetime to match.</param>
        /// <returns>A predicate that matches services with the specified lifetime.</returns>
        IMetadataPredicate HasLifetime(ServiceLifetime lifetime);

        /// <summary>
        /// Creates a predicate that matches services implementing specific contract.
        /// </summary>
        /// <typeparam name="TContract">The contract type to check for.</typeparam>
        /// <returns>A predicate that matches services implementing the contract.</returns>
        IMetadataPredicate ImplementsContract<TContract>();

        /// <summary>
        /// Creates a predicate that matches services implementing specific contract.
        /// </summary>
        /// <param name="contractType">The contract type to check for.</param>
        /// <returns>A predicate that matches services implementing the contract.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="contractType"/> is null.</exception>
        IMetadataPredicate ImplementsContract(Type contractType);

        /// <summary>
        /// Creates a predicate that matches services where implementation type matches a pattern.
        /// </summary>
        /// <param name="pattern">A function that checks if the implementation type matches criteria.</param>
        /// <param name="description">A description of what the pattern checks.</param>
        /// <returns>A predicate that matches services based on implementation type patterns.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="pattern"/> or <paramref name="description"/> is null.</exception>
        IMetadataPredicate ImplementationMatches(Func<Type, bool> pattern, string description);

        /// <summary>
        /// Creates a predicate that matches decorator services.
        /// </summary>
        /// <returns>A predicate that matches only decorator services.</returns>
        IMetadataPredicate IsDecorator();

        /// <summary>
        /// Creates a predicate that matches interceptor services.
        /// </summary>
        /// <returns>A predicate that matches only interceptor services.</returns>
        IMetadataPredicate IsInterceptor();

        /// <summary>
        /// Creates a predicate that matches services registered conditionally.
        /// </summary>
        /// <returns>A predicate that matches services with conditional registration.</returns>
        IMetadataPredicate HasConditions();

        /// <summary>
        /// Creates a composite predicate that combines multiple predicates with AND logic.
        /// </summary>
        /// <param name="predicates">The predicates to combine.</param>
        /// <returns>A predicate that matches when all provided predicates match.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicates"/> is null.</exception>
        IMetadataPredicate All(params IMetadataPredicate[] predicates);

        /// <summary>
        /// Creates a composite predicate that combines multiple predicates with OR logic.
        /// </summary>
        /// <param name="predicates">The predicates to combine.</param>
        /// <returns>A predicate that matches when any provided predicate matches.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicates"/> is null.</exception>
        IMetadataPredicate Any(params IMetadataPredicate[] predicates);

        /// <summary>
        /// Creates a predicate from a custom function with caching support.
        /// </summary>
        /// <param name="predicate">The custom predicate function.</param>
        /// <param name="description">A description of what the predicate evaluates.</param>
        /// <param name="enableCaching">Whether to enable result caching for performance.</param>
        /// <param name="estimatedCost">The estimated performance cost of the predicate.</param>
        /// <returns>A metadata predicate wrapping the custom function.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> or <paramref name="description"/> is null.</exception>
        IMetadataPredicate FromFunction(
            Func<IServiceDescriptor, bool> predicate, 
            string description, 
            bool enableCaching = false,
            int estimatedCost = 1);

        /// <summary>
        /// Creates an optimized predicate chain that reorders predicates by estimated cost.
        /// </summary>
        /// <param name="predicates">The predicates to optimize.</param>
        /// <returns>An optimized predicate chain for better performance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicates"/> is null.</exception>
        IMetadataPredicate OptimizeChain(IEnumerable<IMetadataPredicate> predicates);
    }

    /// <summary>
    /// Provides extension methods for working with metadata predicates.
    /// </summary>
    public static class MetadataPredicateExtensions
    {
        /// <summary>
        /// Creates a logical AND operation between two predicates.
        /// </summary>
        /// <param name="left">The left predicate.</param>
        /// <param name="right">The right predicate.</param>
        /// <returns>A predicate that returns true only when both predicates match.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either predicate is null.</exception>
        public static IMetadataPredicate And(this IMetadataPredicate left, IMetadataPredicate right)
        {
            ArgumentNullException.ThrowIfNull(left);
            ArgumentNullException.ThrowIfNull(right);
            return left.And(right);
        }

        /// <summary>
        /// Creates a logical OR operation between two predicates.
        /// </summary>
        /// <param name="left">The left predicate.</param>
        /// <param name="right">The right predicate.</param>
        /// <returns>A predicate that returns true when either predicate matches.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either predicate is null.</exception>
        public static IMetadataPredicate Or(this IMetadataPredicate left, IMetadataPredicate right)
        {
            ArgumentNullException.ThrowIfNull(left);
            ArgumentNullException.ThrowIfNull(right);
            return left.Or(right);
        }

        /// <summary>
        /// Applies a series of AND operations to multiple predicates.
        /// </summary>
        /// <param name="predicates">The predicates to combine with AND logic.</param>
        /// <returns>A predicate that matches when all provided predicates match.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicates"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="predicates"/> is empty.</exception>
        public static IMetadataPredicate AndAll(this IEnumerable<IMetadataPredicate> predicates)
        {
            ArgumentNullException.ThrowIfNull(predicates);
            
            var predicateList = predicates.ToList();
            if (predicateList.Count == 0)
            {
                throw new ArgumentException("At least one predicate must be provided.", nameof(predicates));
            }

            return predicateList.Skip(1).Aggregate(predicateList[0], (acc, pred) => acc.And(pred));
        }

        /// <summary>
        /// Applies a series of OR operations to multiple predicates.
        /// </summary>
        /// <param name="predicates">The predicates to combine with OR logic.</param>
        /// <returns>A predicate that matches when any provided predicate matches.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicates"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="predicates"/> is empty.</exception>
        public static IMetadataPredicate OrAll(this IEnumerable<IMetadataPredicate> predicates)
        {
            ArgumentNullException.ThrowIfNull(predicates);
            
            var predicateList = predicates.ToList();
            if (predicateList.Count == 0)
            {
                throw new ArgumentException("At least one predicate must be provided.", nameof(predicates));
            }

            return predicateList.Skip(1).Aggregate(predicateList[0], (acc, pred) => acc.Or(pred));
        }

        /// <summary>
        /// Creates a cached version of the predicate that remembers results for descriptors.
        /// </summary>
        /// <param name="predicate">The predicate to cache.</param>
        /// <param name="maxCacheSize">The maximum number of results to cache.</param>
        /// <returns>A cached version of the predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
        public static IMetadataPredicate WithCaching(this IMetadataPredicate predicate, int maxCacheSize = 1000)
        {
            ArgumentNullException.ThrowIfNull(predicate);
            return new CachedMetadataPredicate(predicate, maxCacheSize);
        }

        /// <summary>
        /// Optimizes the predicate for better performance.
        /// </summary>
        /// <param name="predicate">The predicate to optimize.</param>
        /// <returns>An optimized version of the predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
        public static IMetadataPredicate Optimized(this IMetadataPredicate predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate);
            return predicate.Optimize();
        }
    }

    /// <summary>
    /// Internal implementation of a cached metadata predicate.
    /// </summary>
    internal sealed class CachedMetadataPredicate : IMetadataPredicate
    {
        private readonly IMetadataPredicate _innerPredicate;
        private readonly Dictionary<string, bool> _cache;
        private readonly int _maxCacheSize;

        public CachedMetadataPredicate(IMetadataPredicate innerPredicate, int maxCacheSize)
        {
            _innerPredicate = innerPredicate ?? throw new ArgumentNullException(nameof(innerPredicate));
            _maxCacheSize = maxCacheSize;
            _cache = new Dictionary<string, bool>();
        }

        public string Description => $"Cached({_innerPredicate.Description})";
        public int EstimatedCost => Math.Max(1, _innerPredicate.EstimatedCost / 2);

        public bool Match(IServiceDescriptor descriptor)
        {
            ArgumentNullException.ThrowIfNull(descriptor);
            
            var key = descriptor.Id;
            if (_cache.TryGetValue(key, out var cachedResult))
            {
                return cachedResult;
            }

            var result = _innerPredicate.Match(descriptor);
            
            if (_cache.Count < _maxCacheSize)
            {
                _cache[key] = result;
            }

            return result;
        }

        public async Task<bool> MatchAsync(IServiceDescriptor descriptor, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(descriptor);
            
            var key = descriptor.Id;
            if (_cache.TryGetValue(key, out var cachedResult))
            {
                return cachedResult;
            }

            var result = await _innerPredicate.MatchAsync(descriptor, cancellationToken).ConfigureAwait(false);
            
            if (_cache.Count < _maxCacheSize)
            {
                _cache[key] = result;
            }

            return result;
        }

        public IMetadataPredicate And(IMetadataPredicate other) => _innerPredicate.And(other);
        public IMetadataPredicate Or(IMetadataPredicate other) => _innerPredicate.Or(other);
        public IMetadataPredicate Not() => _innerPredicate.Not();
        public IMetadataPredicate Optimize() => this;
        public bool CanOptimizeWith(IMetadataPredicate other) => _innerPredicate.CanOptimizeWith(other);
    }
}
