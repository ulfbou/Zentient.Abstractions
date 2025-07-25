// <copyright file="IEndpointRelationType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents a specific relationship type for entities related to an 'Endpoint' concept.
    /// </summary>
    /// <remarks>
    /// This type is used to explicitly link endpoint-specific codes and contexts, enabling
    /// compile-time guarantees about their shared domain.
    /// </remarks>
    public interface IEndpointRelationType : IRelationType { }
}
