// <copyright file="IDiagnosticResult.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>
    /// Represents the outcome of a single diagnostic check, including status, timing, and details.
    /// </summary>
    /// <typeparam name="TCodeType">The code type categorizing the check result.</typeparam>
    /// <typeparam name="TErrorType">The error information type for any detected issues.</typeparam>
    public interface IDiagnosticResult<out TCodeType, out TErrorType>
        : IEnvelope<TCodeType, TErrorType, DiagnosticStatus>
        where TCodeType : ICodeType
        where TErrorType : IErrorType
    {
        /// <summary>
        /// Gets the duration of the diagnostic check.
        /// </summary>
        TimeSpan CheckDuration { get; }

        /// <summary>
        /// Gets the timestamp when the check completed.
        /// </summary>
        DateTimeOffset Timestamp { get; }
    }
}
