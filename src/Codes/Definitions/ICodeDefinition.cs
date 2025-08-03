// <copyright file="ICodeDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Codes.Definitions
{
    /// <summary>
    /// Defines a category or type for a specific code.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="ITypeDefinition"/> to provide metadata for the code category itself,
    /// such as unique identification and description.
    /// </remarks>
    public interface ICodeDefinition : ITypeDefinition { }
}
