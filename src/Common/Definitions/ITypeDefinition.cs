// <copyright file="ITypeDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Relations;

namespace Zentient.Abstractions.Common.Definitions
{
    /// <summary>
    /// Represents a base interface for all definition types within Zentient,
    /// combining identity, naming, versioning, and description.
    /// </summary>
    /// <remarks>
    /// This interface serves as a foundational contract for categorizing,
    /// identifying, and describing various concepts like code types, context types,
    /// relation types, and error types.
    /// </remarks>
    public interface ITypeDefinition : IIdentifiable, IHasName, IHasVersion, IHasDescription, IHasCategory, IHasRelation
    { }
}
