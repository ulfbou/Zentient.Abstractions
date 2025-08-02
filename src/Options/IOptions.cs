// <copyright file="IOptionsType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Options
{
    /// <summary>Represents a set of options.</summary>
    /// <typeparam name="TOptionsType">The type definition for these options (e.g., MyServiceOptionsType).</typeparam>
    /// <typeparam name="TValue">The concrete type of the options values (e.g., MyServiceOptions).</typeparam>
    /// <remarks>
    /// This abstraction carries the generic type parameter for the value, not the IOptionsType.
    /// </remarks>
    public interface IOptions<out TOptionsType, out TValue>
        where TOptionsType : IOptionsType
    {
        /// <summary>Gets the type definition for the options.</summary>
        TOptionsType Definition { get; }

        /// <summary>Gets the concrete options value.</summary>
        TValue Value { get; }
    }
}
