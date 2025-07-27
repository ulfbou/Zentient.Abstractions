// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Policies
{
    /// <summary>
    /// Represents a policy that can be applied to an operation producing a result of type <typeparamref name="T"/>.
    /// Supports combinators for building policy pipelines.
    /// </summary>
    public interface IPolicy<T>
    {
        /// <summary>
        /// Executes the given delegate under the policy’s behavior.
        /// </summary>
        Task<T> Execute(Func<CancellationToken, Task<T>> operation, CancellationToken cancellationToken = default);

        /// <summary>
        /// Combines this policy with another policy, forming a sequential pipeline.
        /// The inner policy (<paramref name="innerPolicy"/>) is executed first,
        /// and its outcome is then subjected to this policy.
        /// </summary>
        /// <param name="innerPolicy">The policy to execute before this policy.</param>
        /// <returns>A new <see cref="IPolicy{T}"/> that represents the combined policies.</returns>
        IPolicy<T> CombineWith(IPolicy<T> innerPolicy);

        /// <summary>
        /// Combines this policy with another policy, where the secondary policy acts as a fallback.
        /// If this policy fails (e.g., throws an exception not handled by this policy),
        /// the fallback policy will be attempted.
        /// </summary>
        /// <param name="fallbackPolicy">The policy to execute as a fallback if this policy encounters an unhandled failure.</param>
        /// <returns>A new <see cref="IPolicy{T}"/> that represents this policy with a fallback.</returns>
        IPolicy<T> Fallback(IPolicy<T> fallbackPolicy);
    }
}
