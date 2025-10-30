// <copyright file="IValue{out TValue}.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// A strongly-typed wrapper for a literal or value object that provides a name and description.
    /// </summary>
    /// <typeparam name="TValue">The CLR type of the wrapped value. Must be non-nullable.</typeparam>
    public interface IValue<out TValue> : IValue, INamed, IDescribed where TValue : notnull
    {
        /// <summary>
        /// Gets the wrapped literal value.
        /// </summary>
        TValue Value { get; }
    }
}
