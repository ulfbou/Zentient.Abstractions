// <copyright file="IServiceResolutionResult.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.DependencyInjection.Results
{
    /// <summary>
    /// Represents the result of a service resolution operation with detailed context and error information.
    /// </summary>
    /// <typeparam name="TService">The type of service that was requested.</typeparam>
    public interface IServiceResolutionResult<out TService> : IResult<TService>
    {
        /// <summary>
        /// Gets the service descriptor that was used to resolve the service.
        /// </summary>
        /// <value>
        /// The service descriptor used for resolution, or null if resolution failed
        /// before a descriptor could be selected.
        /// </value>
        IServiceDescriptor? UsedDescriptor { get; }

        /// <summary>
        /// Gets the time taken to resolve the service.
        /// </summary>
        /// <value>The duration of the resolution operation.</value>
        TimeSpan ResolutionTime { get; }

        /// <summary>
        /// Gets metadata associated with the resolution process.
        /// </summary>
        /// <value>
        /// Metadata containing resolution context, performance metrics,
        /// and other diagnostic information.
        /// </value>
        IMetadata ResolutionMetadata { get; }

        /// <summary>
        /// Gets a value indicating whether the service was resolved from cache.
        /// </summary>
        /// <value>
        /// True if the service instance was retrieved from cache rather than created;
        /// otherwise, false.
        /// </value>
        bool WasCached { get; }

        /// <summary>
        /// Gets the scope in which the service was resolved.
        /// </summary>
        /// <value>
        /// Information about the resolution scope, or null if resolution failed
        /// or was performed outside a scope.
        /// </value>
        IServiceResolutionScope? ResolutionScope { get; }

        /// <summary>
        /// Gets detailed information about the resolution path taken.
        /// </summary>
        /// <value>
        /// A collection of resolution steps that were executed during service creation,
        /// useful for debugging complex dependency graphs.
        /// </value>
        IReadOnlyCollection<IResolutionStep> ResolutionPath { get; }

        /// <summary>
        /// Gets any warnings that occurred during resolution but didn't prevent success.
        /// </summary>
        /// <value>
        /// A collection of non-fatal warnings that occurred during the resolution process.
        /// </value>
        IReadOnlyCollection<string> Warnings { get; }
    }

    /// <summary>
    /// Represents information about the scope in which service resolution occurred.
    /// </summary>
    public interface IServiceResolutionScope
    {
        /// <summary>
        /// Gets the unique identifier of the resolution scope.
        /// </summary>
        string ScopeId { get; }

        /// <summary>
        /// Gets the type of scope (e.g., "Request", "Manual", "Root").
        /// </summary>
        string ScopeType { get; }

        /// <summary>
        /// Gets the parent scope identifier, if any.
        /// </summary>
        string? ParentScopeId { get; }

        /// <summary>
        /// Gets when the scope was created.
        /// </summary>
        DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Gets metadata associated with the scope.
        /// </summary>
        IMetadata Metadata { get; }
    }

    /// <summary>
    /// Represents a single step in the service resolution process.
    /// </summary>
    public interface IResolutionStep
    {
        /// <summary>
        /// Gets the order of this step in the resolution process.
        /// </summary>
        int StepNumber { get; }

        /// <summary>
        /// Gets a description of what this step accomplished.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the type that was being resolved in this step.
        /// </summary>
        Type TargetType { get; }

        /// <summary>
        /// Gets the service descriptor used in this step, if any.
        /// </summary>
        IServiceDescriptor? UsedDescriptor { get; }

        /// <summary>
        /// Gets the duration of this resolution step.
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        /// Gets any metadata associated with this step.
        /// </summary>
        IMetadata StepMetadata { get; }

        /// <summary>
        /// Gets the result of this step.
        /// </summary>
        ResolutionStepResult Result { get; }

        /// <summary>
        /// Gets any error that occurred during this step.
        /// </summary>
        IErrorInfo<IErrorDefinition>? Error { get; }
    }

    /// <summary>
    /// Represents the result of a resolution step.
    /// </summary>
    public enum ResolutionStepResult
    {
        /// <summary>The step completed successfully.</summary>
        Success = 0,

        /// <summary>The step was skipped due to conditions.</summary>
        Skipped = 1,

        /// <summary>The step failed with an error.</summary>
        Failed = 2,

        /// <summary>The step was cached and returned immediately.</summary>
        Cached = 3,

        /// <summary>The step was intercepted by middleware.</summary>
        Intercepted = 4,

        /// <summary>The step was decorated by another service.</summary>
        Decorated = 5
    }

    /// <summary>
    /// Represents the result of service registration operations.
    /// </summary>
    public interface IServiceRegistrationResult : IResult
    {
        /// <summary>
        /// Gets the service descriptors that were registered.
        /// </summary>
        /// <value>
        /// The collection of service descriptors that were successfully registered.
        /// </value>
        IReadOnlyCollection<IServiceDescriptor> RegisteredDescriptors { get; }

        /// <summary>
        /// Gets descriptors that failed to register.
        /// </summary>
        /// <value>
        /// A collection of service descriptors that could not be registered, along with their errors.
        /// </value>
        IReadOnlyCollection<(IServiceDescriptor Descriptor, IErrorInfo<IErrorDefinition> Error)> FailedDescriptors { get; }

        /// <summary>
        /// Gets the time taken to complete the registration.
        /// </summary>
        /// <value>The duration of the registration operation.</value>
        TimeSpan RegistrationTime { get; }

        /// <summary>
        /// Gets metadata associated with the registration process.
        /// </summary>
        /// <value>Metadata containing registration context and diagnostic information.</value>
        IMetadata RegistrationMetadata { get; }

        /// <summary>
        /// Gets any validation warnings that occurred during registration.
        /// </summary>
        /// <value>
        /// A collection of non-fatal warnings that occurred during the registration process.
        /// </value>
        IReadOnlyCollection<string> ValidationWarnings { get; }
    }

    /// <summary>
    /// Factory for creating service resolution and registration results.
    /// </summary>
    public interface IServiceResultFactory
    {
        /// <summary>
        /// Creates a successful service resolution result.
        /// </summary>
        /// <typeparam name="TService">The type of service that was resolved.</typeparam>
        /// <param name="service">The resolved service instance.</param>
        /// <param name="descriptor">The service descriptor used for resolution.</param>
        /// <param name="resolutionTime">The time taken to resolve the service.</param>
        /// <param name="wasCached">Whether the service was resolved from cache.</param>
        /// <param name="scope">The resolution scope information.</param>
        /// <param name="resolutionPath">The path taken during resolution.</param>
        /// <param name="warnings">Any warnings that occurred during resolution.</param>
        /// <param name="metadata">Additional metadata about the resolution.</param>
        /// <returns>A successful service resolution result.</returns>
        IServiceResolutionResult<TService> CreateSuccessResult<TService>(
            TService service,
            IServiceDescriptor descriptor,
            TimeSpan resolutionTime,
            bool wasCached = false,
            IServiceResolutionScope? scope = null,
            IReadOnlyCollection<IResolutionStep>? resolutionPath = null,
            IReadOnlyCollection<string>? warnings = null,
            IMetadata? metadata = null);

        /// <summary>
        /// Creates a failed service resolution result.
        /// </summary>
        /// <typeparam name="TService">The type of service that was requested.</typeparam>
        /// <param name="errors">The errors that prevented successful resolution.</param>
        /// <param name="resolutionTime">The time taken before resolution failed.</param>
        /// <param name="usedDescriptor">The service descriptor that was attempted, if any.</param>
        /// <param name="scope">The resolution scope information.</param>
        /// <param name="resolutionPath">The path taken before failure.</param>
        /// <param name="metadata">Additional metadata about the failed resolution.</param>
        /// <returns>A failed service resolution result.</returns>
        IServiceResolutionResult<TService> CreateFailureResult<TService>(
            IEnumerable<IErrorInfo<IErrorDefinition>> errors,
            TimeSpan resolutionTime,
            IServiceDescriptor? usedDescriptor = null,
            IServiceResolutionScope? scope = null,
            IReadOnlyCollection<IResolutionStep>? resolutionPath = null,
            IMetadata? metadata = null);

        /// <summary>
        /// Creates a successful service registration result.
        /// </summary>
        /// <param name="registeredDescriptors">The descriptors that were successfully registered.</param>
        /// <param name="registrationTime">The time taken to complete registration.</param>
        /// <param name="warnings">Any validation warnings that occurred.</param>
        /// <param name="metadata">Additional metadata about the registration.</param>
        /// <returns>A successful service registration result.</returns>
        IServiceRegistrationResult CreateRegistrationSuccess(
            IEnumerable<IServiceDescriptor> registeredDescriptors,
            TimeSpan registrationTime,
            IReadOnlyCollection<string>? warnings = null,
            IMetadata? metadata = null);

        /// <summary>
        /// Creates a failed service registration result.
        /// </summary>
        /// <param name="errors">The errors that prevented successful registration.</param>
        /// <param name="registrationTime">The time taken before registration failed.</param>
        /// <param name="registeredDescriptors">Any descriptors that were successfully registered before failure.</param>
        /// <param name="failedDescriptors">The descriptors that failed to register with their errors.</param>
        /// <param name="metadata">Additional metadata about the failed registration.</param>
        /// <returns>A failed service registration result.</returns>
        IServiceRegistrationResult CreateRegistrationFailure(
            IEnumerable<IErrorInfo<IErrorDefinition>> errors,
            TimeSpan registrationTime,
            IReadOnlyCollection<IServiceDescriptor>? registeredDescriptors = null,
            IReadOnlyCollection<(IServiceDescriptor Descriptor, IErrorInfo<IErrorDefinition> Error)>? failedDescriptors = null,
            IMetadata? metadata = null);
    }
}
