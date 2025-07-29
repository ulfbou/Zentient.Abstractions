// <copyright file="IPolicyContextType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Options;

namespace Zentient.Abstractions.Policies
{
    /// <summary>Represents a context type specifically for policy execution.</summary>
    /// <remarks>
    /// Inherits from <see cref="IContextType"/> and provides a strongly-typed reference
    /// to the policy context type for advanced scenarios.
    /// </remarks>
    public interface IPolicyContextType : IContextType
    {
        /// <summary>Gets the <see cref="Type"/> representing the policy context.</summary>
        /// <value>The <see cref="Type"/> of the policy context.</value>
        Type PolicyContextType { get; }
    }
}
