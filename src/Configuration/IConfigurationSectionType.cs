// <copyright file="IConfigurationSectionType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Configuration
{
    /// <summary>Represents a type definition for a specific configuration section.</summary>
    /// <remarks>
    /// This is a non-generic marker interface that inherits from ITypeDefinition.
    /// It allows different configuration sections to be treated as first-class citizens.
    /// </remarks>
    public interface IConfigurationSectionType : ITypeDefinition { }
}
