// <copyright file="IMessagingOptions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;

namespace Zentient.Abstractions.Messaging.Options
{
    /// <summary>
    /// Represents a set of messaging options, leveraging the corrected IOptions abstraction.
    /// </summary>
    /// <typeparam name="TOptionsType">The specific type definition for these options.</typeparam>
    /// <typeparam name="TValue">The concrete type of the options.</typeparam>
    public interface IMessagingOptions<out TOptionsType, out TValue> : IOptions<TOptionsType, TValue>
        where TOptionsType : IMessagingOptionsType
    { }
}
