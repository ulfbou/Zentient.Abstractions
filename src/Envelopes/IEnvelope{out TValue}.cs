// <copyright file="IEnvelope2.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents a strongly typed envelope containing a data payload.
    /// </summary>
    public interface IEnvelope<out TValue> : IEnvelope
    {
        /// <summary>
        /// The optional payload value associated with the result.
        /// </summary>
        TValue? Value { get; }
    }
}
