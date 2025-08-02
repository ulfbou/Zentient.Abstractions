// <copyright file="IDiagnosticReport{out TCodeType, out TErrorType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>
    /// Aggregates the results of multiple diagnostic checks into a unified, strongly‐typed report.
    /// </summary>
    /// <typeparam name="TCodeType">The code type shared by all checks in this report.</typeparam>
    /// <typeparam name="TErrorType">The error type shared by all checks in this report.</typeparam>
    public interface IDiagnosticReport<out TCodeType, out TErrorType>
        : IHasCorrelationId, IHasTimestamp
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        /// <summary>Gets all individual diagnostic results included in this report.</summary>
        /// <value>The Results collection.</value>
        IEnumerable<IDiagnosticResult<TCodeType, TErrorType>> Results { get; }

        /// <summary>Gets the aggregated status computed from all individual results.</summary>
        /// <value>The overall status of the report.</value>
        DiagnosticStatus OverallStatus { get; }

        /// <summary>Gets the timestamp when this report was generated.</summary>
        /// <value>The report generation timestamp.</value>
        DateTimeOffset ReportTimestamp { get; }
    }
}
