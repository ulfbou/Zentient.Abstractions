// <copyright file="IPolicyPipeline{out TPolicyDefinition].cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Policies.Definitions;

namespace Zentient.Abstractions.Policies
{
    /// <summary>Represents a pipeline of policies of a specific type.</summary>
    /// <typeparam name="TPolicyDefinition">The type of policy in the pipeline, must implement <see cref="IPolicyDefinition"/>.</typeparam>
    /// <remarks>
    /// A policy pipeline allows multiple policies to be composed and executed in sequence.
    /// </remarks>
    public interface IPolicyPipeline<out TPolicyDefinition> : IPolicy<TPolicyDefinition>
        where TPolicyDefinition : IPolicyDefinition
    {
        /// <summary>Gets the ordered list of policies in the pipeline.</summary>
        /// <value>The collection of policies in the pipeline.</value>
        IReadOnlyList<IPolicy<IPolicyDefinition>> Policies { get; }
    }
}
