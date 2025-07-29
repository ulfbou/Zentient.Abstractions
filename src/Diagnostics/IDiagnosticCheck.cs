// <copyright file="IDiagnosticCheck.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>
    /// Executes a diagnostic check against a given subject, producing a structured result.
    /// </summary>
    /// <typeparam name="TSubject">The type of object or service to diagnose.</typeparam>
    /// <typeparam name="TCodeType">The code type used for result classification.</typeparam>
    /// <typeparam name="TErrorType">The error type used for detailed issue reporting.</typeparam>
    public interface IDiagnosticCheck<TSubject, TCodeType, TErrorType>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        /// <summary>
        /// Gets the metadata definition for this diagnostic check.
        /// </summary>
        IDiagnosticCheckType Type { get; }

        /// <summary>
        /// Executes the diagnostic check on the specified subject.
        /// </summary>
        /// <param name="subject">The target of the diagnostic operation.</param>
        /// <param name="context">
        /// Optional context providing metadata, timeouts, and profile settings.
        /// </param>
        /// <param name="cancellationToken">A token to cancel the check early.</param>
        /// <returns>
        /// A task that resolves to an <see cref="IDiagnosticResult{TCodeType,TErrorType}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="subject"/> is null.
        /// </exception>
        Task<IDiagnosticResult<TCodeType, TErrorType>> ExecuteAsync(
            TSubject subject,
            IDiagnosticContext? context = default,
            CancellationToken cancellationToken = default);
    }
}
