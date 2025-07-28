// <copyright file="IErrorInfoBuilder{TErrorType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Errors.Builders
{
    /// <summary>
    /// Provides a fluent API for building immutable <see cref="IErrorInfo{TErrorType}"/> instances.
    /// </summary>
    /// <typeparam name="TErrorType">The specific <see cref="IErrorType"/> this builder is for.</typeparam>
    /// <remarks>
    /// This builder facilitates the structured creation of detailed error information,
    /// including its definition, message, unique instance ID, nested errors, and associated metadata.
    /// </remarks>
    public interface IErrorInfoBuilder<TErrorType>
        where TErrorType : IErrorType
    {
        /// <summary>
        /// Sets the specific <typeparamref name="TErrorType"/> definition for the error.
        /// </summary>
        /// <param name="errorDefinition">The error type definition. Must not be null.</param>
        /// <returns>The current builder instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="errorDefinition"/> is <see langword="null"/>.</exception>
        IErrorInfoBuilder<TErrorType> WithErrorDefinition(TErrorType errorDefinition);

        /// <summary>
        /// Sets the specific message detailing this particular occurrence of the error.
        /// </summary>
        /// <param name="message">The error message. Must not be null or empty.</param>
        /// <returns>The current builder instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="message"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="message"/> is empty or whitespace.</exception>
        IErrorInfoBuilder<TErrorType> WithMessage(string message);

        /// <summary>
        /// Sets a specific unique identifier for this error instance.
        /// If not set, the builder should generate a new one (e.g., GUID).
        /// </summary>
        /// <param name="instanceId">The unique instance ID. Must not be null or empty.</param>
        /// <returns>The current builder instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="instanceId"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="instanceId"/> is empty or whitespace.</exception>
        IErrorInfoBuilder<TErrorType> WithInstanceId(string instanceId);

        /// <summary>
        /// Adds an inner error to the collection of nested errors.
        /// </summary>
        /// <param name="innerError">The inner error to add. Must not be null.</param>
        /// <returns>The current builder instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="innerError"/> is <see langword="null"/>.</exception>
        IErrorInfoBuilder<TErrorType> WithInnerError(IErrorInfo<TErrorType> innerError);

        /// <summary>
        /// Sets the collection of inner errors, replacing any existing inner errors.
        /// </summary>
        /// <param name="innerErrors">The collection of inner errors. Can be null or empty.</param>
        /// <returns>The current builder instance.</returns>
        IErrorInfoBuilder<TErrorType> WithInnerErrors(IEnumerable<IErrorInfo<TErrorType>>? innerErrors);

        /// <summary>
        /// Adds or updates a metadata entry for the error info.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The current builder instance.</returns>
        IErrorInfoBuilder<TErrorType> WithMetadata(string key, object? value);

        /// <summary>
        /// Sets the entire metadata collection for the error info. Existing metadata will be replaced.
        /// </summary>
        /// <param name="metadata">The metadata collection. Can be null.</param>
        /// <returns>The current builder instance.</returns>
        IErrorInfoBuilder<TErrorType> WithMetadata(IMetadata? metadata);

        /// <summary>
        /// Builds an immutable <see cref="IErrorInfo{TErrorType}"/> instance.
        /// </summary>
        /// <returns>A new <see cref="IErrorInfo{TErrorType}"/> instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the required properties (e.g., ErrorDefinition, Message) are not set before building.</exception>
        IErrorInfo<TErrorType> Build();
    }
}
