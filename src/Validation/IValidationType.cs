// <copyright file="IValidator{in TIn, out TOut}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Validation
{
    /// <summary>
    /// Defines the metadata for a validation strategy: its unique identifier, version,
    /// description and any other introspection details.
    /// </summary>
    public interface IValidationType : ITypeDefinition
    { }
}
