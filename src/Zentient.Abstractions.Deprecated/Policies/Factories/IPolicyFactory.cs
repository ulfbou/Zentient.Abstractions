// <copyright file="IPolicyFactory.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;
using Zentient.Abstractions.Policies.Definitions;

namespace Zentient.Abstractions.Policies.Factories
{
    /// <summary>
    /// Factory for creating common policy instances and combinators for operation execution.
    /// </summary>
    public interface IPolicyFactory
    {
        /// <summary>Creates a policy instance of the specified type using the provided options.</summary>
        /// <typeparam name="TPolicyDefinition">The type of policy to create.</typeparam>
        /// <typeparam name="TPolicyOptionsDefinition">The options type for the policy.</typeparam>
        /// <typeparam name="TValue">The value type associated with the policy options.</typeparam>
        /// <param name="options">The options or configuration for the policy.</param>
        /// <returns>A new policy instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="options"/> is null.</exception>
        IPolicy<TPolicyDefinition> CreatePolicy<TPolicyDefinition, TPolicyOptionsDefinition, TValue>(IOptions<TPolicyOptionsDefinition, TValue> options)
            where TPolicyDefinition : IPolicyDefinition
            where TPolicyOptionsDefinition : IPolicyOptionsDefinition;

        /// <summary>
        /// Creates a retry policy that retries the operation up to the specified number of times on failure.
        /// </summary>
        /// <typeparam name="TPolicyDefinition">The result type of the operation.</typeparam>
        /// <param name="retryCount">The maximum number of retry attempts. Defaults to 3.</param>
        /// <returns>An <see cref="IPolicy{T}"/> representing the retry policy.</returns>
        IPolicy<TPolicyDefinition> CreateRetryPolicy<TPolicyDefinition>(int retryCount = 3)
            where TPolicyDefinition : IPolicyDefinition;

        /// <summary>
        /// Creates a circuit breaker policy that opens the circuit after a specified number of failures and breaks for a given duration.
        /// </summary>
        /// <typeparam name="TPolicyDefinition">The result type of the operation.</typeparam>
        /// <param name="failureThreshold">The number of failures before opening the circuit. Defaults to 5.</param>
        /// <param name="breakDuration">The duration to keep the circuit open before resetting. Defaults to <see cref="TimeSpan.Zero"/>.</param>
        /// <returns>An <see cref="IPolicy{T}"/> representing the circuit breaker policy.</returns>
        IPolicy<TPolicyDefinition> CreateCircuitBreakerPolicy<TPolicyDefinition>(int failureThreshold = 5, TimeSpan breakDuration = default)
            where TPolicyDefinition : IPolicyDefinition;

        /// <summary>
        /// Creates a fallback policy that executes the specified fallback operation if the primary operation fails.
        /// </summary>
        /// <typeparam name="TPolicyDefinition">The result type of the operation.</typeparam>
        /// <param name="fallbackOperation">A delegate representing the fallback operation to execute on failure.</param>
        /// <returns>An <see cref="IPolicy{T}"/> representing the fallback policy.</returns>
        IPolicy<TPolicyDefinition> CreateFallbackPolicy<TPolicyDefinition>(Func<CancellationToken, Task<TPolicyDefinition>> fallbackOperation)
            where TPolicyDefinition : IPolicyDefinition;
    }
}
