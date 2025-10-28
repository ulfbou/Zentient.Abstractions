// <copyright file="IHasParent{out TParent}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Represents an entity that has a hierarchical parent.
    /// </summary>
    /// <typeparam name="TParent">The type of the parent entity.</typeparam>
    /// <remarks>
    /// This interface is useful for modeling hierarchical structures, such as nested contexts,
    /// where an entity can trace its lineage back to a root.
    /// </remarks>
    public interface IHasParent<out TParent>
    {
        /// <summary>
        /// Gets the parent entity, if one exists.
        /// </summary>
        /// <value>The parent entity, or <see langword="null"/> if this is a root entity.</value>
        TParent? Parent { get; }
    }
}
