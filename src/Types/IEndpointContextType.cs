// <copyright file="IEndpointContextType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Defines a specific <see cref="IContextType"/> that is associated with an endpoint relation.
    /// </summary>
    /// <remarks>
    /// Examples include HTTP request context or gRPC call context, providing a categorical link
    /// to endpoint-specific codes and operations.
    /// </remarks>
    public interface IEndpointContextType : IContextType, IEndpointRelationType { }
}
