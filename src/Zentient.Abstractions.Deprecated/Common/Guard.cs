// <copyright file="Guard.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Provides guard clauses for validating method arguments and throwing appropriate exceptions.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified value is <c>null</c>.
        /// </summary>
        /// <param name="value">The value to check for <c>null</c>.</param>
        /// <param name="paramName">The name of the parameter being checked.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
        public static void AgainstNull(object? value, string? paramName = null)
        {
            if (value is null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the specified string is <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string value to check.</param>
        /// <param name="paramName">The name of the parameter being checked.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is <c>null</c> or empty.</exception>
        public static void AgainstNullOrEmpty(string? value, string? paramName = null)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value cannot be null or empty.", paramName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the specified string is <c>null</c>, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string value to check.</param>
        /// <param name="paramName">The name of the parameter being checked.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is <c>null</c>, empty, or whitespace.</exception>
        public static void AgainstNullOrWhitespace(string? value, string? paramName = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null, empty, or whitespace.", paramName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the specified value is outside the inclusive range defined by <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to check. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum allowed value (inclusive).</param>
        /// <param name="max">The maximum allowed value (inclusive).</param>
        /// <param name="paramName">The name of the parameter being checked.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is less than <paramref name="min"/> or greater than <paramref name="max"/>.</exception>
        public static void AgainstOutOfRange<T>(T value, T min, T max, string? paramName = null) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                throw new ArgumentOutOfRangeException(paramName, $"Value must be between {min} and {max}.");
        }
    }
}
