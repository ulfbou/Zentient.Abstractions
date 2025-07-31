// <copyright file="IErrorInfoDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using System;
using System.Collections.Generic;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Errors
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="IErrorInfo{TErrorType}" /> and related types.
    /// </summary>
    public static class IErrorInfoDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs the error information into all its properties: error definition, code, message, instance identifier, inner errors, and metadata.
        /// </summary>
        /// <typeparam name="TErrorType">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="ErrorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="Code">The symbolic code describing the semantic meaning of this error.</param>
        /// <param name="Message">A human-readable message providing context for this error instance.</param>
        /// <param name="InstanceId">A unique identifier for this specific error occurrence.</param>
        /// <param name="InnerErrors">A collection of inner errors, if this error is a composite.</param>
        /// <param name="Metadata">The metadata associated with this error instance.</param>
        public static void Deconstruct<TErrorType>(
            this IErrorInfo<TErrorType> errorInfo,
            out TErrorType ErrorDefinition,
            out ICode<ICodeType> Code,
            out string Message,
            out string InstanceId,
            out IReadOnlyCollection<IErrorInfo<TErrorType>> InnerErrors,
            out IMetadata Metadata)
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(errorInfo, nameof(errorInfo));
            ErrorDefinition = errorInfo.ErrorDefinition;
            Code = errorInfo.Code;
            Message = errorInfo.Message;
            InstanceId = errorInfo.InstanceId;
            InnerErrors = errorInfo.InnerErrors;
            Metadata = errorInfo.Metadata;
        }

        /// <summary>
        /// Deconstructs the error information into its error definition, code, message, instance identifier, and inner errors.
        /// </summary>
        /// <typeparam name="TErrorType">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="ErrorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="Code">The symbolic code describing the semantic meaning of this error.</param>
        /// <param name="Message">A human-readable message providing context for this error instance.</param>
        /// <param name="InstanceId">A unique identifier for this specific error occurrence.</param>
        /// <param name="InnerErrors">A collection of inner errors, if this error is a composite.</param>
        public static void Deconstruct<TErrorType>(
            this IErrorInfo<TErrorType> errorInfo,
            out TErrorType ErrorDefinition,
            out ICode<ICodeType> Code,
            out string Message,
            out string InstanceId,
            out IReadOnlyCollection<IErrorInfo<TErrorType>> InnerErrors)
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(errorInfo, nameof(errorInfo));
            ErrorDefinition = errorInfo.ErrorDefinition;
            Code = errorInfo.Code;
            Message = errorInfo.Message;
            InstanceId = errorInfo.InstanceId;
            InnerErrors = errorInfo.InnerErrors;
        }

        /// <summary>
        /// Deconstructs the error information into its error definition, code, and message components.
        /// </summary>
        /// <typeparam name="TErrorType">The specific type of the error definition for the error info.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="errorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="code">The symbolic code describing the semantic meaning of this error.</param>
        /// <param name="message">A human-readable message providing context for this error instance.</param>
        public static void Deconstruct<TErrorType>(
            this IErrorInfo<TErrorType> errorInfo,
            out IErrorType errorDefinition,
            out ICode<ICodeType> code,
            out string message)
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(errorInfo, nameof(errorInfo));
            errorDefinition = errorInfo.ErrorDefinition;
            code = errorInfo.Code;
            message = errorInfo.Message;
        }

        /// <summary>
        /// Deconstructs the error information into its error definition, message, and code (basic subset).
        /// </summary>
        /// <typeparam name="TErrorType">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="errorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="message">A human-readable message providing context for this error instance.</param>
        /// <param name="code">The symbolic code describing the semantic meaning of this error.</param>
        public static void Deconstruct<TErrorType>(
            this IErrorInfo<TErrorType> errorInfo,
            out TErrorType errorDefinition,
            out string message,
            out ICode<ICodeType> code)
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(errorInfo, nameof(errorInfo));
            errorDefinition = errorInfo.ErrorDefinition;
            message = errorInfo.Message;
            code = errorInfo.Code;
        }

        /// <summary>
        /// Deconstructs the error information into its error definition, message, code, and instance ID (debugging/logging subset).
        /// </summary>
        /// <typeparam name="TErrorType">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="errorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="message">A human-readable message providing context for this error instance.</param>
        /// <param name="code">The symbolic code describing the semantic meaning of this error.</param>
        /// <param name="instanceId">A unique identifier for this specific error occurrence.</param>
        public static void Deconstruct<TErrorType>(
            this IErrorInfo<TErrorType> errorInfo,
            out TErrorType errorDefinition,
            out string message,
            out ICode<ICodeType> code,
            out string instanceId)
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(errorInfo, nameof(errorInfo));
            errorDefinition = errorInfo.ErrorDefinition;
            message = errorInfo.Message;
            code = errorInfo.Code;
            instanceId = errorInfo.InstanceId;
        }

        /// <summary>
        /// Deconstructs the error information into its error definition only.
        /// </summary>
        /// <typeparam name="TErrorType">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="errorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        public static void Deconstruct<TErrorType>(
            this IErrorInfo<TErrorType> errorInfo,
            out TErrorType errorDefinition)
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(errorInfo, nameof(errorInfo));
            errorDefinition = errorInfo.ErrorDefinition;
        }

        /// <summary>
        /// Deconstructs the error information into its message only.
        /// </summary>
        /// <typeparam name="TErrorType">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="message">A human-readable message providing context for this error instance.</param>
        public static void Deconstruct<TErrorType>(
            this IErrorInfo<TErrorType> errorInfo,
            out string message)
            where TErrorType : IErrorType
        {
            ArgumentNullException.ThrowIfNull(errorInfo, nameof(errorInfo));
            message = errorInfo.Message;
        }
    }
}
