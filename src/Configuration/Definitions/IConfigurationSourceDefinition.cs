// <copyright file="IConfigurationSourceDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Configuration.Definitions
{
    /// <summary>Represents a type definition for a specific configuration source.</summary>
    /// <remarks>
    /// This is a non-generic marker interface that inherits from <see cref="ITypeDefinition"/>.
    /// It provides a strongly-typed, metadata-rich descriptor for a configuration source.
    /// </remarks>
    public interface IConfigurationSourceDefinition : ITypeDefinition { }
}
