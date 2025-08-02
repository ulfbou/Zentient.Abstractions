// <copyright file="IMessage.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Diagnostics;

namespace Zentient.Abstractions.Messaging
{
    /// <summary>Represents the base contract for all messages within the framework.</summary>
    /// <remarks>
    /// All messages inherit from this abstraction, ensuring consistent
    /// handling of correlation and metadata.
    /// </remarks>
    public interface IMessage : IHasCorrelationId, IHasMetadata { }
}
