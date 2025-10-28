// <copyright file="IEndpointRelationDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Endpoints.Definitions
{
    /// <summary>
    /// Defines the relation metadata for an endpoint, including error severity.
    /// </summary>
    public interface IEndpointRelationDefinition : IRelationDefinition
    {
        /// <summary>
        /// Gets the severity level associated with the endpoint relation.
        /// <para>
        /// The severity indicates the impact or criticality of the relation outcome.
        /// </para>
        /// <returns>
        /// An <see cref="ErrorSeverity"/> value representing the severity of the relation.
        /// </returns>
        /// </summary>
        ErrorSeverity Severity { get; }
    }
}
