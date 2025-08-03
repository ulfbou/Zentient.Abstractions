// <copyright file="IConfigurationSectionDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Configuration.Definitions
{
    /// <summary>Represents a type definition for a specific configuration section.</summary>
    /// <remarks>
    /// This is a non-generic marker interface that inherits from ITypeDefinition.
    /// It allows different configuration sections to be treated as first-class citizens.
    /// </remarks>
    public interface IConfigurationSectionDefinition : ITypeDefinition 
    {
        /// <summary>Gets the type of the configuration source.</summary>
        Type SourceType { get; }
    }
}
