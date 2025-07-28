// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Policies
{
    /// <summary>Represents a policy type definition within the Zentient framework.</summary>
    /// <remarks>
    /// A policy type defines the structure or contract for a specific kind of policy,
    /// including its identity, name, description, and version information. This interface
    /// extends <see cref="ITypeDefinition"/> to ensure all policy types are consistently
    /// described and identifiable within the system.
    /// </remarks>
    public interface IPolicyType : ITypeDefinition { }
    public interface IPolicyContextType : IContextType
    {
        /// <summary>
        /// Gets the type of the policy context.
        /// </summary>
        Type PolicyContextType { get; }
    }
    public interface IPolicyPipeline<out TPolicyType> : IPolicy<TPolicyType>
        where TPolicyType : IPolicyType
    {
        /// <summary>
        /// Gets a read-only list of the policies contained within this pipeline.
        /// This provides introspection capabilities for diagnostics and logging.
        /// The list can contain policies of various <see cref="IPolicyType"/> categories.
        /// </summary>
        IReadOnlyList<IPolicy<IPolicyType>> Policies { get; }
    }
    public interface IPolicyPipelineBuilder<out TPolicyType>
        where TPolicyType : IPolicyType
    {
        /// <summary>
        /// Adds a policy to the pipeline. Policies of any <see cref="IPolicyType"/> category can be added.
        /// </summary>
        /// <typeparam name="TAddedPolicyType">The type of the policy category being added.</typeparam>
        /// <param name="policy">The policy instance to add.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        IPolicyPipelineBuilder<TPolicyType> Add<TAddedPolicyType>(IPolicy<TAddedPolicyType> policy)
            where TAddedPolicyType : IPolicyType;

        /// <summary>
        /// Adds a policy to the pipeline only if the specified condition is true.
        /// The policy instance is created via the factory function only when needed.
        /// Policies of any <see cref="IPolicyType"/> category can be added.
        /// </summary>
        /// <typeparam name="TAddedPolicyType">The type of the policy category being added.</typeparam>
        /// <param name="condition">A boolean indicating whether to add the policy.</param>
        /// <param name="factory">A factory function to create the policy instance.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        IPolicyPipelineBuilder<TPolicyType> AddIf<TAddedPolicyType>(
            bool condition,
            Func<IPolicy<TAddedPolicyType>> factory)
            where TAddedPolicyType : IPolicyType;

        /// <summary>
        /// Adds metadata to the policy pipeline being built.
        /// This metadata will be associated with the resulting <see cref="IPolicyPipeline{TPolicyType}"/>.
        /// </summary>
        /// <param name="key">The key of the metadata tag.</param>
        /// <param name="value">The value of the metadata tag.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        IPolicyPipelineBuilder<TPolicyType> WithMetadata(string key, object? value);

        /// <summary>
        /// Merges an existing <see cref="IMetadata"/> instance into the pipeline's metadata.
        /// </summary>
        /// <param name="metadata">The metadata to merge.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        IPolicyPipelineBuilder<TPolicyType> WithMetadata(IMetadata metadata);

        /// <summary>
        /// Builds an immutable <see cref="IPolicyPipeline{TPolicyType}"/> instance based on the configured policies.
        /// </summary>
        /// <returns>A new, immutable <see cref="IPolicyPipeline{TPolicyType}"/>.</returns>
        IPolicyPipeline<TPolicyType> Build();
    }
    public interface IPolicyDescriptor : IHasName, IIdentifiable
    {
        /// <summary>
        /// Gets the <see cref="System.Type"/> of the policy implementation.
        /// </summary>
        Type ImplementationType { get; }

        /// <summary>
        /// Gets the <see cref="System.Type"/> of the policy category (e.g., IRetryPolicyType, ICircuitBreakerPolicyType)
        /// that this policy belongs to.
        /// </summary>
        Type PolicyCategoryType { get; }

        /// <summary>
        /// Gets a read-only view of the properties or metadata associated with this policy descriptor.
        /// This aligns with the IMetadataReader pattern for consistent metadata access.
        /// </summary>
        IMetadataReader Metadata { get; }
    }
    public interface IPolicyDescriptorRegistry
    {
        /// <summary>
        /// Registers a policy descriptor, making it discoverable by name and ID.
        /// </summary>
        /// <param name="descriptor">The policy descriptor to register.</param>
        void Register(IPolicyDescriptor descriptor);

        /// <summary>
        /// Retrieves all registered policy descriptors.
        /// </summary>
        /// <returns>A read-only collection of all registered policy descriptors.</returns>
        IReadOnlyCollection<IPolicyDescriptor> GetAll();

        /// <summary>
        /// Attempts to retrieve a policy descriptor by its name.
        /// </summary>
        /// <param name="name">The name of the policy descriptor.</param>
        /// <param name="descriptor">When this method returns, contains the policy descriptor if found; otherwise, null.</param>
        /// <returns>True if the policy descriptor was found; otherwise, false.</returns>
        bool TryGet(string name, [NotNullWhen(true)] out IPolicyDescriptor? descriptor);

        /// <summary>Retrieves a policy descriptor by its name.</summary>
        /// <param name="name">The name of the policy descriptor.</param>
        /// <returns>The policy descriptor if it exists; otherwise, <see langword="null"/>.</returns>
        IPolicyDescriptor? GetDescriptor(string name);

        /// <summary>
        /// Attempts to retrieve a policy descriptor by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the policy descriptor.</param>
        /// <param name="descriptor">When this method returns, contains the policy descriptor if found; otherwise, null.</param>
        /// <returns>True if the policy descriptor was found; otherwise, false.</returns>
        bool TryGetById(string id, [NotNullWhen(true)] out IPolicyDescriptor? descriptor);

        /// <summary>
        /// Retrieves a policy descriptor by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the policy descriptor.</param>
        /// <returns>The policy descriptor if it exists; otherwise, <see langword="null"/>.</returns>
        IPolicyDescriptor? GetById(string id);
    }
    public interface IPolicyFactory
    {
        /// <summary>
        /// Creates a policy instance for a specific policy type with a given configuration.
        /// This method is intended to be overloaded for different policy categories (e.g., Retry, Circuit Breaker).
        /// </summary>
        /// <typeparam name="TPolicyType">The specific policy category type (e.g., IRetryPolicyType).</typeparam>
        /// <param name="options">An object containing configuration options for the policy.</param>
        /// <returns>A new, configured instance of <see cref="IPolicy{TPolicyType}"/>.</returns>
        /// <remarks>
        /// Concrete implementations of IPolicyFactory will provide specific methods
        /// like CreateRetryPolicy(IRetryPolicyOptions options), CreateCircuitBreakerPolicy(ICircuitBreakerPolicyOptions options), etc.
        /// The generic parameter TPolicyType refers to the policy's category, not the result type of the action it wraps.
        /// </remarks>
        IPolicy<TPolicyType> CreatePolicy<TPolicyType>(object options)
            where TPolicyType : IPolicyType;
    }
}
