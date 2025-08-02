// <copyright file="IValidatorType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Validation
{
    /// <summary>Represents a type definition for a validator.</summary>
    /// <remarks>
    /// This interface is used to uniquely identify and describe a specific validator.
    /// It is a first-class entity in the Zentient type system.
    /// </remarks>
    public interface IValidationType : ITypeDefinition { }
}
