// <copyright file="IHeaderedEnvelope{out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents a strongly typed envelope that can carry arbitrary key-value headers,
    /// in addition to a typed payload value and protocol-agnostic envelope properties.
    /// </summary>
    /// <typeparam name="TValue">The type of the payload value carried by the envelope.</typeparam>
    public interface IHeaderedEnvelope<out TValue> : IEnvelope<TValue>, IHeaderedEnvelope
    { }
}
