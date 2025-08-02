// <copyright file="IConfigurationSourceType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Configuration
{
    /// <summary>Represents a type definition for a specific configuration source.</summary>
    /// <remarks>
    /// This is a non-generic marker interface that inherits from <see cref="ITypeDefinition"/>.
    /// It provides a strongly-typed, metadata-rich descriptor for a configuration source.
    /// </remarks>
    public interface IConfigurationSourceType : ITypeDefinition { }
}
