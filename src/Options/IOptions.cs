// <copyright file="IOptionsType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Options
{
    /// <summary>
    /// Represents a concrete instance of a set of options, linked to its type definition.
    /// </summary>
    /// <typeparam name="TOptionsType">The type of the option definition (e.g., MyServiceOptionsType).</typeparam>
    /// <typeparam name="TValue">The concrete type of the option values (e.g., MyServiceOptions).</typeparam>
    /// <remarks>
    /// This allows for strongly-typed access to option values while also providing metadata
    /// about the option set via its definition.
    /// </remarks>
    public interface IOptions<out TOptionsType, out TValue>
        where TOptionsType : IOptionsType<TValue>
    {
        /// <summary>Gets the type definition for this set of options.</summary>
        /// <value>The definition of the options type.</value>
        TOptionsType Definition { get; }

        /// <summary>Gets the actual option values.</summary>
        /// <value>The concrete values of the options.</value>
        TValue Value { get; }
    }
}
