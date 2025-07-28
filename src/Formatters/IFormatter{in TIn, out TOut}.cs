// <copyright file="IFormatter{in TIn, out TOut}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Formatters
{
    /// <summary>
    /// Defines a data transformation from type <typeparamref name="TIn"/> to <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">The type of input value to be formatted.</typeparam>
    /// <typeparam name="TOut">The type of output value after formatting.</typeparam>
    public interface IFormatter<TIn, TOut>
    {
        /// <summary>
        /// Gets the formatter's type metadata, including identity, name, and semantic info.
        /// </summary>
        IFormatterType Type { get; }

        /// <summary>Transforms the input value asynchronously.</summary>
        /// <param name="input">The input value.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <returns>A task representing the transformed output value.</returns>
        Task<TOut> Format(TIn input, CancellationToken cancellationToken = default);
    }
}
