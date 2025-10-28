// <copyright file="IContexTDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Contexts.Definitions
{
    /// <summary>
    /// Defines a category or type for a specific context.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="ITypeDefinition"/> to provide metadata for the context category itself,
    /// such as unique identification and description.
    /// </remarks>
    public interface IContextDefinition : ITypeDefinition { }
}
