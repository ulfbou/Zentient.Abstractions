// <copyright file="ICodeDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Metadata;
using System;
using Zentient.Abstractions.Codes.Definitions;

namespace Zentient.Abstractions.Codes
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="ICode{TCodeDefinition}" /> and related types.
    /// </summary>
    public static class ICodeDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="ICode{TCodeDefinition}"/> into its definition and metadata.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition.</typeparam>
        /// <param name="code">The code instance to deconstruct.</param>
        /// <param name="definition">The code type definition.</param>
        /// <param name="metadata">The metadata associated with the code.</param>
        public static void Deconstruct<TCodeDefinition>(
            this ICode<TCodeDefinition> code,
            out TCodeDefinition definition,
            out IMetadata metadata)
            where TCodeDefinition : ICodeDefinition
        {
            ArgumentNullException.ThrowIfNull(code, nameof(code));
            definition = code.Definition;
            metadata = code.Metadata;
        }

        /// <summary>
        /// Deconstructs an <see cref="ICode{TCodeDefinition}"/> into its definition only.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition.</typeparam>
        /// <param name="code">The code instance to deconstruct.</param>
        /// <param name="definition">The code type definition.</param>
        public static void Deconstruct<TCodeDefinition>(
            this ICode<TCodeDefinition> code,
            out TCodeDefinition definition)
            where TCodeDefinition : ICodeDefinition
        {
            ArgumentNullException.ThrowIfNull(code, nameof(code));
            definition = code.Definition;
        }

        /// <summary>
        /// Deconstructs an <see cref="ICode{TCodeDefinition}"/> into its metadata only.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition.</typeparam>
        /// <param name="code">The code instance to deconstruct.</param>
        /// <param name="metadata">The metadata associated with the code.</param>
        public static void Deconstruct<TCodeDefinition>(
            this ICode<TCodeDefinition> code,
            out IMetadata metadata)
            where TCodeDefinition : ICodeDefinition
        {
            ArgumentNullException.ThrowIfNull(code, nameof(code));
            metadata = code.Metadata;
        }
    }
}
