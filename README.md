# Zentient.Abstractions

[![NuGet Version](https://img.shields.io/nuget/v/Zentient.Abstractions.svg)](https://www.nuget.org/packages/Zentient.Abstractions)
[![.NET](https://img.shields.io/badge/.NET-6.0%20%7C%207.0%20%7C%208.0-blue.svg)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

> ⚠️ **CRITICAL - 3.0.0 BREAKING CHANGES**  
> **This is a complete rewrite** with massive breaking changes from 2.x versions.  
> **📚 REQUIRED READING**: [Migration Guide](MIGRATION_GUIDE_2.x_to_3.0.md) before upgrading.  
> **New Projects**: Continue reading below for the modern 3.0 architecture.

**Zentient.Abstractions 3.0** is the foundational library for the Zentient Framework, providing comprehensive abstractions that enable the **four-pillar architecture** for building robust, extensible, and protocol-agnostic applications. This major release introduces a unified framework core with enhanced developer experience and enterprise-grade capabilities.

## 🏗️ Four-Pillar Architecture

Zentient Framework 3.0 is built upon four interconnected pillars that ensure consistency, discoverability, and robust error handling:

### 1. 🧩 **Definition-Centric Core (The "What")**
Everything in the framework is self-describing through the `ITypeDefinition` interface and composed `IHas...` contracts. This metadata layer enables runtime discovery, categorization, and component wiring.

### 2. ✉️ **Universal Envelope (The "How")**
All operations return standardized `IEnvelope<TCode, TError>` results, providing consistent success/failure communication with rich error information, codes, and metadata.

### 3. 🏗️ **Fluent DI & Application Builder (The "Wiring")**
The powerful `IContainerBuilder` serves as the composition root, offering fluent APIs for dependency injection, module management, assembly scanning, and application validation.

### 4. 🩺 **Built-in Observability (The "Health")**
First-class diagnostic and validation systems through `IDiagnosticCheck` and `IValidator` interfaces, with results flowing through the universal envelope pattern.

## 🚀 Getting Started

Install Zentient.Abstractions 3.0 into your .NET project:

```bash
dotnet add package Zentient.Abstractions
```

**Supported Frameworks:** .NET 6.0, .NET 7.0, .NET 8.0, and .NET 9.0

### Quick Start Example

```csharp
using Zentient.Abstractions;
using Zentient.Abstractions.Builders;

// Build the complete Zentient application core
var zentient = await new ContainerBuilder()
    .RegisterFromAssemblies(Assembly.GetExecutingAssembly())
    .AddModule<MyApplicationModule>()
    .ConfigureValidationOnRegistration(true)
    .BuildZentientAsync();

// Access all framework systems through unified interface
var orderService = zentient.Services.Resolve<IOrderService>();
var validator = zentient.Validators.GetValidator<CreateOrderRequest, 
    OrderValidationCodeDefinition, 
    OrderValidationErrorDefinition>();
var diagnostics = zentient.GetDiagnosticRunner<
    SystemHealthCodeDefinition, 
    SystemHealthErrorDefinition>();
```

## ✨ Key Features & Interfaces

### **Core Framework Interface**
- **`IZentient`**: Unified entry point providing access to all framework systems
- **`IContainerBuilder`**: Comprehensive DI container with advanced features
- **Enhanced DX**: Global using directives and convenience namespaces

### **Definition-Centric Types**
- **`ITypeDefinition`**: Rich metadata for all framework components
- **`IIdentifiable`**: Unique identification system
- **`IHas...` Interfaces**: Composable capability contracts (Name, Version, Description, etc.)

### **Universal Envelopes**
- **`IEnvelope<TCodeDefinition, TErrorDefinition>`**: Standardized operation results
- **`IHeaderedEnvelope`**: Protocol-agnostic header support
- **`IStreamableEnvelope`**: Support for streaming scenarios

### **Observability & Validation**
- **`IValidator<TIn, TCodeDefinition, TErrorDefinition>`**: Type-safe validation
- **`IDiagnosticCheck<TSubject, TCodeDefinition, TErrorDefinition>`**: Health monitoring
- **`IDiagnosticRunner`**: Coordinated diagnostic execution

### **Configuration & Options**
- **`IConfiguration`**: Flexible configuration management
- **`ITypedConfiguration<TOptionsDefinition, TValue>`**: Strongly-typed options
- **`IConfigurationBinder`**: Dynamic configuration binding

### **Supporting Types**
- **`ICode<TCodeDefinition>`**: Structured, protocol-agnostic codes
- **`IErrorInfo<TErrorDefinition>`**: Rich error information
- **`IContext<TContextDefinition>`**: Hierarchical execution context
- **`IMetadata`**: Extensible key-value metadata system

## 🎯 Developer Experience Enhancements

### **Simplified Namespace Usage**
```csharp
// Single import for most scenarios
using Zentient.Abstractions;

// Specialized imports only when needed
using Zentient.Abstractions.Builders;    // For advanced building
using Zentient.Abstractions.Health;      // For health & validation
```

### **Enhanced Debugging**
- **Source Link Integration**: Step-through debugging into framework source
- **Rich Documentation**: Comprehensive IntelliSense support
- **Symbol Packages**: Enhanced debugging experience

### **Enterprise Features**
- **Assembly Scanning**: Automatic service discovery
- **Module System**: Organized service registration
- **Conditional Registration**: Environment-aware configuration
- **Advanced Patterns**: Decorators, interceptors, and policies

## 🏛️ Architectural Benefits

### **Protocol Agnostic**
Design core logic independently of transport protocols (HTTP, gRPC, Messaging)

### **Type Safety**
Strongly-typed definitions and generic constraints ensure compile-time correctness

### **Testability**
Decoupled interfaces and unified result patterns promote comprehensive testing

### **Consistency**
Universal envelope pattern and definition-centric design ensure predictable behavior

### **Extensibility**
Composable interfaces and metadata system support diverse application requirements

## 📊 What's New in 3.0.0

### **Major Architectural Improvements**
- ✨ **IZentient Interface**: Unified framework entry point
- 🏗️ **Enhanced Container Builder**: Advanced DI capabilities with validation
- 🎯 **Four-Pillar Architecture**: Complete framework foundation
- 📦 **Improved Package Metadata**: Enhanced discoverability and debugging

### **Developer Experience Enhancements**
- 🚀 **Global Using Directives**: Reduced namespace imports
- 📝 **Rich Documentation**: Comprehensive XML documentation
- 🔗 **Source Link Support**: Enhanced debugging experience
- 🎨 **Convenience Namespaces**: Streamlined access patterns

### **Breaking Changes**
- Moved from 2.x envelope patterns to comprehensive 3.0 architecture
- Enhanced type definitions with richer metadata support
- Unified service resolution through IZentient interface

See [CHANGELOG.md](CHANGELOG.md) for complete details.

## 💡 Example Use Cases

### **Building Applications**
```csharp
var app = await new ContainerBuilder()
    .RegisterFromCallingAssembly()
    .AddModule<CoreModule>()
    .AddModule<DataModule>()
    .ConfigureValidationOnRegistration(true)
    .BuildZentientAsync();
```

### **Validation**
```csharp
var validator = zentient.Validators.GetValidator<CustomerDto, 
    CustomerValidationCodeDefinition, 
    CustomerValidationErrorDefinition>();

var result = await validator.Validate(customerData);
if (!result.IsSuccess)
{
    foreach (var error in result.Errors)
        Console.WriteLine($"Validation error: {error.Message}");
}
```

### **Health Monitoring**
```csharp
var diagnostics = zentient.GetDiagnosticRunner<
    ServiceHealthCodeDefinition,
    ServiceHealthErrorDefinition>();

var healthReport = await zentient.PerformHealthCheckAsync<
    SystemHealthCodeDefinition,
    SystemHealthErrorDefinition>();
```

    ```csharp
    public interface IEndpointCode
    {
        string Name { get; }
        int? Numeric { get; }
        string? Protocol { get; }
    }
    ```

  * **`IMetadata`**: A flexible interface for attaching structured contextual metadata as key-value pairs to various entities (e.g., `IContext`, `IEnvelope`). It supports type-safe retrieval of tags.

    ```csharp
    public interface IMetadata
    {
        IReadOnlyCollection<string> Keys { get; }
        IReadOnlyCollection<object> Values { get; }
        bool TryGetTag<TValue>(string key, out TValue? value);
        IMetadata WithTag<TValue>(string key, TValue value);
    }
    ```

  * **`IPolicy<T>`**: Defines a contract for applying cross-cutting concerns or retry logic to operations that produce a result of type `T`.

    ```csharp
    public interface IPolicy<T>
    {
        Task<T> Execute(Func<CancellationToken, Task<T>> operation, CancellationToken cancellationToken = default);
    }
    ```

  * **`IFormatter<TIn, TOut>`**: A generic interface for transforming one type of value into another, useful for data serialization, deserialization, or mapping.

    ```csharp
    public interface IFormatter<in TIn, TOut>
    {
        Task<TOut> Format(TIn input, CancellationToken cancellationToken = default);
    }
    ```

  * **`Unit`**: A lightweight, singleton value type used to represent the absence of a specific value in generic contexts, similar to `void` in C\# or `null` but as a concrete, serializable type. It's particularly useful in functional programming patterns where a generic type parameter is required but no meaningful data needs to be conveyed.

    ```csharp
    public readonly struct Unit : IEquatable<Unit>, IComparable, IComparable<Unit>
    {
        public static Unit Value { get; } // Singleton instance
        // ... operators and methods for equality, comparison, serialization
    }
    ```

## 💡 Why Use Zentient.Abstractions?

  * **Protocol Agnostic:** Design your core logic independently of specific transport protocols (HTTP, gRPC, Messaging).
  * **Structured Outcomes:** Standardize how operations report success, failure, and associated information, moving beyond exceptions for expected business flows. This is fundamental to how libraries like **Zentient.Results** operate.
  * **Extensibility:** Provides interfaces that can be easily implemented and extended to fit diverse application requirements.
  * **Testability:** Decoupled interfaces promote easier unit testing of business logic.
  * **Consistency:** Enforces a consistent approach to common application concerns across your codebase, **serving as the common language for all Zentient Framework components.**

## 🤝 Contributing

We welcome contributions! Please visit our [GitHub Repository](https://github.com/ulfbou/Zentient.Abstractions) for the latest source code, issues, and contribution guidelines.

## 📄 License

Zentient.Abstractions is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

**Zentient Framework 3.0** - Building the future of .NET applications with consistency, discoverability, and exceptional developer experience.
