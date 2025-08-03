// <copyright file="IDiagnosticDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;
using System;
using System.Collections.Generic;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="IDiagnosticResult{TCodeType, TErrorType}" /> and related types.
    /// </summary>
    public static class IDiagnosticDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeType, TErrorType}"/> into its full components.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="code">The result code of the diagnostic check.</param>
        /// <param name="errors">The collection of errors detected by the diagnostic check.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        /// <param name="checkDuration">The duration of the diagnostic check.</param>
        /// <param name="timestamp">The timestamp when the check completed.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IDiagnosticResult<TCodeType, TErrorType> diagnosticResult,
            out ICode<TCodeType> code,
            out IReadOnlyCollection<IErrorInfo<TErrorType>> errors,
            out DiagnosticStatus status,
            out TimeSpan checkDuration,
            out DateTimeOffset timestamp)
            where TCodeType : ICodeDefinition
            where TErrorType : IErrorDefinition
        {
            ArgumentNullException.ThrowIfNull(diagnosticResult, nameof(diagnosticResult));
            code = diagnosticResult.Code;
            errors = diagnosticResult.Errors;
            status = diagnosticResult.Status;
            checkDuration = diagnosticResult.CheckDuration;
            timestamp = diagnosticResult.Timestamp;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeType, TErrorType}"/> into its status (quick check subset).
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IDiagnosticResult<TCodeType, TErrorType> diagnosticResult,
            out DiagnosticStatus status)
            where TCodeType : ICodeDefinition
            where TErrorType : IErrorDefinition
        {
            ArgumentNullException.ThrowIfNull(diagnosticResult, nameof(diagnosticResult));
            status = diagnosticResult.Status;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeType, TErrorType}"/> into its status and errors.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        /// <param name="errors">The collection of errors detected by the diagnostic check.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IDiagnosticResult<TCodeType, TErrorType> diagnosticResult,
            out DiagnosticStatus status,
            out IReadOnlyCollection<IErrorInfo<TErrorType>> errors)
            where TCodeType : ICodeDefinition
            where TErrorType : IErrorDefinition
        {
            ArgumentNullException.ThrowIfNull(diagnosticResult, nameof(diagnosticResult));
            status = diagnosticResult.Status;
            errors = diagnosticResult.Errors;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeType, TErrorType}"/> into its status and check duration (performance subset).
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        /// <param name="checkDuration">The duration of the diagnostic check.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IDiagnosticResult<TCodeType, TErrorType> diagnosticResult,
            out DiagnosticStatus status,
            out TimeSpan checkDuration)
            where TCodeType : ICodeDefinition
            where TErrorType : IErrorDefinition
        {
            ArgumentNullException.ThrowIfNull(diagnosticResult, nameof(diagnosticResult));
            status = diagnosticResult.Status;
            checkDuration = diagnosticResult.CheckDuration;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeType, TErrorType}"/> into its code and status.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="code">The result code of the diagnostic check.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IDiagnosticResult<TCodeType, TErrorType> diagnosticResult,
            out ICode<TCodeType> code,
            out DiagnosticStatus status)
            where TCodeType : ICodeDefinition
            where TErrorType : IErrorDefinition
        {
            ArgumentNullException.ThrowIfNull(diagnosticResult, nameof(diagnosticResult));
            code = diagnosticResult.Code;
            status = diagnosticResult.Status;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeType, TErrorType}"/> into its code, errors, and status.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="code">The result code of the diagnostic check.</param>
        /// <param name="errors">The collection of errors detected by the diagnostic check.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IDiagnosticResult<TCodeType, TErrorType> diagnosticResult,
            out ICode<TCodeType> code,
            out IReadOnlyCollection<IErrorInfo<TErrorType>> errors,
            out DiagnosticStatus status)
            where TCodeType : ICodeDefinition
            where TErrorType : IErrorDefinition
        {
            ArgumentNullException.ThrowIfNull(diagnosticResult, nameof(diagnosticResult));
            code = diagnosticResult.Code;
            errors = diagnosticResult.Errors;
            status = diagnosticResult.Status;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeType, TErrorType}"/> into its code, errors, status, and check duration.
        /// </summary>
        /// <typeparam name="TCodeType">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorType">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="code">The result code of the diagnostic check.</param>
        /// <param name="errors">The collection of errors detected by the diagnostic check.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        /// <param name="checkDuration">The duration of the diagnostic check.</param>
        public static void Deconstruct<TCodeType, TErrorType>(
            this IDiagnosticResult<TCodeType, TErrorType> diagnosticResult,
            out ICode<TCodeType> code,
            out IReadOnlyCollection<IErrorInfo<TErrorType>> errors,
            out DiagnosticStatus status,
            out TimeSpan checkDuration)
            where TCodeType : ICodeDefinition
            where TErrorType : IErrorDefinition
        {
            ArgumentNullException.ThrowIfNull(diagnosticResult, nameof(diagnosticResult));
            code = diagnosticResult.Code;
            errors = diagnosticResult.Errors;
            status = diagnosticResult.Status;
            checkDuration = diagnosticResult.CheckDuration;
        }
    }
}
