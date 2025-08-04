// <copyright file="IEndpointCodeDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Endpoints.Definitions
{
    /// <summary>
    /// Defines the metadata and semantic type for specific endpoint codes.
    /// This allows for categorizing and describing different types of endpoint outcomes.
    /// </summary>
    public interface IEndpointCodeDefinition : ICodeDefinition
    { }
}
