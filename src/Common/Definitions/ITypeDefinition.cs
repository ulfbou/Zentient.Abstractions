// <copyright file="ITypeDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Relations;

namespace Zentient.Abstractions.Common.Definitions
{
    /// <summary>
    /// The standard, rich metadata contract for a full-featured definition.
    /// This interface is the "golden standard" for most components in the framework,
    /// providing comprehensive properties for introspection and documentation.
    /// </summary>
    /// <remarks>
    /// This interface serves as a foundational contract for categorizing,
    /// identifying, and describing various concepts like code types, context types,
    /// relation types, and error types.
    /// </remarks>
    public interface ITypeDefinition :
    IIdentifiableDefinition,
    IHasName,
        IHasVersion,
        IHasDescription,
        IHasCategory,
        IHasRelation,
        IHasMetadata
    { }
}
