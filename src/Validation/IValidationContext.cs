// <copyright file="IValidator{in TIn, out TOut}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Validation
{
    /// <summary>
    /// Carries arbitrary metadata into a validator (e.g. locale, profiles, include/exclude lists).
    /// </summary>
    public interface IValidationContext : IHasMetadata
    { }
}
