// <copyright file="IRelationType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Relations;

namespace Zentient.Abstractions.Endpoints.Relations
{
    /// <summary>
    /// Represents a specific relationship type for entities related to an 'Endpoint' concept.
    /// This type extends <see cref="IRelationType"/> and provides endpoint-specific attributes.
    /// </summary>
    /// <remarks>
    /// This type is used to explicitly link endpoint-specific codes and contexts, enabling
    /// compile-time guarantees about their shared domain and exposing properties like severity.
    /// </remarks>
    public interface IEndpointRelationType : IRelationType
    {
        /// <summary>
        /// Gets the severity level associated with this endpoint relation.
        /// This indicates the typical impact of an endpoint outcome that uses this relation type.
        /// </summary>
        ErrorSeverity Severity { get; }
    }
}
