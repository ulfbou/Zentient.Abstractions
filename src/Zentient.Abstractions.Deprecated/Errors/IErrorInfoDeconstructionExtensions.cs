// <copyright file="IErrorInfoDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using System;
using System.Collections.Generic;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Errors.Definitions;
using Zentient.Abstractions.Codes.Definitions;

namespace Zentient.Abstractions.Errors
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="IErrorInfo{TErrorDefinition}" /> and related types.
    /// </summary>
    public static class IErrorInfoDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs the error information into all its properties: error definition, code, message, instance identifier, inner errors, and metadata.
        /// </summary>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="ErrorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="Code">The symbolic code describing the semantic meaning of this error.</param>
        /// <param name="Message">A human-readable message providing context for this error instance.</param>
        /// <param name="InstanceId">A unique identifier for this specific error occurrence.</param>
        /// <param name="InnerErrors">A collection of inner errors, if this error is a composite.</param>
        /// <param name="Metadata">The metadata associated with this error instance.</param>
        public static void Deconstruct<TErrorDefinition>(
            this IErrorInfo<TErrorDefinition> errorInfo,
            out TErrorDefinition ErrorDefinition,
            out ICode<ICodeDefinition> Code,
            out string Message,
            out string InstanceId,
            out IReadOnlyCollection<IErrorInfo<TErrorDefinition>> InnerErrors,
            out IMetadata Metadata)
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(errorInfo, nameof(errorInfo));
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
        /// <typeparam name="TErrorDefinition">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="ErrorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="Code">The symbolic code describing the semantic meaning of this error.</param>
        /// <param name="Message">A human-readable message providing context for this error instance.</param>
        /// <param name="InstanceId">A unique identifier for this specific error occurrence.</param>
        /// <param name="InnerErrors">A collection of inner errors, if this error is a composite.</param>
        public static void Deconstruct<TErrorDefinition>(
            this IErrorInfo<TErrorDefinition> errorInfo,
            out TErrorDefinition ErrorDefinition,
            out ICode<ICodeDefinition> Code,
            out string Message,
            out string InstanceId,
            out IReadOnlyCollection<IErrorInfo<TErrorDefinition>> InnerErrors)
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(errorInfo, nameof(errorInfo));
            ErrorDefinition = errorInfo.ErrorDefinition;
            Code = errorInfo.Code;
            Message = errorInfo.Message;
            InstanceId = errorInfo.InstanceId;
            InnerErrors = errorInfo.InnerErrors;
        }

        /// <summary>
        /// Deconstructs the error information into its error definition, code, and message components.
        /// </summary>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition for the error info.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="errorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="code">The symbolic code describing the semantic meaning of this error.</param>
        /// <param name="message">A human-readable message providing context for this error instance.</param>
        public static void Deconstruct<TErrorDefinition>(
            this IErrorInfo<TErrorDefinition> errorInfo,
            out IErrorDefinition errorDefinition,
            out ICode<ICodeDefinition> code,
            out string message)
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(errorInfo, nameof(errorInfo));
            errorDefinition = errorInfo.ErrorDefinition;
            code = errorInfo.Code;
            message = errorInfo.Message;
        }

        /// <summary>
        /// Deconstructs the error information into its error definition, message, and code (basic subset).
        /// </summary>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="errorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="message">A human-readable message providing context for this error instance.</param>
        /// <param name="code">The symbolic code describing the semantic meaning of this error.</param>
        public static void Deconstruct<TErrorDefinition>(
            this IErrorInfo<TErrorDefinition> errorInfo,
            out TErrorDefinition errorDefinition,
            out string message,
            out ICode<ICodeDefinition> code)
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(errorInfo, nameof(errorInfo));
            errorDefinition = errorInfo.ErrorDefinition;
            message = errorInfo.Message;
            code = errorInfo.Code;
        }

        /// <summary>
        /// Deconstructs the error information into its error definition, message, code, and instance ID (debugging/logging subset).
        /// </summary>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="errorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        /// <param name="message">A human-readable message providing context for this error instance.</param>
        /// <param name="code">The symbolic code describing the semantic meaning of this error.</param>
        /// <param name="instanceId">A unique identifier for this specific error occurrence.</param>
        public static void Deconstruct<TErrorDefinition>(
            this IErrorInfo<TErrorDefinition> errorInfo,
            out TErrorDefinition errorDefinition,
            out string message,
            out ICode<ICodeDefinition> code,
            out string instanceId)
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(errorInfo, nameof(errorInfo));
            errorDefinition = errorInfo.ErrorDefinition;
            message = errorInfo.Message;
            code = errorInfo.Code;
            instanceId = errorInfo.InstanceId;
        }

        /// <summary>
        /// Deconstructs the error information into its error definition only.
        /// </summary>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="errorDefinition">The symbolic error definition describing the semantic meaning of this error.</param>
        public static void Deconstruct<TErrorDefinition>(
            this IErrorInfo<TErrorDefinition> errorInfo,
            out TErrorDefinition errorDefinition)
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(errorInfo, nameof(errorInfo));
            errorDefinition = errorInfo.ErrorDefinition;
        }

        /// <summary>
        /// Deconstructs the error information into its message only.
        /// </summary>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition.</typeparam>
        /// <param name="errorInfo">The error information instance to deconstruct.</param>
        /// <param name="message">A human-readable message providing context for this error instance.</param>
        public static void Deconstruct<TErrorDefinition>(
            this IErrorInfo<TErrorDefinition> errorInfo,
            out string message)
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(errorInfo, nameof(errorInfo));
            message = errorInfo.Message;
        }
    }
}
