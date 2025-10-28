// <copyright file="IPolicyDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Policies.Definitions
{
    /// <summary>Represents a policy type definition within the Zentient framework.</summary>
    /// <remarks>
    /// A policy type defines the structure or contract for a specific kind of policy,
    /// including its identity, name, description, and version information. This interface
    /// extends <see cref="ITypeDefinition"/> to ensure all policy types are consistently
    /// described and identifiable within the system.
    /// </remarks>
    public interface IPolicyDefinition : ITypeDefinition { }
}
