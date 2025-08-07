// <copyright file="IScoped.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Configuration
{
    /// <summary>
    /// Represents an object that has a specific configuration scope.
    /// </summary>
    /// <remarks>
    /// This interface provides a standard way to associate configuration scope
    /// with objects, enabling proper hierarchy and precedence resolution.
    /// </remarks>
    public interface IScoped
    {
        /// <summary>
        /// Gets the configuration scope of the object.
        /// </summary>
        /// <value>The scope that determines configuration precedence and inheritance.</value>
        ConfigurationScope Scope { get; }
    }

    /// <summary>
    /// Represents an object that has a scoped value.
    /// </summary>
    /// <typeparam name="TValue">The type of the scoped value.</typeparam>
    public interface IScoped<out TValue> : IScoped
    {
        /// <summary>
        /// Gets the value associated with this scope.
        /// </summary>
        /// <value>The scoped value.</value>
        TValue Value { get; }
    }
}
