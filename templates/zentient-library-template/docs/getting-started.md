# Getting Started with Zentient.LibraryTemplate

This guide will help you get up and running with your new Zentient library project.

## Prerequisites

- .NET 8.0 SDK or later
- Visual Studio Code (recommended) or Visual Studio
- Git (for version control)

## Quick Start

### 1. Clone and Setup

```bash
# If you created this from the template, you're already ready!
# Otherwise, clone your repository:
git clone <your-repo-url>
cd <your-project-name>

# Restore dependencies
dotnet restore
```

### 2. Build and Test

```bash
# Build the solution
dotnet build

# Run tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

### 3. Development Workflow

The project includes comprehensive automation through Directory.*.* files:

```bash
# Full build with all checks
dotnet build -c Release

# Run code analysis
dotnet build -p:RunCodeAnalysis=true

# Run security scan
dotnet build -p:RunSecurityCodeAnalysis=true

# Generate documentation
dotnet build -p:GenerateDocumentation=true

# Create NuGet package
dotnet pack -c Release
```

## Project Structure

```
YourLibrary/
├── src/                           # Main library source code
│   ├── YourLibrary.csproj        # Main project file
│   ├── ExampleService.cs         # Example implementation (replace)
│   └── GlobalUsings.cs           # Global using statements
├── tests/                        # Unit tests
│   ├── YourLibrary.Tests.csproj  # Test project file
│   ├── ExampleServiceTests.cs    # Example tests (replace)
│   └── GlobalUsings.cs           # Test global usings
├── docs/                         # Documentation
│   └── getting-started.md        # This file
├── samples/                      # Code samples (auto-generated)
├── .vscode/                      # VS Code configuration
├── analyzers/                    # Code analysis rules
├── Directory.*.props             # Build configuration
├── Directory.*.targets           # Build automation
└── YourLibrary.sln              # Solution file
```

## Key Features

### 🏗️ **Build Automation**
- Multi-target framework support
- Automatic versioning
- NuGet package generation
- Source linking for debugging

### 🧪 **Testing Infrastructure**
- xUnit test framework
- Code coverage reporting
- Benchmark testing support
- Continuous testing with file watching

### 📊 **Code Quality**
- Microsoft analyzers
- StyleCop code style enforcement
- Security analysis
- API surface validation

### 🔐 **Security**
- Vulnerability scanning
- Dependency validation
- Cryptographic standards enforcement
- Security compliance checking

### 📚 **Documentation**
- XML documentation generation
- DocFX integration
- API documentation
- Code sample validation

### ⚡ **Performance**
- BenchmarkDotNet integration
- Memory analysis
- Performance regression detection
- Load testing capabilities

## Development Workflow

### VS Code (Recommended)

1. **Open in VS Code**: The project includes complete VS Code configuration
2. **Install Extensions**: VS Code will prompt to install recommended extensions
3. **Build**: Use `Ctrl+Shift+P` → "Tasks: Run Task" → "build"
4. **Test**: Use `Ctrl+Shift+P` → "Tasks: Run Task" → "test"
5. **Debug**: Use F5 to debug tests

### Command Line

```bash
# Watch for changes and rebuild
dotnet watch build

# Watch for changes and run tests
dotnet watch test

# Format code
dotnet format

# Clean build artifacts
dotnet clean
```

## Customization

### Replacing Example Code

1. **Update Project Names**: Replace `Zentient.LibraryTemplate` with your actual library name
2. **Replace ExampleService**: Implement your actual library functionality
3. **Update Tests**: Replace example tests with your actual test cases
4. **Update Documentation**: Modify README.md and docs/ with your library-specific information

### Configuration

Most settings can be customized through MSBuild properties:

```xml
<!-- In your .csproj or Directory.Build.props -->
<PropertyGroup>
  <EnableSigning>true</EnableSigning>
  <EnableTesting>true</EnableTesting>
  <EnableQuality>true</EnableQuality>
  <EnableSecurity>true</EnableSecurity>
  <EnableDocumentation>true</EnableDocumentation>
  <EnablePerformance>false</EnablePerformance>
</PropertyGroup>
```

## CI/CD Integration

The project is ready for CI/CD with:

- GitHub Actions workflows (if using GitHub)
- Azure DevOps pipelines (if using Azure DevOps)
- Docker containerization support
- Automated testing and quality checks

## Best Practices

### Code Organization

- Follow the existing namespace structure
- Implement interfaces from Zentient.Abstractions
- Use the IResult pattern for error handling
- Add comprehensive XML documentation

### Testing

- Maintain high test coverage (aim for >90%)
- Include both unit and integration tests
- Use descriptive test method names
- Follow the Arrange-Act-Assert pattern

### Documentation

- Document all public APIs
- Include code examples in XML comments
- Update CHANGELOG.md for each release
- Keep README.md current

### Performance

- Use BenchmarkDotNet for performance testing
- Monitor memory allocations
- Validate performance against baselines
- Profile regularly during development

## Troubleshooting

### Common Issues

**Build Errors**:
- Ensure .NET 8.0 SDK is installed
- Run `dotnet restore` to restore packages
- Check for syntax errors in .csproj files

**Test Failures**:
- Verify test project references are correct
- Check test method signatures
- Ensure test data is valid

**Package Issues**:
- Verify package metadata in Directory.Pack.props
- Check for missing dependencies
- Validate version numbers

### Getting Help

- Check the [Zentient.Abstractions documentation](https://github.com/Zentient/Zentient.Abstractions)
- Review the example implementations
- File issues in the project repository

## Next Steps

1. **Implement Your Library**: Replace the example code with your actual implementation
2. **Add Tests**: Write comprehensive tests for your functionality
3. **Update Documentation**: Customize the documentation for your specific library
4. **Configure CI/CD**: Set up continuous integration for your project
5. **Publish**: Create and publish your NuGet package

Happy coding! 🚀
