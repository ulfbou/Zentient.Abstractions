// <copyright file="ConfigurationBuilderTests.cs" company="LIBRARY_COMPANY">
// Copyright © 2025 LIBRARY_COMPANY. All rights reserved.
// </copyright>

namespace Zentient.LibraryTemplate.Tests;

/// <summary>
/// Tests for <see cref="ConfigurationBuilder"/> class.
/// </summary>
public class ConfigurationBuilderTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithEmptyValues()
    {
        // Act
        var builder = new ConfigurationBuilder();

        // Assert
        builder.Name.Should().Be(string.Empty);
        builder.Description.Should().Be(string.Empty);
        builder.Metadata.Should().BeEmpty();
    }

    [Fact]
    public void WithName_ShouldSetName()
    {
        // Arrange
        var builder = new ConfigurationBuilder();
        const string expectedName = "Test Configuration";

        // Act
        var result = builder.WithName(expectedName);

        // Assert
        result.Should().BeSameAs(builder); // Should return the same instance for fluent API
        builder.Name.Should().Be(expectedName);
    }

    [Fact]
    public void WithDescription_ShouldSetDescription()
    {
        // Arrange
        var builder = new ConfigurationBuilder();
        const string expectedDescription = "Test description";

        // Act
        var result = builder.WithDescription(expectedDescription);

        // Assert
        result.Should().BeSameAs(builder); // Should return the same instance for fluent API
        builder.Description.Should().Be(expectedDescription);
    }

    [Fact]
    public void FluentConfiguration_ShouldWorkCorrectly()
    {
        // Arrange
        const string expectedName = "Fluent Configuration";
        const string expectedDescription = "Built using fluent API";

        // Act
        var builder = new ConfigurationBuilder()
            .WithName(expectedName)
            .WithDescription(expectedDescription);

        // Assert
        builder.Name.Should().Be(expectedName);
        builder.Description.Should().Be(expectedDescription);
    }

    [Fact]
    public void WithMetadata_ShouldAddMetadataKeyValue()
    {
        // Arrange
        var builder = new ConfigurationBuilder();
        const string key = "environment";
        const string value = "development";

        // Act
        var result = builder.WithMetadata(key, value);

        // Assert
        result.Should().BeSameAs(builder); // Fluent interface
        builder.Metadata.Should().ContainKey(key);
        builder.Metadata[key].Should().Be(value);
    }

    [Fact]
    public void IsValid_ShouldReturnFalse_WhenNameOrDescriptionMissing()
    {
        // Arrange & Act & Assert
        new ConfigurationBuilder().IsValid().Should().BeFalse(); // Empty
        new ConfigurationBuilder().WithName("Test").IsValid().Should().BeFalse(); // Missing description
        new ConfigurationBuilder().WithDescription("Test").IsValid().Should().BeFalse(); // Missing name
    }

    [Fact]
    public void IsValid_ShouldReturnTrue_WhenNameAndDescriptionSet()
    {
        // Arrange
        var builder = new ConfigurationBuilder()
            .WithName("TestConfig")
            .WithDescription("Test configuration");

        // Act & Assert
        builder.IsValid().Should().BeTrue();
    }

    [Fact]
    public void GetScope_ShouldReturnNull_WhenScopeNotSet()
    {
        // Arrange
        var builder = new ConfigurationBuilder();

        // Act & Assert
        builder.GetScope().Should().BeNull();
    }

    [Fact]
    public void GetScope_ShouldReturnScope_WhenScopeSetInMetadata()
    {
        // Arrange
        var builder = new ConfigurationBuilder();
        const string expectedScope = "application";

        // Act
        builder.WithMetadata("scope", expectedScope);

        // Assert
        builder.GetScope().Should().Be(expectedScope);
    }
}
