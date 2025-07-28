// <copyright file="IMetadataReader.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace Zentient.Abstractions.Metadata
{
    /// <summary>
    /// Provides read-only access to a collection of key-value metadata, designed for explicit and robust data retrieval.
    /// </summary>
    /// <remarks>
    /// This interface adheres strictly to the principle of throwing exceptions only for invalid caller parameters.
    /// It avoids inheriting from broader collection interfaces to precisely control exposed functionality.
    /// Consumers are encouraged to use <see cref="TryGetValue{TValue}(string, out TValue)"/> or
    /// <see cref="GetValueOrDefault{TValue}(string, TValue)"/> for safe data access.
    /// </remarks>
    public interface IMetadataReader : IEnumerable<KeyValuePair<string, object?>>
    {
        /// <summary>Gets the number of metadata entries contained in this instance.</summary>
        /// <value>The number of metadata entries.</value>
        int Count { get; }

        /// <summary>Gets a read-only collection containing the keys of the metadata entries.</summary>
        /// <value>A read-only collection of keys.</value>
        IReadOnlyCollection<string> Keys { get; }

        /// <summary>Gets a read-only collection containing the values of the metadata entries.</summary>
        /// <value>A read-only collection of values.</value>
        IReadOnlyCollection<object?> Values { get; }

        /// <summary>
        /// Determines whether the <see cref="IMetadataReader"/> contains a metadata entry with the specified key.
        /// </summary>
        /// <param name="key">The key to locate. Must not be null.</param>
        /// <returns><see langword="true"/> if the <see cref="IMetadataReader"/> contains a metadata entry with the key; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is <see langword="null"/>.</exception>
        bool ContainsKey(string key);

        /// <summary>
        /// Attempts to retrieve a metadata value for the specified key and casts it to the specified type.
        /// </summary>
        /// <typeparam name="TValue">The expected type of the metadata value.</typeparam>
        /// <param name="key">The key of the metadata entry. Must not be null.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key,
        /// if the key is found and the value is compatible with <typeparamref name="TValue"/>;
        /// otherwise, the default value for <typeparamref name="TValue"/>.</param>
        /// <returns><see langword="true"/> if the metadata key exists and the value is compatible with <typeparamref name="TValue"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is <see langword="null"/>.</exception>
        bool TryGetValue<TValue>(string key, [MaybeNullWhen(false)] out TValue value);

        /// <summary>
        /// Gets the metadata value associated with the specified key, cast to the specified type,
        /// or a default value if the key does not exist or the value cannot be cast.
        /// </summary>
        /// <typeparam name="TValue">The expected type of the metadata value.</typeparam>
        /// <param name="key">The key of the metadata entry. Must not be null.</param>
        /// <param name="defaultValue">The value to return if the key is not found or the cast fails.</param>
        /// <returns>The metadata value if found and castable; otherwise, <paramref name="defaultValue"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is <see langword="null"/>.</exception>
        TValue GetValueOrDefault<TValue>(string key, TValue defaultValue = default(TValue)!);
    }
}
