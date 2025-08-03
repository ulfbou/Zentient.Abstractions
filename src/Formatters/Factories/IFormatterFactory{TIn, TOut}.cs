// <copyright file="IFormatterFactory{TIn, TOut}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Formatters.Definitions;

namespace Zentient.Abstractions.Formatters.Factories
{
    /// <summary>Factory interface for creating formatter instances.</summary>
    public interface IFormatterFactory
    {
        /// <summary>
        /// Creates a formatter instance of the specified formatter type and input/output configuration.
        /// </summary>
        /// <typeparam name="TIn">The input type the formatter accepts.</typeparam>
        /// <typeparam name="TOut">The output type the formatter produces.</typeparam>
        /// <param name="definition">The formatter type metadata.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing the created formatter.
        /// </returns>
        Task<IFormatter<TIn, TOut>> CreateFormatter<TIn, TOut>(
            IFormatterDefinition definition,
            CancellationToken cancellationToken = default);
    }
}
