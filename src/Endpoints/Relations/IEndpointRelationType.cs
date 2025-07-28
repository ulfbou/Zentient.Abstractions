// <copyright file="IRelationType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Relations;

namespace Zentient.Abstractions.Endpoints.Relations
{
    /// <summary>
    /// Represents a specific relationship type for entities related to an 'Endpoint' concept.
    /// </summary>
    /// <remarks>
    /// This type is used to explicitly link endpoint-specific codes and contexts, enabling
    /// compile-time guarantees about their shared domain.
    /// </remarks>
    public interface IEndpointRelationType : IRelationType
    {
        ErrorSeverity Severity { get; }
    }
}
