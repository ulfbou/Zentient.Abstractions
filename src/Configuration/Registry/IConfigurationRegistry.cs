// <copyright file="IConfigurationRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Options;
using Zentient.Abstractions.Options.Definitions;
using Zentient.Abstractions.Validation;
using Zentient.Abstractions.Validation.Definitions;

namespace Zentient.Abstractions.Configuration.Registry
{
    /// <summary>
    /// Represents a registry that tracks all known configuration and options type definitions.
    /// </summary>
    /// <remarks>
    /// This registry is used for discovery and provides a centralized place for metadata,
    /// default values, and validation rules for strongly-typed configuration.
    /// </remarks>
    public interface IConfigurationRegistry
    {
        /// <summary>
        /// Gets a read-only collection of all registered options type definitions.
        /// </summary>
        IReadOnlyCollection<IOptionsDefinition> AllOptionsDefinitions { get; }

        /// <summary>
        /// Attempts to get an options type definition by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the options type.</param>
        /// <param name="definition">When found, contains the IOptionsDefinition definition.</param>
        /// <returns>True if the definition was found; otherwise, false.</returns>
        bool TryGeTOptionsDefinition(string id, out IOptionsDefinition? definition);

        /// <summary>
        /// Gets the default value for a given options type definition.
        /// </summary>
        /// <typeparam name="TValue">The concrete type of the options value.</typeparam>
        /// <param name="definition">The options type definition.</param>
        /// <returns>The default value for the options, or null if no default is specified.</returns>
        TValue? GetDefaultValue<TValue>(IOptionsDefinition definition);

        /// <summary>
        /// Gets the validator definition associated with a given options type.
        /// </summary>
        /// <param name="OptionsDefinition">The IOptionsDefinition to get the validator for.</param>
        /// <returns>The IValidationDefinition definition, or null if none is registered.</returns>
        IValidationDefinition? GetValidatorType(IOptionsDefinition OptionsDefinition);
    }
}
