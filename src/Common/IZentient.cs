// <copyright file="IZentient.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using Zentient.Abstractions.DependencyInjection;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Validation.Factories;
using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Represents the unified core of the Zentient application, providing a single point
    /// of access to all major framework systems.
    /// </summary>
    /// <remarks>
    /// This interface brings together the four pillars of the Zentient Framework:
    /// 1. Definition-Centric Core - Through the service resolver's type discovery
    /// 2. Universal Envelope - Through validation and diagnostic results
    /// 3. Fluent DI and Application Builder - Through the service resolver
    /// 4. Built-in Observability - Through diagnostics and validation systems
    /// 
    /// By providing a single, non-generic entry point, this interface simplifies
    /// dependency injection while maintaining access to the type-safe, generic
    /// components that make up the system's operational core.
    /// </remarks>
    public interface IZentient
    {
        /// <summary>
        /// Gets the primary service resolver for the application.
        /// This provides access to all registered services and represents the culmination
        /// of the Fluent DI and Application Builder pillar.
        /// </summary>
        IServiceResolver Services { get; }

        /// <summary>
        /// Gets the primary validation factory for the application.
        /// This enables creation of type-safe validators as part of the Built-in Observability pillar.
        /// </summary>
        IValidatorFactory Validators { get; }

        /// <summary>
        /// Retrieves a diagnostic runner for a specific code and error definition.
        /// This method provides type-safe access to the diagnostic system while maintaining
        /// the non-generic nature of the core IZentient interface.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The code type used for result classification.</typeparam>
        /// <typeparam name="TErrorDefinition">The error type used for detailed issue reporting.</typeparam>
        /// <returns>A diagnostic runner instance tailored for the specified types.</returns>
        /// <remarks>
        /// This method correctly handles the generic nature of IDiagnosticRunner while keeping
        /// IZentient itself non-generic, allowing for easy dependency injection registration
        /// while preserving type safety when accessing diagnostic capabilities.
        /// </remarks>
        IDiagnosticRunner<TCodeDefinition, TErrorDefinition> GetDiagnosticRunner<TCodeDefinition, TErrorDefinition>()
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IErrorDefinition;

        /// <summary>
        /// Performs a comprehensive health check of the entire Zentient application core.
        /// This method leverages the Built-in Observability pillar to provide system-wide
        /// health assessment.
        /// </summary>
        /// <typeparam name="TCodeDefinition">The code type used for health check results.</typeparam>
        /// <typeparam name="TErrorDefinition">The error type used for health check issues.</typeparam>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous health check operation.
        /// The task's result contains a comprehensive diagnostic report.
        /// </returns>
        Task<IDiagnosticReport<TCodeDefinition, TErrorDefinition>> PerformHealthCheckAsync<TCodeDefinition, TErrorDefinition>(
            CancellationToken cancellationToken = default)
            where TCodeDefinition : ICodeDefinition
            where TErrorDefinition : IErrorDefinition;
    }
}
