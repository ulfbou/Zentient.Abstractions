// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Generic code abstraction for domain-specific codes with a strongly typed value.
    /// </summary>
    /// <typeparam name="TCode">The code type, representing the domain or category of the code.</typeparam>
    /// <typeparam name="TValue">The strongly typed value associated with the code (e.g., int, string, Guid).</typeparam>
    public interface ICode<out TCode, out TValue> : ICode<TCode>
        where TCode : ICodeType
    {
        /// <summary>Domain-specific, strongly typed value (e.g., int, string, Guid).</summary>
        /// <value>The value associated with this code, providing additional context or detail.</value>
        TValue? Value { get; }
    }
}
