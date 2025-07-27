// <copyright file="IEndpointCode.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents a canonical, symbolic code for interpreting endpoint outcome semantics, providing
    /// a structured way to convey status and type across different layers and protocols.
    /// </summary>
    public interface IEndpointCode
    {
        /// <summary>
        /// Gets a symbolic name for the code (e.g., "NotFound", "Success", "ValidationError").
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets an optional numeric representation (e.g., HTTP status code 404, a custom error code 13).
        /// </summary>
        int? Numeric { get; }

        /// <summary>
        /// Gets an optional protocol hint (e.g., "http", "grpc", "domain") indicating
        /// the context or origin of the code.
        /// </summary>
        string? Protocol { get; }
    }
}
