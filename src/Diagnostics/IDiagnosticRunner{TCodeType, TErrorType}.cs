// <copyright file="IDiagnosticRunner{TCodeType, TErrorType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>
    /// Orchestrates execution of a set of diagnostic checks and composes a consolidated report.
    /// </summary>
    /// <typeparam name="TCodeType">The code type used for result classification.</typeparam>
    /// <typeparam name="TErrorType">The error type used for detailed issue reporting.</typeparam>
    public interface IDiagnosticRunner<TCodeType, TErrorType>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        /// <summary>
        /// Runs the specified diagnostic checks against an optional subject instance.
        /// </summary>
        /// <param name="checkTypes">The definitions of checks to execute.</param>
        /// <param name="subject">Optional subject passed to each check (may be null).</param>
        /// <param name="context">Optional context carrying execution parameters.</param>
        /// <param name="cancellationToken">Token to cancel the overall run.</param>
        /// <returns>
        /// A task that resolves to an <see cref="IDiagnosticReport{TCodeType, TErrorType}"/> summarizing the run.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="checkTypes"/> is null.
        /// </exception>
        Task<IDiagnosticReport<TCodeType, TErrorType>> RunChecksAsync(
            IEnumerable<IDiagnosticCheckType> checkTypes,
            object? subject = null,
            IDiagnosticContext? context = default,
            CancellationToken cancellationToken = default);
    }
}
