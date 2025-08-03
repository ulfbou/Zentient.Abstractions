// <copyright file="IOptions{out TOptionsDefinition, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options.Definitions;

namespace Zentient.Abstractions.Options
{
    /// <summary>Represents a set of options.</summary>
    /// <typeparam name="TOptionsDefinition">The type definition for these options (e.g., MyServiceOptionsDefinition).</typeparam>
    /// <typeparam name="TValue">The concrete type of the options values (e.g., MyServiceOptions).</typeparam>
    /// <remarks>
    /// This abstraction carries the generic type parameter for the value, not the IOptionsDefinition.
    /// </remarks>
    public interface IOptions<out TOptionsDefinition, out TValue>
        where TOptionsDefinition : IOptionsDefinition
    {
        /// <summary>Gets the type definition for the options.</summary>
        TOptionsDefinition Definition { get; }

        /// <summary>Gets the concrete options value.</summary>
        TValue Value { get; }
    }
}
