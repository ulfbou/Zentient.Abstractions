// <copyright file="IAddressable.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// A foundational composite contract combining identity, naming, description, and metadata.
    /// Use this when a concept must be addressable and self-describing.
    /// </summary>
    /// <typeparam name="TId">The type of the address/identifier.</typeparam>
    public interface IAddressable<out TId> : IIdentifiable<TId>, INamed, IDescribed, IHasMetadata where TId : notnull { }
}
