// <copyright file="ConfigurationBuilder.cs" company="LIBRARY_COMPANY">
// Copyright © LIBRARY_COPYRIGHT. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Configuration;

namespace Zentient.LibraryTemplate;

/// <summary>
/// Example configuration builder demonstrating Zentient.Abstractions usage.
/// This shows how to implement common Zentient patterns for building configuration objects.
/// </summary>
public class ConfigurationBuilder : IHasName, IHasDescription
{
    private readonly Dictionary<string, object> _metadata = new();

    /// <inheritdoc />
    public string Name { get; private set; } = string.Empty;

    /// <inheritdoc />
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the metadata dictionary for this configuration.
    /// </summary>
    public IReadOnlyDictionary<string, object> Metadata => _metadata;

    /// <summary>
    /// Sets the name of the configuration.
    /// </summary>
    /// <param name="name">The configuration name.</param>
    /// <returns>The builder instance for method chaining.</returns>
    public ConfigurationBuilder WithName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
        return this;
    }

    /// <summary>
    /// Sets the description of the configuration.
    /// </summary>
    /// <param name="description">The configuration description.</param>
    /// <returns>The builder instance for method chaining.</returns>
    public ConfigurationBuilder WithDescription(string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        Description = description;
        return this;
    }

    /// <summary>
    /// Adds metadata to the configuration.
    /// </summary>
    /// <param name="key">The metadata key.</param>
    /// <param name="value">The metadata value.</param>
    /// <returns>The builder instance for method chaining.</returns>
    public ConfigurationBuilder WithMetadata(string key, object value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(value);

        _metadata[key] = value;
        return this;
    }

    /// <summary>
    /// Validates that the builder has the required configuration.
    /// </summary>
    /// <returns>True if the configuration is valid; otherwise, false.</returns>
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Name) &&
               !string.IsNullOrWhiteSpace(Description);
    }

    /// <summary>
    /// Gets the configuration scope if specified in metadata.
    /// </summary>
    /// <returns>The configuration scope or null if not specified.</returns>
    public string? GetScope()
    {
        return _metadata.TryGetValue("scope", out var scope) ? scope.ToString() : null;
    }
}
