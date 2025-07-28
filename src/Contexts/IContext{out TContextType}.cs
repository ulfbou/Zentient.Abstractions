// <copyright file="IContext{out TContextType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Diagnostics;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Contexts
{
    /// <summary>
    /// Represents a strongly-typed operational context instance.
    /// </summary>
    /// <typeparam name="TContextType">The specific <see cref="IContextType"/> that defines this context.</typeparam>
    /// <remarks>
    /// A context encapsulates ambient information relevant to an operation, providing
    /// environmental data, correlation IDs, and hierarchical relationships.
    /// </remarks>
    public interface IContext<out TContextType> : IHasMetadata, IHasParent<IContext<IContextType>>, IHasCorrelationId
        where TContextType : IContextType
    {
        /// <summary>
        /// Gets the specific <see cref="IContextType"/> definition associated with this context instance.
        /// </summary>
        TContextType Definition { get; }
    }
}
