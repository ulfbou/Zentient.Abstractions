// <copyright file="IRelationType.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Codes
{

    /// <summary>
    /// Defines a category or type for a specific code.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="ITypeDefinition"/> to provide metadata for the code category itself,
    /// such as unique identification and description.
    /// </remarks>
    public interface ICodeType : ITypeDefinition { }
}
