// <copyright file="ICodeDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Metadata;
using System;

namespace Zentient.Abstractions.Codes
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="ICode{TCodeType}" /> and related types.
    /// </summary>
    public static class ICodeDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="ICode{TCodeType}"/> into its definition and metadata.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition.</typeparam>
        /// <param name="code">The code instance to deconstruct.</param>
        /// <param name="definition">The code type definition.</param>
        /// <param name="metadata">The metadata associated with the code.</param>
        public static void Deconstruct<TCodeType>(
            this ICode<TCodeType> code,
            out TCodeType definition,
            out IMetadata metadata)
            where TCodeType : ICodeType
        {
            ArgumentNullException.ThrowIfNull(code, nameof(code));
            definition = code.Definition;
            metadata = code.Metadata;
        }

        /// <summary>
        /// Deconstructs an <see cref="ICode{TCodeType}"/> into its definition only.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition.</typeparam>
        /// <param name="code">The code instance to deconstruct.</param>
        /// <param name="definition">The code type definition.</param>
        public static void Deconstruct<TCodeType>(
            this ICode<TCodeType> code,
            out TCodeType definition)
            where TCodeType : ICodeType
        {
            ArgumentNullException.ThrowIfNull(code, nameof(code));
            definition = code.Definition;
        }

        /// <summary>
        /// Deconstructs an <see cref="ICode{TCodeType}"/> into its metadata only.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition.</typeparam>
        /// <param name="code">The code instance to deconstruct.</param>
        /// <param name="metadata">The metadata associated with the code.</param>
        public static void Deconstruct<TCodeType>(
            this ICode<TCodeType> code,
            out IMetadata metadata)
            where TCodeType : ICodeType
        {
            ArgumentNullException.ThrowIfNull(code, nameof(code));
            metadata = code.Metadata;
        }
    }
}
