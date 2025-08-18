// <copyright file="IMetadataReader.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace Zentient.Abstractions.Metadata.Readers
{
    /// <summary>
    /// Represents a read-only interface for accessing metadata key-value pairs.
    /// This interface is designed for querying metadata without allowing modification.
    /// </summary>
    /// <remarks>
    /// Implementations of this interface are expected to be <see langword="immutable"/> and
    /// <see langword="thread-safe"/>, making them suitable for sharing across concurrent operations
    /// and read-only contexts.
    /// </remarks>
    public interface IMetadataReader
    {
        /// <summary>Gets the number of metadata tags contained in this instance.</summary>
        int Count { get; }

        /// <summary>
        /// Gets an enumerable collection of all keys contained in this metadata instance.
        /// </summary>
        IEnumerable<string> Keys { get; }

        /// <summary>
        /// Gets an enumerable collection of all values contained in this metadata instance.
        /// </summary>
        IEnumerable<object?> Values { get; }

        /// <summary>
        /// Gets an enumerable collection of all key-value pairs (tags) contained in this metadata
        /// instance.
        /// </summary>
        IEnumerable<KeyValuePair<string, object?>> Tags { get; }

        /// <summary>
        /// Determines whether this metadata instance contains a tag with the specified key.
        /// </summary>
        /// <param name="key">
        /// The key to locate. Cannot be <see langword="null"/> or whitespace.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if a tag with the key exists;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="key"/> is empty or whitespace.
        /// </exception>
        bool ContainsKey(string key);

        /// <summary>Attempts to retrieve the value associated with the specified key.</summary>
        /// <param name="key">
        /// The key of the value to get. Cannot be <see langword="null"/> or whitespace.
        /// </param>
        /// <param name="value">
        /// When this method returns, contains the value associated with the specified key,
        /// if the key is found; otherwise, the default value for the type of the value parameter.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the value associated with the specified key was retrieved
        /// successfully; otherwise, <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// If a tag exists with a <see langword="null"/> value, this method will return
        /// <see langword="true"/>, and <paramref name="value"/> will be <see langword="null"/>.
        /// It is crucial to differentiate between a key not existing and a key existing with a
        /// <see langword="null"/> value.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="key"/> is empty or whitespace.
        /// </exception>
#if NETSTANDARD2_0
        bool TryGetValue(string key, [NotNullWhen(true)] out object? value);
#else
        bool TryGetValue(string key, [MaybeNullWhen(false)] out object? value);
#endif

        /// <summary>
        /// Attempts to retrieve the value associated with the specified key, casting it to the
        /// specified type.
        /// </summary>
        /// <typeparam name="TValue">The type to which the value should be cast.</typeparam>
        /// <param name="key">
        /// The key of the value to get. Cannot be <see langword="null"/> or whitespace.
        /// </param>
        /// <param name="value">
        /// When this method returns, contains the value associated with the specified key,
        /// cast to <typeparamref name="TValue"/>, if the key is found and the value is compatible;
        /// otherwise, the default value for <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the value associated with the specified key was retrieved and
        /// is compatible with <typeparamref name="TValue"/>; otherwise, <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// If a tag exists with a <see langword="null"/> value, this method will return
        /// <see langword="true"/>, and <paramref name="value"/> will be <see langword="null"/>
        /// (for reference types or <see langword="null"/>able value types).
        /// This method returns <see langword="false"/> if the key does not exist or if the value
        /// cannot be cast to <typeparamref name="TValue"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="key"/> is empty or whitespace.
        /// </exception>
#if NETSTANDARD2_0
        bool TryGetValue<TValue>(string key, [NotNullWhen(true)] out TValue value)
            where TValue : class;
#else
        bool TryGetValue<TValue>(string key, [MaybeNullWhen(false)] out TValue value);
#endif

        /// <summary>
        /// Gets the value associated with the specified key, or a default value if the key is
        /// not found.
        /// </summary>
        /// <param name="key">
        /// The key of the value to get. Cannot be <see langword="null"/> or whitespace.
        /// </param>
        /// <param name="defaultValue">
        /// The value to return if the key is not found. Can be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// The value associated with the specified key, or <paramref name="defaultValue"/> if the
        /// key is not found.
        /// </returns>
        /// <remarks>
        /// If a tag exists with a <see langword="null"/> value, this method will return
        /// <see langword="null"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="key"/> is empty or whitespace.
        /// </exception>
        object? GetValueOrDefault(string key, object? defaultValue = default);

        /// <summary>
        /// Gets the value associated with the specified key, cast to the specified type, or a
        /// default value if the key is not found or the value is not compatible.
        /// </summary>
        /// <typeparam name="TValue">The type to which the value should be cast.</typeparam>
        /// <param name="key">
        /// The key of the value to get. Cannot be <see langword="null"/> or whitespace.
        /// </param>
        /// <param name="defaultValue">
        /// The value to return if the key is not found or the value cannot be cast to
        /// <typeparamref name="TValue"/>. Can be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// The value associated with the specified key, cast to <typeparamref name="TValue"/>, or
        /// <paramref name="defaultValue"/> if the key is not found or the value is not compatible.
        /// </returns>
        /// <remarks>
        /// If a tag exists with a <see langword="null"/> value, this method will return
        /// <see langword="null"/> (for reference types or <see langword="null"/>able value types),
        /// provided the value's type is compatible with <typeparamref name="TValue"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="key"/> is empty or whitespace.
        /// </exception>
        TValue GetValueOrDefault<TValue>(string key, TValue defaultValue = default!);
    }
}
