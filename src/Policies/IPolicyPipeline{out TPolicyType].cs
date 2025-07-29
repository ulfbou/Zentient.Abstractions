// <copyright file="IPolicyPipeline{out TPolicyType].cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Policies
{
    /// <summary>Represents a pipeline of policies of a specific type.</summary>
    /// <typeparam name="TPolicyType">The type of policy in the pipeline, must implement <see cref="IPolicyType"/>.</typeparam>
    /// <remarks>
    /// A policy pipeline allows multiple policies to be composed and executed in sequence.
    /// </remarks>
    public interface IPolicyPipeline<out TPolicyType> : IPolicy<TPolicyType>
        where TPolicyType : IPolicyType
    {
        /// <summary>Gets the ordered list of policies in the pipeline.</summary>
        /// <value>The collection of policies in the pipeline.</value>
        IReadOnlyList<IPolicy<IPolicyType>> Policies { get; }
    }
}
