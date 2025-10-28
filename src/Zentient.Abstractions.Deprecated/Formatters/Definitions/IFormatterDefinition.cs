// <copyright file="IFormatterDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Formatters.Definitions
{
    /// <summary>Represents a semantic, discoverable definition for a formatter implementation.</summary>
    /// <remarks>
    /// Inherits from <see cref="ITypeDefinition"/> to enable introspection,
    /// naming, versioning, and metadata description.
    /// </remarks>
    public interface IFormatterDefinition : ITypeDefinition
    {
        /// <summary>Gets the runtime input type this formatter accepts.</summary>
        Type InputType { get; }

        /// <summary>Gets the runtime output type this formatter produces.</summary>
        Type OutputType { get; }

        /// <summary>
        /// Gets a symbolic or display-friendly name for the formatting method or convention.
        /// </summary>
        string? FormatName { get; }
    }
}
