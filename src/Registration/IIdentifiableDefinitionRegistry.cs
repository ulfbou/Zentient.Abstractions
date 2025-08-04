// <copyright file="IIdentifiableDefinitionRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Registration
{
    /// <summary>A specialized registry for definitions that are uniquely identifiable.</summary>
    public interface IIdentifiableDefinitionRegistry
    {
        /// <summary>Retrieves a definition by its unique identifier.</summary>
        /// <param name="id">The unique identifier of the definition.</param>
        /// <param name="ct">
        /// Cancellation token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing the identifiable
        /// definition if found, or <see langword="null"/> if not found.
        /// </returns>
        Task<IIdentifiableDefinition?> GetById(string id, CancellationToken ct = default);

        /// <summary>Registers an identifiable definition.</summary>
        /// <param name="def">The definition to register.</param>
        /// <param name="ct">
        /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete.
        /// </param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Register(IIdentifiableDefinition def, CancellationToken ct = default);
    }
}
