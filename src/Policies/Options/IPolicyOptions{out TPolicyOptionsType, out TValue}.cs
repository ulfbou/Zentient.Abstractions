// <copyright file="IPolicyOptions{out TPolicyOptionsType, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;

namespace Zentient.Abstractions.Policies.Options
{
    /// <summary>
    /// Represents a set of policy options, linked to its policy type definition.
    /// </summary>
    /// <typeparam name="TPolicyOptionsType">
    /// The type of the policy option definition (must implement <see cref="IPolicyOptionsType"/>).
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The concrete type of the policy option values.
    /// </typeparam>
    public interface IPolicyOptions<out TPolicyOptionsType, out TValue>
        : IOptions<TPolicyOptionsType, TValue>
        where TPolicyOptionsType : IPolicyOptionsType<TValue>
    { }
}