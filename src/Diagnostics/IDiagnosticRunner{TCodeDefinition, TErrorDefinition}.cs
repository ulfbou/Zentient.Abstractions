// <copyright file="IDiagnosticRunner{TCodeDefinition, TErrorDefinition}.cs" company="Zentient Framework Team">
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
    /// Orchestrates execution of a set of diagnostic checks and composes a consolidated report.
    /// </summary>
    /// <typeparam name="TCodeDefinition">The code type used for result classification.</typeparam>
    /// <typeparam name="TErrorDefinition">The error type used for detailed issue reporting.</typeparam>
    public interface IDiagnosticRunner<TCodeDefinition, TErrorDefinition>
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    {
        /// <summary>
        /// Runs the specified diagnostic checks against an optional subject instance.
        /// </summary>
        /// <param name="checkTypes">The definitions of checks to execute.</param>
        /// <param name="subject">Optional subject passed to each check (may be null).</param>
        /// <param name="context">Optional context carrying execution parameters.</param>
        /// <param name="cancellationToken">Token to cancel the overall run.</param>
        /// <returns>
        /// A task that resolves to an <see cref="IDiagnosticReport{TCodeDefinition, TErrorDefinition}"/> summarizing the run.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="checkTypes"/> is null.
        /// </exception>
        Task<IDiagnosticReport<TCodeDefinition, TErrorDefinition>> RunChecksAsync(
            IEnumerable<IDiagnosticCheckDefinition> checkTypes,
            object? subject = null,
            IDiagnosticContext? context = default,
            CancellationToken cancellationToken = default);
    }
}
