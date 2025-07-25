// <copyright file="IPolicyType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>Marker interface for policy types, representing domain-specific policies.</summary>
    /// <remarks>
    /// Extends <see cref="ITypeDefinition"/> to provide metadata for policies such as
    /// business rules or authorization requirements.
    /// </remarks>
    public interface IPolicyType : ITypeDefinition
    { }
}
