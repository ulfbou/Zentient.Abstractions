// <copyright file="IPolicyOptionsType{out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;

namespace Zentient.Abstractions.Policies
{
    /// <summary>Represents a policy options type that provides strongly-typed access to option values.</summary>
    /// <typeparam name="TValue">The type of the value provided by the options.</typeparam>
    public interface IPolicyOptionsType<out TValue> : IPolicyOptionsType, IOptionsType<TValue>
    { }
}
