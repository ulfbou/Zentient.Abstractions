﻿// <copyright file="IOptionsProvider.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright><copyright file="IOptionsProvider.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options.Definitions;

namespace Zentient.Abstractions.Options.Providers
{
    /// <summary>Provides access to configured option values at runtime.</summary>
    public interface IOptionsProvider
    {
        /// <summary>
        /// Retrieves an instance of options based on their Definition definition.
        /// </summary>
        /// <typeparam name="TOptionsDefinition">The type of the option definition.</typeparam>
        /// <typeparam name="TValue">The concrete type of the option values.</typeparam>
        /// <returns>
        /// An <see cref="IOptions{TOptionsDefinition, TValue}"/> instance representing the configured options, if it exists; 
        /// otherwise, <see langword="null" />.
        /// </returns>
        IOptions<TOptionsDefinition, TValue>? GetOptions<TOptionsDefinition, TValue>()
            where TOptionsDefinition : IOptionsDefinition;

        /// <summary>Retrieves an instance of options by its unique identifier.</summary>
        /// <typeparam name="TValue">The concrete type of the option values.</typeparam>
        /// <param name="OptionsDefinitionId">The unique identifier of the options type.</param>
        /// <param name="options">When found, the resulting options instance.</param>
        /// <returns><see langword="true" /> if the options were found; otherwise, <see langword="false" />.</returns>
        bool TryGetOptions<TValue>(string OptionsDefinitionId, out IOptions<IOptionsDefinition, TValue> options);
    }
}
