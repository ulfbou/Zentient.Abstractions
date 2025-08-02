// <copyright file="IHasCorrelationId.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Diagnostics
{
    /// <summary>Represents an entity that carries a correlation identifier.</summary>
    /// <remarks>
    /// A correlation ID is used to link together various operations, logs, and events
    /// that are part of a single logical request or business transaction across
    /// distributed systems.
    /// </remarks>
    public interface IHasCorrelationId
    {
        /// <summary>Gets the correlation identifier for the operation or entity.</summary>
        /// <value>A non-null, non-empty string representing the correlation ID.</value>
        string CorrelationId { get; }
    }
}
