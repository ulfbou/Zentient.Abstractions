// <copyright file="IOptionsDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options.Definitions;

namespace Zentient.Abstractions.Options
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="IOptions{TOptionsDefinition, TValue}" /> and related types.
    /// </summary>
    public static class IOptionsDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="IOptions{TOptionsDefinition, TValue}"/> into its definition and value.
        /// </summary>
        /// <typeparam name="TOptionsDefinition">The specific type of the options definition.</typeparam>
        /// <typeparam name="TValue">The type of the options value.</typeparam>
        /// <param name="options">The options instance to deconstruct.</param>
        /// <param name="definition">The options type definition.</param>
        /// <param name="value">The value of the options.</param>
        public static void Deconstruct<TOptionsDefinition, TValue>(
            this IOptions<TOptionsDefinition, TValue> options,
            out TOptionsDefinition definition,
            out TValue value)
            where TOptionsDefinition : IOptionsDefinition
        {
            Guard.AgainstNull(options, nameof(options));
            definition = options.Definition;
            value = options.Value;
        }

        /// <summary>
        /// Deconstructs an <see cref="IOptions{TOptionsDefinition, TValue}"/> into its definition only.
        /// </summary>
        /// <typeparam name="TOptionsDefinition">The specific type of the options definition.</typeparam>
        /// <typeparam name="TValue">The type of the options value.</typeparam>
        /// <param name="options">The options instance to deconstruct.</param>
        /// <param name="definition">The options type definition.</param>
        public static void Deconstruct<TOptionsDefinition, TValue>(
            this IOptions<TOptionsDefinition, TValue> options,
            out TOptionsDefinition definition)
            where TOptionsDefinition : IOptionsDefinition
        {
            Guard.AgainstNull(options, nameof(options));
            definition = options.Definition;
        }

        /// <summary>
        /// Deconstructs an <see cref="IOptions{TOptionsDefinition, TValue}"/> into its value only.
        /// </summary>
        /// <typeparam name="TOptionsDefinition">The specific type of the options definition.</typeparam>
        /// <typeparam name="TValue">The type of the options value.</typeparam>
        /// <param name="options">The options instance to deconstruct.</param>
        /// <param name="value">The value of the options.</param>
        public static void Deconstruct<TOptionsDefinition, TValue>(
            this IOptions<TOptionsDefinition, TValue> options,
            out TValue value)
            where TOptionsDefinition : IOptionsDefinition
        {
            Guard.AgainstNull(options, nameof(options));
            value = options.Value;
        }
    }
}
