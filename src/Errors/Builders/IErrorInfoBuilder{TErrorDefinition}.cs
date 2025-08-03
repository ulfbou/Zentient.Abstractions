// <copyright file="IErrorInfoBuilder{TErrorDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Errors.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Errors.Builders
{
    /// <summary>
    /// Provides a fluent API for building immutable <see cref="IErrorInfo{TErrorDefinition}"/> instances.
    /// </summary>
    /// <typeparam name="TErrorDefinition">The specific <see cref="IErrorDefinition"/> this builder is for.</typeparam>
    /// <remarks>
    /// This builder facilitates the structured creation of detailed error information,
    /// including its definition, message, unique instance ID, nested errors, and associated metadata.
    /// </remarks>
    public interface IErrorInfoBuilder<TErrorDefinition>
        where TErrorDefinition : IErrorDefinition
    {
        /// <summary>
        /// Sets the specific <typeparamref name="TErrorDefinition"/> definition for the error.
        /// </summary>
        /// <param name="errorDefinition">The error type definition. Must not be null.</param>
        /// <returns>The current builder instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="errorDefinition"/> is <see langword="null"/>.</exception>
        IErrorInfoBuilder<TErrorDefinition> WithErrorDefinition(TErrorDefinition errorDefinition);

        /// <summary>
        /// Sets the specific message detailing this particular occurrence of the error.
        /// </summary>
        /// <param name="message">The error message. Must not be null or empty.</param>
        /// <returns>The current builder instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="message"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="message"/> is empty or whitespace.</exception>
        IErrorInfoBuilder<TErrorDefinition> WithMessage(string message);

        /// <summary>
        /// Sets a specific unique identifier for this error instance.
        /// If not set, the builder should generate a new one (e.g., GUID).
        /// </summary>
        /// <param name="instanceId">The unique instance ID. Must not be null or empty.</param>
        /// <returns>The current builder instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="instanceId"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="instanceId"/> is empty or whitespace.</exception>
        IErrorInfoBuilder<TErrorDefinition> WithInstanceId(string instanceId);

        /// <summary>
        /// Adds an inner error to the collection of nested errors.
        /// </summary>
        /// <param name="innerError">The inner error to add. Must not be null.</param>
        /// <returns>The current builder instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="innerError"/> is <see langword="null"/>.</exception>
        IErrorInfoBuilder<TErrorDefinition> WithInnerError(IErrorInfo<TErrorDefinition> innerError);

        /// <summary>
        /// Sets the collection of inner errors, replacing any existing inner errors.
        /// </summary>
        /// <param name="innerErrors">The collection of inner errors. Can be null or empty.</param>
        /// <returns>The current builder instance.</returns>
        IErrorInfoBuilder<TErrorDefinition> WithInnerErrors(IEnumerable<IErrorInfo<TErrorDefinition>>? innerErrors);

        /// <summary>
        /// Adds or updates a metadata entry for the error info.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The current builder instance.</returns>
        IErrorInfoBuilder<TErrorDefinition> WithMetadata(string key, object? value);

        /// <summary>
        /// Sets the entire metadata collection for the error info. Existing metadata will be replaced.
        /// </summary>
        /// <param name="metadata">The metadata collection. Can be null.</param>
        /// <returns>The current builder instance.</returns>
        IErrorInfoBuilder<TErrorDefinition> WithMetadata(IMetadata? metadata);

        /// <summary>
        /// Builds an immutable <see cref="IErrorInfo{TErrorDefinition}"/> instance.
        /// </summary>
        /// <returns>A new <see cref="IErrorInfo{TErrorDefinition}"/> instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the required properties (e.g., ErrorDefinition, Message) are not set before building.</exception>
        IErrorInfo<TErrorDefinition> Build();
    }
}
