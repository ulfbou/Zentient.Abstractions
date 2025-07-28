// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Diagnostics;

namespace Zentient.Abstractions.Policies
{
    /// <summary>Represents a context for policy evaluation and execution.</summary>
    public interface IPolicyContext : IContext<IPolicyType>, IHasName, IHasCorrelationId, IHasDescription
    {
        /// <summary>
        /// Gets the cancellation token for the current policy execution flow,
        /// allowing for cooperative cancellation.
        /// </summary>
        /// <value>The <see cref="CancellationToken"/> for the current operation.</value>
        CancellationToken CancellationToken { get; }
    }
}
