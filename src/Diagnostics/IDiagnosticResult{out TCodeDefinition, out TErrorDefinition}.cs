// <copyright file="IDiagnosticResult{out TCodeDefinition, out TErrorDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>
    /// Represents the outcome of a single diagnostic check, including status, timing, and details.
    /// </summary>
    /// <typeparam name="TCodeDefinition">The code type categorizing the check result.</typeparam>
    /// <typeparam name="TErrorDefinition">The error information type for any detected issues.</typeparam>
    public interface IDiagnosticResult<out TCodeDefinition, out TErrorDefinition>
        : IEnvelope<TCodeDefinition, TErrorDefinition, DiagnosticStatus>, IHasTimestamp
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    {
        /// <summary>Gets the status of the diagnostic check.</summary>
        DiagnosticStatus Status { get; }

        /// <summary>Gets the duration of the diagnostic check.</summary>
        TimeSpan CheckDuration { get; }
    }
}
