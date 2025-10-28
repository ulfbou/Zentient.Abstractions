// <copyright file="IPolicyOptions{out TPolicyOptionsDefinition, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;
using Zentient.Abstractions.Policies.Definitions;

namespace Zentient.Abstractions.Policies.Options
{
    /// <summary>
    /// Represents a set of policy options, linked to its policy type definition.
    /// </summary>
    /// <typeparam name="TPolicyOptionsDefinition">
    /// The type of the policy option definition (must implement <see cref="IPolicyOptionsDefinition"/>).
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The concrete type of the policy option values.
    /// </typeparam>
    public interface IPolicyOptions<out TPolicyOptionsDefinition, out TValue>
        : IOptions<TPolicyOptionsDefinition, TValue>
        where TPolicyOptionsDefinition : IPolicyOptionsDefinition
    { }
}
