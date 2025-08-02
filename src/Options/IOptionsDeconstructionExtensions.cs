// <copyright file="IOptionsDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Options
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="IOptions{TOptionsType, TValue}" /> and related types.
    /// </summary>
    public static class IOptionsDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="IOptions{TOptionsType, TValue}"/> into its definition and value.
        /// </summary>
        /// <typeparam name="TOptionsType">The specific type of the options definition.</typeparam>
        /// <typeparam name="TValue">The type of the options value.</typeparam>
        /// <param name="options">The options instance to deconstruct.</param>
        /// <param name="definition">The options type definition.</param>
        /// <param name="value">The value of the options.</param>
        public static void Deconstruct<TOptionsType, TValue>(
            this IOptions<TOptionsType, TValue> options,
            out TOptionsType definition,
            out TValue value)
            where TOptionsType : IOptionsType
        {
            ArgumentNullException.ThrowIfNull(options, nameof(options));
            definition = options.Definition;
            value = options.Value;
        }

        /// <summary>
        /// Deconstructs an <see cref="IOptions{TOptionsType, TValue}"/> into its definition only.
        /// </summary>
        /// <typeparam name="TOptionsType">The specific type of the options definition.</typeparam>
        /// <typeparam name="TValue">The type of the options value.</typeparam>
        /// <param name="options">The options instance to deconstruct.</param>
        /// <param name="definition">The options type definition.</param>
        public static void Deconstruct<TOptionsType, TValue>(
            this IOptions<TOptionsType, TValue> options,
            out TOptionsType definition)
            where TOptionsType : IOptionsType
        {
            ArgumentNullException.ThrowIfNull(options, nameof(options));
            definition = options.Definition;
        }

        /// <summary>
        /// Deconstructs an <see cref="IOptions{TOptionsType, TValue}"/> into its value only.
        /// </summary>
        /// <typeparam name="TOptionsType">The specific type of the options definition.</typeparam>
        /// <typeparam name="TValue">The type of the options value.</typeparam>
        /// <param name="options">The options instance to deconstruct.</param>
        /// <param name="value">The value of the options.</param>
        public static void Deconstruct<TOptionsType, TValue>(
            this IOptions<TOptionsType, TValue> options,
            out TValue value)
            where TOptionsType : IOptionsType
        {
            ArgumentNullException.ThrowIfNull(options, nameof(options));
            value = options.Value;
        }
    }
}
