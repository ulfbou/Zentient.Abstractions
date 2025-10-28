// <copyright file="IPolicyPipelineBuilder{out TPolicyType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Policies.Definitions;

namespace Zentient.Abstractions.Policies.Builders
{
    /// <summary>Builder interface for constructing a policy pipeline.</summary>
    /// <typeparam name="TPolicyDefinition">The type of policy in the pipeline, must implement <see cref="IPolicyDefinition"/>.</typeparam>
    /// <remarks>
    /// Provides a fluent API for adding policies and metadata, and building the final pipeline.
    /// </remarks>
    public interface IPolicyPipelineBuilder<out TPolicyDefinition>
        where TPolicyDefinition : IPolicyDefinition
    {
        /// <summary>Adds a policy to the pipeline.</summary>
        /// <typeparam name="TAddedPolicyDefinition">The type of the policy to add.</typeparam>
        /// <param name="policy">The policy instance to add.</param>
        /// <returns>The current builder instance for chaining.</returns>
        IPolicyPipelineBuilder<TPolicyDefinition> Add<TAddedPolicyDefinition>(IPolicy<TAddedPolicyDefinition> policy)
            where TAddedPolicyDefinition : IPolicyDefinition;

        /// <summary>Conditionally adds a policy to the pipeline if the condition is true.</summary>
        /// <typeparam name="TAddedPolicyDefinition">The type of the policy to add.</typeparam>
        /// <param name="condition">If true, the policy is added.</param>
        /// <param name="factory">A factory function to create the policy instance.</param>
        /// <returns>The current builder instance for chaining.</returns>
        IPolicyPipelineBuilder<TPolicyDefinition> AddIf<TAddedPolicyDefinition>(
            bool condition,
            Func<IPolicy<TAddedPolicyDefinition>> factory)
            where TAddedPolicyDefinition : IPolicyDefinition;

        /// <summary>Adds or updates a metadata entry for the pipeline.</summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The current builder instance for chaining.</returns>
        IPolicyPipelineBuilder<TPolicyDefinition> WithMetadata(string key, object? value);

        /// <summary>Merges the provided metadata into the pipeline's metadata.</summary>
        /// <param name="metadata">The metadata to merge.</param>
        /// <returns>The current builder instance for chaining.</returns>
        IPolicyPipelineBuilder<TPolicyDefinition> WithMetadata(IMetadata metadata);

        /// <summary>Builds the policy pipeline.</summary>
        /// <returns>The constructed <see cref="IPolicyPipeline{TPolicyDefinition}"/> instance.</returns>
        IPolicyPipeline<TPolicyDefinition> Build();
    }
}
