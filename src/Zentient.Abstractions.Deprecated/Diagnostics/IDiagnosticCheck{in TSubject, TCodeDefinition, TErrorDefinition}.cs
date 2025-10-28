// <copyright file="IDiagnosticCheck{in TSubject, TCodeDefinition, TErrorDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Diagnostics.Definitions;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>
    /// Executes a diagnostic check against a given subject, producing a structured result.
    /// </summary>
    /// <typeparam name="TSubject">The type of object or service to diagnose.</typeparam>
    /// <typeparam name="TCodeDefinition">The code type used for result classification.</typeparam>
    /// <typeparam name="TErrorDefinition">The error type used for detailed issue reporting.</typeparam>
    public interface IDiagnosticCheck<in TSubject, TCodeDefinition, TErrorDefinition>
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    {
        /// <summary>
        /// Gets the metadata definition for this diagnostic check.
        /// </summary>
        IDiagnosticCheckDefinition Definition { get; }

        /// <summary>
        /// Executes the diagnostic check on the specified subject.
        /// </summary>
        /// <param name="subject">The target of the diagnostic operation.</param>
        /// <param name="context">
        /// Optional context providing metadata, timeouts, and profile settings.
        /// </param>
        /// <param name="cancellationToken">A token to cancel the check early.</param>
        /// <returns>
        /// A task that resolves to an <see cref="IDiagnosticResult{TCodeDefinition,TErrorDefinition}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="subject"/> is null.
        /// </exception>
        Task<IDiagnosticResult<TCodeDefinition, TErrorDefinition>> ExecuteAsync(
            TSubject subject,
            IDiagnosticContext? context = default,
            CancellationToken cancellationToken = default);
    }
}
