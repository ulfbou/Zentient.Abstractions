// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Formatters
{
    /// <summary>
    /// Transforms a value of type <typeparamref name="TIn"/> into a value of type <typeparamref name="TOut"/>.
    /// </summary>
    public interface IFormatter<in TIn, TOut>
    {
        /// <summary>
        /// Performs the transformation.
        /// </summary>
        Task<TOut> Format(TIn input, CancellationToken cancellationToken = default);
    }
}
