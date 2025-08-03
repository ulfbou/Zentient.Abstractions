// <copyright file="ICacheKeyDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Results;

namespace Zentient.Abstractions.Caching.Definitions
{
    /// <summary>Represents a type definition for a cache key.</summary>
    /// <remarks>
    /// This allows cache keys to be identified and managed as first-class citizens.
    /// </remarks>
    public interface ICacheKeyDefinition : ITypeDefinition { }
}
