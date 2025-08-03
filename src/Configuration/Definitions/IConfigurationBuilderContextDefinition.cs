// <copyright file="IConfigurationBuilderContexTDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Contexts.Definitions;

namespace Zentient.Abstractions.Configuration.Definitions
{
    /// <summary>Represents the type definition for a configuration builder context.</summary>
    /// <remarks>
    /// Provides metadata about the context type, including the associated .NET <see cref="Type"/>.
    /// </remarks>
    public interface IConfigurationBuilderContexTDefinition : IContextDefinition
    {
        /// <summary>
        /// Gets the .NET <see cref="Type"/> that defines this configuration builder context type.
        /// </summary>
        /// <value>The <see cref="Type"/> representing the context type.</value>
        Type Type { get; }
    }
}
