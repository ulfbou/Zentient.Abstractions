# Contribution Guidelines

Thank you for your interest in contributing to this Zentient library! This document provides guidelines and information for contributors.

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Git
- Visual Studio Code (recommended) or Visual Studio
- Basic understanding of C# and .NET

### Development Setup

1. **Fork and Clone**
   ```bash
   git fork <repository-url>
   git clone <your-fork-url>
   cd <project-name>
   ```

2. **Install Dependencies**
   ```bash
   dotnet restore
   ```

3. **Verify Setup**
   ```bash
   dotnet build
   dotnet test
   ```

## Development Workflow

### Branching Strategy

- `main` - Stable release branch
- `develop` - Integration branch for features
- `feature/<name>` - Feature development
- `bugfix/<name>` - Bug fixes
- `hotfix/<name>` - Critical fixes for production

### Making Changes

1. **Create Feature Branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. **Make Changes**
   - Follow the coding standards
   - Add/update tests
   - Update documentation

3. **Test Changes**
   ```bash
   dotnet build
   dotnet test
   dotnet test --collect:"XPlat Code Coverage"
   ```

4. **Commit Changes**
   ```bash
   git add .
   git commit -m "feat: add your feature description"
   ```

5. **Push and Create PR**
   ```bash
   git push origin feature/your-feature-name
   ```

## Coding Standards

### Code Style

This project follows the Zentient coding standards:

- Use PascalCase for public members
- Use camelCase for private fields and local variables
- Use UPPER_CASE for constants
- Prefix private fields with underscore: `_fieldName`

### Naming Conventions

```csharp
// Classes and Interfaces
public class ExampleService { }
public interface IExampleService { }

// Methods and Properties
public string ProcessData(string input) { }
public string DataValue { get; set; }

// Private fields
private readonly string _connectionString;
private static readonly ILogger _logger;

// Constants
public const int MAX_RETRY_COUNT = 3;
private const string DEFAULT_CONFIG = "default";
```

### Documentation

All public APIs must have XML documentation:

```csharp
/// <summary>
/// Processes the input data and returns a result.
/// </summary>
/// <param name="input">The input data to process.</param>
/// <returns>A result containing the processed data or an error.</returns>
/// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
public IResult<string> ProcessData(string input)
{
    // Implementation
}
```

### Code Organization

```csharp
// File: ExampleService.cs
using System;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Results;

namespace YourLibrary.Services;

/// <summary>
/// Service class documentation.
/// </summary>
public class ExampleService : IIdentifiable
{
    // Constants first
    private const int DEFAULT_TIMEOUT = 30;
    
    // Static fields
    private static readonly ILogger _logger = LogManager.GetLogger<ExampleService>();
    
    // Instance fields
    private readonly string _connectionString;
    
    // Properties
    public string Id { get; } = Guid.NewGuid().ToString();
    
    // Constructors
    public ExampleService(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }
    
    // Public methods
    public IResult<string> ProcessData(string input)
    {
        // Implementation
    }
    
    // Private methods
    private bool ValidateInput(string input)
    {
        // Implementation
    }
}
```

## Testing Guidelines

### Test Structure

```csharp
namespace YourLibrary.Tests.Services;

public class ExampleServiceTests
{
    [Fact]
    public void ProcessData_WithValidInput_ReturnsSuccess()
    {
        // Arrange
        var service = new ExampleService("test-connection");
        var input = "test data";
        
        // Act
        var result = service.ProcessData(input);
        
        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("TEST DATA", result.Value);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ProcessData_WithInvalidInput_ReturnsError(string input)
    {
        // Arrange
        var service = new ExampleService("test-connection");
        
        // Act
        var result = service.ProcessData(input);
        
        // Assert
        Assert.True(result.IsFailure);
        Assert.NotNull(result.Error);
    }
}
```

### Test Coverage

- Aim for >90% code coverage
- Test both success and failure paths
- Include edge cases and boundary conditions
- Use descriptive test method names
- Group related tests in nested classes

### Performance Tests

```csharp
[Benchmark]
public string ProcessData_Performance()
{
    return _service.ProcessData("test input").Value;
}

[Fact]
public void ProcessData_PerformanceRequirement()
{
    // Test should complete within acceptable time
    var stopwatch = Stopwatch.StartNew();
    
    _service.ProcessData("test input");
    
    stopwatch.Stop();
    Assert.True(stopwatch.ElapsedMilliseconds < 100);
}
```

## Quality Requirements

### Code Analysis

All code must pass:
- Microsoft .NET analyzers
- StyleCop analysis
- Security analysis
- Custom Zentient analyzers

### Security

- No hardcoded secrets or credentials
- Validate all inputs
- Use secure cryptographic algorithms
- Follow OWASP guidelines

### Performance

- No memory leaks
- Efficient algorithms
- Proper resource disposal
- Baseline performance maintained

## Pull Request Process

### Before Submitting

1. **Ensure Tests Pass**
   ```bash
   dotnet test
   ```

2. **Check Code Quality**
   ```bash
   dotnet build -p:RunCodeAnalysis=true
   dotnet build -p:RunSecurityCodeAnalysis=true
   ```

3. **Update Documentation**
   - Update XML documentation
   - Update README if needed
   - Update CHANGELOG.md

4. **Format Code**
   ```bash
   dotnet format
   ```

### PR Requirements

- [ ] All tests pass
- [ ] Code coverage maintained/improved
- [ ] No analyzer warnings
- [ ] Documentation updated
- [ ] CHANGELOG.md updated
- [ ] Breaking changes documented

### PR Template

```markdown
## Description
Brief description of changes

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Breaking change
- [ ] Documentation update

## Testing
- [ ] Unit tests added/updated
- [ ] Integration tests added/updated
- [ ] Performance tests added/updated

## Checklist
- [ ] Code follows style guidelines
- [ ] Self-review completed
- [ ] Documentation updated
- [ ] Tests pass locally
- [ ] CHANGELOG.md updated
```

### Review Process

1. Automated checks run (CI/CD)
2. Code review by maintainers
3. Address feedback
4. Final approval and merge

## Release Process

### Version Numbers

We use [Semantic Versioning](https://semver.org/):
- MAJOR.MINOR.PATCH
- Breaking changes increment MAJOR
- New features increment MINOR
- Bug fixes increment PATCH

### Release Workflow

1. Create release branch from develop
2. Update version numbers
3. Update CHANGELOG.md
4. Create release PR to main
5. Tag release
6. Publish NuGet package

## Community

### Communication

- Use GitHub Issues for bug reports
- Use GitHub Discussions for questions
- Follow our Code of Conduct
- Be respectful and constructive

### Getting Help

- Check existing documentation
- Search existing issues
- Ask in GitHub Discussions
- Contact maintainers if needed

## Resources

- [Zentient.Abstractions Documentation](https://github.com/Zentient/Zentient.Abstractions)
- [.NET Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [xUnit Documentation](https://xunit.net/)
- [BenchmarkDotNet Documentation](https://benchmarkdotnet.org/)

Thank you for contributing to the Zentient ecosystem! 🚀
