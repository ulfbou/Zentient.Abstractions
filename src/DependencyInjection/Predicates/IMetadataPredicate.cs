// <copyright file="IMetadataPredicate.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection.Predicates
{
    /// <summary>Represents a structured predicate for filtering service descriptors.</summary>
    /// <remarks>
    /// This abstraction provides a more composable alternative to a raw
    /// <see cref="Func{T, TResult}"/> by encapsulating filtering logic.
    /// </remarks>
    public interface IMetadataPredicate
    {
        /// <summary>
        /// Evaluates whether a given service descriptor matches the predicate's criteria.
        /// </summary>
        /// <param name="descriptor">The service descriptor to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the descriptor matches; otherwise, <see langword="false"/>.
        /// </returns>
        bool Match(IServiceDescriptor descriptor);
    }
}
