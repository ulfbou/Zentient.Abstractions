// <copyright file="IObservabilityProvider.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Observability.Metrics;
using Zentient.Abstractions.Observability.Tracing;

namespace Zentient.Abstractions.Observability.Providers
{
    /// <summary>Central factory for obtaining logger, tracer, and meter instances.</summary>
    public interface IObservabilityProvider
    {
        /// <summary>Gets a context-aware logger for <typeparamref name="TContexTDefinition"/>.</summary>
        ILogger<TContexTDefinition> GetLogger<TContexTDefinition>() 
            where TContexTDefinition : IContexTDefinition;

        /// <summary>Gets a context-aware tracer for <typeparamref name="TContexTDefinition"/>.</summary>
        ITracer<TContexTDefinition> GetTracer<TContexTDefinition>()
            where TContexTDefinition : IContexTDefinition;

        /// <summary>Gets a shared meter for recording metrics.</summary>
        IMeter GetMeter();
    }
}
