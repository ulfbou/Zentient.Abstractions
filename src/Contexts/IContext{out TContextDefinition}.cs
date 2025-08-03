// <copyright file="IContext{out TContextDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Contexts
{
    /// <summary>
    /// Represents a strongly-typed operational context instance.
    /// </summary>
    /// <typeparam name="TContextDefinition">The specific <see cref="IContextDefinition"/> that defines this context.</typeparam>
    /// <remarks>
    /// A context encapsulates ambient information relevant to an operation, providing
    /// environmental data, correlation IDs, and hierarchical relationships.
    /// </remarks>
    public interface IContext<out TContextDefinition> : IHasMetadata, IHasParent<IContext<IContextDefinition>>, IHasCorrelationId
        where TContextDefinition : IContextDefinition
    {
        /// <summary>
        /// Gets the specific <see cref="IContextDefinition"/> definition associated with this context instance.
        /// </summary>
        TContextDefinition Definition { get; }
    }
}
