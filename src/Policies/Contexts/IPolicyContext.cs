// <copyright file="IPolicyContext.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Policies.Definitions;

namespace Zentient.Abstractions.Policies.Contexts
{
    /// <summary>Represents a context for policy evaluation and execution.</summary>
    public interface IPolicyContext : IContext<IPolicyContextDefinition>, IHasName, IHasCorrelationId, IHasDescription
    {
        /// <summary>
        /// Gets the cancellation token for the current policy execution flow,
        /// allowing for cooperative cancellation.
        /// </summary>
        /// <value>The <see cref="CancellationToken"/> for the current operation.</value>
        CancellationToken CancellationToken { get; }
    }
}
