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
    /// Provides extension methods for deconstructing <see cref="IDiagnosticResult{TCodeDefinition, TErrorDefinition}" /> and related types.
    /// </summary>
    public static class IDiagnosticDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeDefinition, TErrorDefinition}"/> into its full components.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="code">The result code of the diagnostic check.</param>
        /// <param name="errors">The collection of errors detected by the diagnostic check.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        /// <param name="checkDuration">The duration of the diagnostic check.</param>
        /// <param name="timestamp">The timestamp when the check completed.</param>
        public static void Deconstruct<TCodeDefinition, TErrorDefinition>(
            this IDiagnosticResult<TCodeDefinition, TErrorDefinition> diagnosticResult,
            out ICode<TCodeDefinition> code,
            out IReadOnlyCollection<IErrorInfo<TErrorDefinition>> errors,
            out DiagnosticStatus status,
            out TimeSpan checkDuration,
            out DateTimeOffset timestamp)
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(diagnosticResult, nameof(diagnosticResult));
            code = diagnosticResult.Code;
            errors = diagnosticResult.Errors;
            status = diagnosticResult.Status;
            checkDuration = diagnosticResult.CheckDuration;
            timestamp = diagnosticResult.Timestamp;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeDefinition, TErrorDefinition}"/> into its status (quick check subset).
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        public static void Deconstruct<TCodeDefinition, TErrorDefinition>(
            this IDiagnosticResult<TCodeDefinition, TErrorDefinition> diagnosticResult,
            out DiagnosticStatus status)
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(diagnosticResult, nameof(diagnosticResult));
            status = diagnosticResult.Status;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeDefinition, TErrorDefinition}"/> into its status and errors.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        /// <param name="errors">The collection of errors detected by the diagnostic check.</param>
        public static void Deconstruct<TCodeDefinition, TErrorDefinition>(
            this IDiagnosticResult<TCodeDefinition, TErrorDefinition> diagnosticResult,
            out DiagnosticStatus status,
            out IReadOnlyCollection<IErrorInfo<TErrorDefinition>> errors)
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(diagnosticResult, nameof(diagnosticResult));
            status = diagnosticResult.Status;
            errors = diagnosticResult.Errors;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeDefinition, TErrorDefinition}"/> into its status and check duration (performance subset).
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        /// <param name="checkDuration">The duration of the diagnostic check.</param>
        public static void Deconstruct<TCodeDefinition, TErrorDefinition>(
            this IDiagnosticResult<TCodeDefinition, TErrorDefinition> diagnosticResult,
            out DiagnosticStatus status,
            out TimeSpan checkDuration)
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(diagnosticResult, nameof(diagnosticResult));
            status = diagnosticResult.Status;
            checkDuration = diagnosticResult.CheckDuration;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeDefinition, TErrorDefinition}"/> into its code and status.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="code">The result code of the diagnostic check.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        public static void Deconstruct<TCodeDefinition, TErrorDefinition>(
            this IDiagnosticResult<TCodeDefinition, TErrorDefinition> diagnosticResult,
            out ICode<TCodeDefinition> code,
            out DiagnosticStatus status)
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(diagnosticResult, nameof(diagnosticResult));
            code = diagnosticResult.Code;
            status = diagnosticResult.Status;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeDefinition, TErrorDefinition}"/> into its code, errors, and status.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="code">The result code of the diagnostic check.</param>
        /// <param name="errors">The collection of errors detected by the diagnostic check.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        public static void Deconstruct<TCodeDefinition, TErrorDefinition>(
            this IDiagnosticResult<TCodeDefinition, TErrorDefinition> diagnosticResult,
            out ICode<TCodeDefinition> code,
            out IReadOnlyCollection<IErrorInfo<TErrorDefinition>> errors,
            out DiagnosticStatus status)
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(diagnosticResult, nameof(diagnosticResult));
            code = diagnosticResult.Code;
            errors = diagnosticResult.Errors;
            status = diagnosticResult.Status;
        }

        /// <summary>
        /// Deconstructs an <see cref="IDiagnosticResult{TCodeDefinition, TErrorDefinition}"/> into its code, errors, status, and check duration.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The specific type of the code definition for the diagnostic result.</typeparam>
        /// <typeparam name="TErrorDefinition">The specific type of the error definition for the diagnostic result.</typeparam>
        /// <param name="diagnosticResult">The diagnostic result instance to deconstruct.</param>
        /// <param name="code">The result code of the diagnostic check.</param>
        /// <param name="errors">The collection of errors detected by the diagnostic check.</param>
        /// <param name="status">The status of the diagnostic check.</param>
        /// <param name="checkDuration">The duration of the diagnostic check.</param>
        public static void Deconstruct<TCodeDefinition, TErrorDefinition>(
            this IDiagnosticResult<TCodeDefinition, TErrorDefinition> diagnosticResult,
            out ICode<TCodeDefinition> code,
            out IReadOnlyCollection<IErrorInfo<TErrorDefinition>> errors,
            out DiagnosticStatus status,
            out TimeSpan checkDuration)
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IErrorDefinition
        {
            Guard.AgainstNull(diagnosticResult, nameof(diagnosticResult));
            code = diagnosticResult.Code;
            errors = diagnosticResult.Errors;
            status = diagnosticResult.Status;
            checkDuration = diagnosticResult.CheckDuration;
        }
    }
}
