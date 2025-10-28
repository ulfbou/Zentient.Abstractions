// <copyright file="IValidatorRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Zentient.Abstractions.Validation.Definitions;

namespace Zentient.Abstractions.Validation.Registry
{
    /// <summary>
    /// Provides a registry for discovering and retrieving validator type definitions.
    /// </summary>
    public interface IValidatorRegistry
    {
        /// <summary>
        /// Attempts to retrieve a validator type definition by its unique identifier.
        /// </summary>
        /// <typeparam name="TValidationDefinition">
        /// The specific type of the validation definition.
        /// </typeparam>
        /// <param name="validatorTypeId">The unique identifier of the validator type.</param>
        /// <param name="definition">
        /// When this method returns, contains the validator type definition if found;
        /// otherwise, the default value.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the validator type definition was found;
        /// otherwise, <see langword="false"/>.
        /// </returns>
#if NETSTANDARD2_0
        bool TryGet<TValidationDefinition>(
        string validatorTypeId,
        [NotNullWhen(true)] out TValidationDefinition? definition)
            where TValidationDefinition : IValidationDefinition;
#else
        bool TryGet<TValidationDefinition>(
        string validatorTypeId,
        [MaybeNullWhen(false)] out TValidationDefinition? definition)
            where TValidationDefinition : IValidationDefinition;
#endif

        /// <summary>
        /// Gets a read-only collection of all registered validator type definitions.
        /// </summary>
        IReadOnlyCollection<IValidationDefinition> AllDefinitions { get; }
    }
}
