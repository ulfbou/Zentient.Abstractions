// <copyright file="IEnvelopeDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Envelopes;
using System;
using System.Collections.Generic;

namespace Zentient.Abstractions.Errors
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="IEnvelope{TCodeType, TErrorType}" /> and related types.
    /// </summary>
    public static class IEnvelopeDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="IEnvelope{TCodeType, TErrorType}"/> into its code, errors, and messages.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the envelope.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the envelope.</typeparam>
        /// <param name="envelope">The envelope instance to deconstruct.</param>
        /// <param name="code">The result code associated with the envelope.</param>
        /// <param name="errors">The collection of errors associated with the envelope.</param>
        /// <param name="messages">The collection of informational or diagnostic messages.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IEnvelope<TCodeType, TErrorType> envelope,
            out ICode<TCodeType> code,
            out IReadOnlyCollection<IErrorInfo<TErrorType>> errors,
            out IReadOnlyCollection<string> messages)
            where TCodeType : ICodeType
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(envelope, nameof(envelope));
            code = envelope.Code;
            errors = envelope.Errors;
            messages = envelope.Messages;
        }

        /// <summary>
        /// Deconstructs an <see cref="IEnvelope{TCodeType, TErrorType, TValue}"/> into its code, errors, messages, and value.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the envelope.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the envelope.</typeparam>
        /// <typeparam name="TValue">The type of the payload value.</typeparam>
        /// <param name="envelope">The envelope instance to deconstruct.</param>
        /// <param name="code">The result code associated with the envelope.</param>
        /// <param name="errors">The collection of errors associated with the envelope.</param>
        /// <param name="messages">The collection of informational or diagnostic messages.</param>
        /// <param name="value">The strongly-typed payload value.</param>
        public static void Deconstruct<TCodeType, TErrorType, TValue>(
            this IEnvelope<TCodeType, TErrorType, TValue> envelope,
            out ICode<TCodeType> code,
            out IReadOnlyCollection<IErrorInfo<TErrorType>> errors,
            out IReadOnlyCollection<string> messages,
            out TValue? value)
            where TCodeType : ICodeType
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(envelope, nameof(envelope));
            code = envelope.Code;
            errors = envelope.Errors;
            messages = envelope.Messages;
            value = envelope.Value;
        }

        /// <summary>
        /// Deconstructs an <see cref="IEnvelope{TCodeType, TErrorType}"/> into its code and errors.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the envelope.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the envelope.</typeparam>
        /// <param name="envelope">The envelope instance to deconstruct.</param>
        /// <param name="code">The result code associated with the envelope.</param>
        /// <param name="errors">The collection of errors associated with the envelope.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IEnvelope<TCodeType, TErrorType> envelope,
            out ICode<TCodeType> code,
            out IReadOnlyCollection<IErrorInfo<TErrorType>> errors)
            where TCodeType : ICodeType
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(envelope, nameof(envelope));
            code = envelope.Code;
            errors = envelope.Errors;
        }

        /// <summary>
        /// Deconstructs an <see cref="IEnvelope{TCodeType, TErrorType}"/> into its code and messages.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the envelope.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the envelope.</typeparam>
        /// <param name="envelope">The envelope instance to deconstruct.</param>
        /// <param name="code">The result code associated with the envelope.</param>
        /// <param name="messages">The collection of informational or diagnostic messages.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IEnvelope<TCodeType, TErrorType> envelope,
            out ICode<TCodeType> code,
            out IReadOnlyCollection<string> messages)
            where TCodeType : ICodeType
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(envelope, nameof(envelope));
            code = envelope.Code;
            messages = envelope.Messages;
        }

        /// <summary>
        /// Deconstructs an <see cref="IEnvelope{TCodeType, TErrorType}"/> into its code only.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the envelope.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the envelope.</typeparam>
        /// <param name="envelope">The envelope instance to deconstruct.</param>
        /// <param name="code">The result code associated with the envelope.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IEnvelope<TCodeType, TErrorType> envelope,
            out ICode<TCodeType> code)
            where TCodeType : ICodeType
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(envelope, nameof(envelope));
            code = envelope.Code;
        }

        /// <summary>
        /// Deconstructs an <see cref="IEnvelope{TCodeType, TErrorType, TValue}"/> into its value only.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the envelope.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the envelope.</typeparam>
        /// <typeparam name="TValue">The type of the payload value.</typeparam>
        /// <param name="envelope">The envelope instance to deconstruct.</param>
        /// <param name="value">The strongly-typed payload value.</param>
        public static void Deconstruct<TCodeType, TErrorType, TValue>(
            this IEnvelope<TCodeType, TErrorType, TValue> envelope,
            out TValue? value)
            where TCodeType : ICodeType
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(envelope, nameof(envelope));
            value = envelope.Value;
        }
    }
}
