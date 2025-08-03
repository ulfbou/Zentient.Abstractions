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
        /// <summary>Gets a context-aware logger for <typeparamref name="TContextDefinition"/>.</summary>
        ILogger<TContextDefinition> GetLogger<TContextDefinition>() 
            where TContextDefinition : IContextDefinition;

        /// <summary>Gets a context-aware tracer for <typeparamref name="TContextDefinition"/>.</summary>
        ITracer<TContextDefinition> GetTracer<TContextDefinition>()
            where TContextDefinition : IContextDefinition;

        /// <summary>Gets a shared meter for recording metrics.</summary>
        IMeter GetMeter();
    }
}
