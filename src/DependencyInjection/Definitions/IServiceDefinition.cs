// <copyright file="IServiceDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.DependencyInjection.Definitions
{
    /// <summary>
    /// Represents a service definition in Zentient—carries Id, Name, Version, Description.
    /// This is a marker type for dependency injection.
    /// </summary>
    /// <remarks>
    /// The 'Definition' suffix is used to avoid ambiguity with the CLR type 'ServiceType'.
    /// </remarks>
    public interface IServiceDefinition : ITypeDefinition
    { }
}
