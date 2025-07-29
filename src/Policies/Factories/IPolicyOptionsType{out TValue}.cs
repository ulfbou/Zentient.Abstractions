// <copyright file="IPolicyOptionsType{out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;

namespace Zentient.Abstractions.Policies.Factories
{
    public interface IPolicyOptionsType<out TValue> : IOptionsType<TValue>
    { }
}