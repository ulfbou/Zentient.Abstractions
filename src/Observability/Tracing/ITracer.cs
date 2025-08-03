// <copyright file="ITracer.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Observability.Tracing
{
    /// <summary>Creates and manages tracing activities tied to a given context type.</summary>
    /// <typeparam name="TContextDefinition">
    /// The ambient context (e.g., service or component) associated with this tracer.
    /// </typeparam>
    public interface ITracer<out TContextDefinition>
        where TContextDefinition : IContextDefinition
    {
        /// <summary>Starts a new tracing activity/span.</summary>
        /// <param name="name">The operation or span name.</param>
        /// <param name="parentActivityId">Optional parent span identifier for cross-process linkage.</param>
        /// <param name="metadata">Optional tags or baggage entries to attach at start.</param>
        /// <returns>An <see cref="IActivity"/> representing the new span.</returns>
        IActivity StartActivity(
            string name,
            string? parentActivityId = null,
            IMetadata? metadata = null);
    }
}
