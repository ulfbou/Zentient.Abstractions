// <copyright file="IServiceValidationContext.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.DependencyInjection.Validation
{
    /// <summary>
    /// Provides context and services for validating service registrations and dependencies.
    /// </summary>
    public interface IServiceValidationContext
    {
        /// <summary>
        /// Gets the registry being validated.
        /// </summary>
        IServiceRegistry Registry { get; }

        /// <summary>
        /// Gets all service descriptors being validated.
        /// </summary>
        IReadOnlyCollection<IServiceDescriptor> Descriptors { get; }

        /// <summary>
        /// Gets metadata associated with the validation process.
        /// </summary>
        IMetadata ValidationMetadata { get; }

        /// <summary>
        /// Gets the current validation options.
        /// </summary>
        ServiceValidationOptions Options { get; }

        /// <summary>
        /// Adds a validation error to the context.
        /// </summary>
        /// <param name="error">The validation error to add.</param>
        void AddError(IErrorInfo<IErrorDefinition> error);

        /// <summary>
        /// Adds a validation warning to the context.
        /// </summary>
        /// <param name="warning">The validation warning message.</param>
        void AddWarning(string warning);

        /// <summary>
        /// Checks if a service type can be resolved from the current registry.
        /// </summary>
        /// <param name="serviceType">The service type to check.</param>
        /// <returns>True if the service type can be resolved; otherwise, false.</returns>
        bool CanResolve(Type serviceType);

        /// <summary>
        /// Gets all service descriptors that can provide the specified service type.
        /// </summary>
        /// <param name="serviceType">The service type to search for.</param>
        /// <returns>A collection of service descriptors that can provide the service type.</returns>
        IEnumerable<IServiceDescriptor> GetProvidersFor(Type serviceType);

        /// <summary>
        /// Checks for circular dependencies starting from the specified service type.
        /// </summary>
        /// <param name="serviceType">The service type to check for circular dependencies.</param>
        /// <returns>A collection of dependency chains that form circular references.</returns>
        IEnumerable<IReadOnlyList<Type>> GetCircularDependencies(Type serviceType);

        /// <summary>
        /// Gets the dependency graph for the specified service type.
        /// </summary>
        /// <param name="serviceType">The service type to analyze.</param>
        /// <returns>A dependency graph showing all dependencies and their relationships.</returns>
        IServiceDependencyGraph GetDependencyGraph(Type serviceType);
    }

    /// <summary>
    /// Represents options for service validation.
    /// </summary>
    public sealed class ServiceValidationOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether to validate circular dependencies.
        /// </summary>
        /// <value>True to check for circular dependencies; otherwise, false. Default is true.</value>
        public bool ValidateCircularDependencies { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to validate that all dependencies can be resolved.
        /// </summary>
        /// <value>True to validate dependency resolution; otherwise, false. Default is true.</value>
        public bool ValidateDependencyResolution { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to validate service lifetimes for compatibility.
        /// </summary>
        /// <value>True to validate lifetime compatibility; otherwise, false. Default is true.</value>
        public bool ValidateLifetimes { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to validate generic type constraints.
        /// </summary>
        /// <value>True to validate generic constraints; otherwise, false. Default is true.</value>
        public bool ValidateGenericConstraints { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to validate decorator patterns.
        /// </summary>
        /// <value>True to validate decorator configurations; otherwise, false. Default is true.</value>
        public bool ValidateDecorators { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to validate interceptor patterns.
        /// </summary>
        /// <value>True to validate interceptor configurations; otherwise, false. Default is true.</value>
        public bool ValidateInterceptors { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to validate conditional registrations.
        /// </summary>
        /// <value>True to validate conditional registration logic; otherwise, false. Default is true.</value>
        public bool ValidateConditionalRegistrations { get; set; } = true;

        /// <summary>
        /// Gets or sets the maximum depth for dependency validation.
        /// </summary>
        /// <value>The maximum depth to traverse when validating dependencies. Default is 50.</value>
        public int MaxValidationDepth { get; set; } = 50;

        /// <summary>
        /// Gets custom validation rules to apply.
        /// </summary>
        /// <value>A collection of custom validation rules to execute.</value>
        public ICollection<IServiceValidationRule> CustomRules { get; } = new List<IServiceValidationRule>();

        /// <summary>
        /// Gets or sets a value indicating whether to stop validation on the first error.
        /// </summary>
        /// <value>True to stop on the first error; false to collect all errors. Default is false.</value>
        public bool StopOnFirstError { get; set; }

        /// <summary>
        /// Gets or sets the timeout for validation operations.
        /// </summary>
        /// <value>The maximum time to spend on validation. Default is 30 seconds.</value>
        public TimeSpan ValidationTimeout { get; set; } = TimeSpan.FromSeconds(30);
    }

    /// <summary>
    /// Represents a custom validation rule for service registrations.
    /// </summary>
    public interface IServiceValidationRule
    {
        /// <summary>
        /// Gets the name of the validation rule.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the description of what this rule validates.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the severity level of violations detected by this rule.
        /// </summary>
        ValidationSeverity Severity { get; }

        /// <summary>
        /// Validates a service descriptor within the given context.
        /// </summary>
        /// <param name="descriptor">The service descriptor to validate.</param>
        /// <param name="context">The validation context.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous validation operation.</returns>
        Task ValidateAsync(IServiceDescriptor descriptor, IServiceValidationContext context, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Represents the severity level of a validation rule violation.
    /// </summary>
    public enum ValidationSeverity
    {
        /// <summary>Informational message that doesn't indicate a problem.</summary>
        Info = 0,

        /// <summary>Warning about a potential issue that might cause problems.</summary>
        Warning = 1,

        /// <summary>Error that will likely cause runtime failures.</summary>
        Error = 2,

        /// <summary>Critical error that will definitely cause runtime failures.</summary>
        Critical = 3
    }

    /// <summary>
    /// Represents a dependency graph for service resolution analysis.
    /// </summary>
    public interface IServiceDependencyGraph
    {
        /// <summary>
        /// Gets the root service type of this dependency graph.
        /// </summary>
        Type RootServiceType { get; }

        /// <summary>
        /// Gets all nodes in the dependency graph.
        /// </summary>
        IReadOnlyCollection<IDependencyGraphNode> Nodes { get; }

        /// <summary>
        /// Gets all edges (dependencies) in the graph.
        /// </summary>
        IReadOnlyCollection<IDependencyGraphEdge> Edges { get; }

        /// <summary>
        /// Gets the maximum depth of the dependency graph.
        /// </summary>
        int MaxDepth { get; }

        /// <summary>
        /// Gets a value indicating whether the graph contains circular dependencies.
        /// </summary>
        bool HasCircularDependencies { get; }

        /// <summary>
        /// Gets all circular dependency paths in the graph.
        /// </summary>
        IReadOnlyCollection<IReadOnlyList<Type>> CircularPaths { get; }

        /// <summary>
        /// Finds the shortest path between two service types in the dependency graph.
        /// </summary>
        /// <param name="from">The source service type.</param>
        /// <param name="to">The target service type.</param>
        /// <returns>The shortest dependency path, or null if no path exists.</returns>
        IReadOnlyList<Type>? FindShortestPath(Type from, Type to);

        /// <summary>
        /// Gets all service types that depend on the specified service type.
        /// </summary>
        /// <param name="serviceType">The service type to find dependents for.</param>
        /// <returns>A collection of service types that depend on the specified type.</returns>
        IEnumerable<Type> GetDependents(Type serviceType);

        /// <summary>
        /// Gets all service types that the specified service type depends on.
        /// </summary>
        /// <param name="serviceType">The service type to find dependencies for.</param>
        /// <returns>A collection of service types that the specified type depends on.</returns>
        IEnumerable<Type> GetDependencies(Type serviceType);
    }

    /// <summary>
    /// Represents a node in a service dependency graph.
    /// </summary>
    public interface IDependencyGraphNode
    {
        /// <summary>
        /// Gets the service type represented by this node.
        /// </summary>
        Type ServiceType { get; }

        /// <summary>
        /// Gets the service descriptor associated with this node.
        /// </summary>
        IServiceDescriptor Descriptor { get; }

        /// <summary>
        /// Gets the depth of this node in the dependency graph.
        /// </summary>
        int Depth { get; }

        /// <summary>
        /// Gets metadata associated with this node.
        /// </summary>
        IMetadata Metadata { get; }

        /// <summary>
        /// Gets a value indicating whether this node is part of a circular dependency.
        /// </summary>
        bool IsPartOfCircularDependency { get; }
    }

    /// <summary>
    /// Represents an edge (dependency relationship) in a service dependency graph.
    /// </summary>
    public interface IDependencyGraphEdge
    {
        /// <summary>
        /// Gets the source node of this dependency edge.
        /// </summary>
        IDependencyGraphNode From { get; }

        /// <summary>
        /// Gets the target node of this dependency edge.
        /// </summary>
        IDependencyGraphNode To { get; }

        /// <summary>
        /// Gets the type of dependency relationship.
        /// </summary>
        DependencyType DependencyType { get; }

        /// <summary>
        /// Gets metadata associated with this dependency edge.
        /// </summary>
        IMetadata Metadata { get; }

        /// <summary>
        /// Gets a value indicating whether this edge is part of a circular dependency.
        /// </summary>
        bool IsPartOfCircularDependency { get; }
    }

    /// <summary>
    /// Represents the type of dependency relationship between services.
    /// </summary>
    public enum DependencyType
    {
        /// <summary>Direct constructor parameter dependency.</summary>
        Constructor = 0,

        /// <summary>Property injection dependency.</summary>
        Property = 1,

        /// <summary>Method injection dependency.</summary>
        Method = 2,

        /// <summary>Factory method parameter dependency.</summary>
        Factory = 3,

        /// <summary>Decorator dependency.</summary>
        Decorator = 4,

        /// <summary>Interceptor dependency.</summary>
        Interceptor = 5,

        /// <summary>Optional dependency that may not be resolved.</summary>
        Optional = 6
    }

    /// <summary>
    /// Provides services for validating dependency injection configurations.
    /// </summary>
    public interface IServiceValidator
    {
        /// <summary>
        /// Validates all services in the specified registry.
        /// </summary>
        /// <param name="registry">The service registry to validate.</param>
        /// <param name="options">The validation options to use.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous validation operation.</returns>
        Task<IResult> ValidateAsync(IServiceRegistry registry, ServiceValidationOptions? options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Validates a specific service descriptor and its dependencies.
        /// </summary>
        /// <param name="descriptor">The service descriptor to validate.</param>
        /// <param name="registry">The service registry containing all registrations.</param>
        /// <param name="options">The validation options to use.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous validation operation.</returns>
        Task<IResult> ValidateServiceAsync(IServiceDescriptor descriptor, IServiceRegistry registry, ServiceValidationOptions? options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Analyzes the dependency graph for the specified service type.
        /// </summary>
        /// <param name="serviceType">The service type to analyze.</param>
        /// <param name="registry">The service registry containing all registrations.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous analysis operation.</returns>
        Task<IServiceDependencyGraph> AnalyzeDependenciesAsync(Type serviceType, IServiceRegistry registry, CancellationToken cancellationToken = default);
    }
}
