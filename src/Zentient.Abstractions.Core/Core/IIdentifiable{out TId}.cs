// <copyright file="IIdentifiable{out TId}.cs" authors="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Core
{
    /// <summary>
    /// Provides a unique, stable identity token of a specified type.
    /// </summary>
    /// <typeparam name="TId">The CLR type used for the identifier (for example, <see cref="System.Guid"/> or <see cref="string"/>).</typeparam>
    public interface IIdentifiable<out TId> : IIdentifiable where TId : notnull
    {
        /// <summary>
        /// Gets the unique identifier for this concept instance.
        /// </summary>
        TId Id { get; }
    }
}
