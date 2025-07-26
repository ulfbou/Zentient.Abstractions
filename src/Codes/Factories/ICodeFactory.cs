// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Codes.Factories
{
    /// <summary>
    /// Factory for creating universal ICode instances.
    /// </summary>
    public interface ICodeFactory
    {
        /// <summary>
        /// Creates a new ICode instance with the specified name and optional value.
        /// </summary>
        /// <param name="name">The symbolic name of the code (e.g., "NotFound", "ValidationError").</param>
        /// <param name="value">An optional numeric value associated with the code (e.g., 404, 1001).</param>
        ICode CreateCode(string name, int? value = null);
    }
}
