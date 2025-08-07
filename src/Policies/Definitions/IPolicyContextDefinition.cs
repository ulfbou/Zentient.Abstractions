// <copyright file="IPolicyContextDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;
using Zentient.Abstractions.Options;

namespace Zentient.Abstractions.Policies.Definitions
{
    /// <summary>Represents a context type specifically for policy execution.</summary>
    /// <remarks>
    /// Inherits from <see cref="IContextDefinition"/> and provides a strongly-typed reference
    /// to the policy context type for advanced scenarios.
    /// </remarks>
    public interface IPolicyContextDefinition : IContextDefinition
    {
        /// <summary>Gets the <see cref="Type"/> representing the policy context.</summary>
        /// <value>The <see cref="Type"/> of the policy context.</value>
        Type PolicyContextType { get; }
    }
}
