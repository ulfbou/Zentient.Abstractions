// <copyright file="IRelationAwareEnvelope{out TRelationType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Marker interface for envelopes that are explicitly tied to a specific <see cref="IRelationType"/>.
    /// </summary>
    /// <typeparam name="TRelationType">The specific relation type this envelope is associated with.</typeparam>
    /// <remarks>
    /// This allows for compile-time enforcement of relationships between the code and context
    /// contained within the envelope, when such a relationship is explicitly defined.
    /// </remarks>
    public interface IRelationAwareEnvelope<out TRelationType>
        where TRelationType : IRelationType
    {
        /// <summary>Gets the relation type associated with this envelope.</summary>
        /// <value>The relation type that defines the relationship of this envelope.</value>
        TRelationType RelationType { get; }
    }
}
