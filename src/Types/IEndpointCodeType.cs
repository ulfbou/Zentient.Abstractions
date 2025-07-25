// <copyright file="IEndpointCodeType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Defines a specific <see cref="ICodeType"/> that is associated with an endpoint relation.
    /// </summary>
    /// <remarks>
    /// Examples of codes using this type include HTTP status codes or gRPC status codes,
    /// providing a categorical link to endpoint-specific contexts.
    /// </remarks>
    public interface IEndpointCodeType : ICodeType, IEndpointRelationType { }
}
