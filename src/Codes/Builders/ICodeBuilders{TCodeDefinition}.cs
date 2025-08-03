// <copyright file="ICodeBuilder{TCodeDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Codes.Builders
{
    /// <summary>
    /// Provides a fluent API for building immutable <see cref="ICode{TCodeDefinition}"/> instances.
    /// </summary>
    /// <typeparam name="TCodeDefinition">The specific <see cref="ICodeDefinition"/> this builder is for.</typeparam>
    public interface ICodeBuilder<TCodeDefinition>
        where TCodeDefinition : ICodeDefinition
    {
        /// <summary>
        /// Sets the specific <typeparamref name="TCodeDefinition"/> definition for the code.
        /// </summary>
        /// <param name="definition">The code type definition.</param>
        /// <returns>The current builder instance.</returns>
        ICodeBuilder<TCodeDefinition> WithDefinition(TCodeDefinition definition);

        /// <summary>
        /// Adds or updates a metadata entry for the code.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The current builder instance.</returns>
        ICodeBuilder<TCodeDefinition> WithMetadata(string key, object? value);

        /// <summary>
        /// Sets the entire metadata collection for the code. Existing metadata will be replaced.
        /// </summary>
        /// <param name="metadata">The metadata collection.</param>
        /// <returns>The current builder instance.</returns>
        ICodeBuilder<TCodeDefinition> WithMetadata(IMetadata metadata);

        /// <summary>
        /// Builds an immutable <see cref="ICode{TCodeDefinition}"/> instance.
        /// </summary>
        /// <returns>A new <see cref="ICode{TCodeDefinition}"/> instance.</returns>
        ICode<TCodeDefinition> Build();
    }
}
