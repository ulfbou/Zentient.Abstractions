// <copyright file="IValidator{in TIn, out TOut}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Validation.Registry
{
    /// <summary>
    /// Discovers and retrieves validation definitions (IValidationType).
    /// Parallels ITypeDefinitionRegistry / IFormatterRegistry patterns.
    /// </summary>
    public interface IValidatorRegistry
    {
        /// <summary>
        /// Attempts to find a validation definition by its identifier.
        /// </summary>
        bool TryGet<TValidationType>(string validatorTypeId, out TValidationType? definition)
            where TValidationType : IValidationType;

        /// <summary>
        /// All registered definitions for discovery and listing.
        /// </summary>
        IReadOnlyCollection<IValidationType> AllDefinitions { get; }
    }
}
