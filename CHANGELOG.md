# 🧾 CHANGELOG — Zentient.Abstractions

> All notable changes to this package will be documented in this file.  
> This project adheres to [Semantic Versioning](https://semver.org).

---

## 📦 [3.0.0] — 2025-01-XX

🚀 **Zentient Framework 3.0 - Four-Pillar Architecture & Enhanced Developer Experience**

> This major release introduces the refined four-pillar architecture that establishes Zentient as a comprehensive foundation for modern .NET applications. Building upon the solid abstractions of v2.x, this version focuses on exceptional developer experience, architectural clarity, and production-ready capabilities.

> ⚠️ **CRITICAL - MASSIVE BREAKING CHANGES**: This is a **complete rewrite** of the library requiring full migration from 2.x. See `MIGRATION_GUIDE_2.x_to_3.0.md` for essential migration instructions.

---

### 💥 Breaking Changes — Complete Architectural Rewrite

⚠️ **THIS IS NOT A COMPATIBLE UPGRADE** - Every 2.x implementation will require updates:

| Breaking Change | 2.x | 3.0.0 | Impact |
|---|---|---|---|
| **Namespace Structure** | `Zentient.Abstractions` (flat) | `Zentient.Abstractions.*` (hierarchical) | All using statements must change |
| **File Organization** | 21 files in `src/` root | 200+ files in organized directories | File references must be updated |
| **Interface Design** | Simple interfaces | Generic definition-based architecture | Interface implementations need type parameters |
| **Type System** | Basic types | Rich type-safe abstractions | Type constraints and definitions required |

### 📚 Migration Resources

* **`MIGRATION_GUIDE_2.x_to_3.0.md`** - **ESSENTIAL**: Complete migration guide with examples
* **Global Usings**: `GlobalUsings.cs` helps reduce namespace update effort  
* **Type Aliases**: `ZentientAbstractions.cs` provides convenient shortcuts
* **Compatibility**: Some simple interfaces preserved for easier migration

---

### 🏗️ Architecture Evolution — Four-Pillar Design

Zentient Framework 3.0 is built on four foundational pillars:

1. **Definition-Centric Core** - Type-safe, strongly-typed definitions for all domain concepts
2. **Universal Envelope** - Consistent, protocol-agnostic containers for all operations
3. **Fluent DI & Application Builder** - Intuitive service registration and application composition
4. **Built-in Observability** - Comprehensive diagnostics, health checks, and monitoring capabilities

### ✨ Added — Developer Experience & Framework Integration

| Feature | Description |
|---|---|
| **`IZentient`** | Unified, non-generic entry point providing access to all framework systems through clean generic methods |
| **Global Using Directives** | Comprehensive global usings in `GlobalUsings.cs` for enhanced development experience |
| **Convenience Namespaces** | Type aliases in `ZentientAbstractions.cs` for improved discoverability and shorter syntax |
| **Enhanced Container Builder** | Async-capable `BuildZentientAsync()` method for production-ready application composition |
| **Source Link Integration** | Full source debugging support with GitHub integration for enhanced debugging experience |

### ♻️ Enhanced — Project & Documentation

| Component | Improvements |
|---|---|
| **Multi-target Support** | Enhanced .NET 6.0, 7.0, 8.0 support with optimized configurations |
| **NuGet Package Metadata** | Professional package presentation with comprehensive metadata and Source Link |
| **XML Documentation** | Enhanced documentation generation with proper symbol support |
| **README.md** | Completely rewritten with four-pillar architecture explanation and comprehensive examples |
| **Code Analysis** | Enhanced analyzer integration with Zentient-specific rulesets |

### 🔧 Technical Improvements

* **Enhanced Generic Handling**: Improved type safety and generic method implementations across the framework
* **Async-First Design**: BuildZentientAsync and other async patterns for production scalability  
* **Clean Architecture**: Better separation of concerns with definition-centric approach
* **Protocol Agnostic**: Framework abstractions work seamlessly across different protocols and platforms

### 📘 Documentation & Examples

* **Getting Started Guide**: Simplified onboarding with clear examples and best practices
* **Architecture Overview**: Comprehensive explanation of the four-pillar design philosophy
* **Integration Examples**: Real-world usage patterns and integration approaches
* **Migration Guide**: Clear guidance for upgrading from v2.x to v3.0

---

> 🔖 **Zentient Framework 3.0** establishes the definitive foundation for building consistent, discoverable, and maintainable .NET applications with exceptional developer experience.

---

## 📦 [2.0.1] — 2025-07-17 (Hotfix)

💥 **Immediate Architectural Correction**

> This patch release addresses an architectural oversight in the newly released v2.0.0.
> While technically a breaking change, it is being released as a patch to immediately correct
> the intended placement of a core abstraction prior to widespread adoption of v2.0.0.
> Future breaking changes will strictly adhere to major version bumps.

---

### ♻️ Changed — Core Contracts & Refinements

* **`ErrorCategory`**:
    * **Breaking Change**: Relocated from `Zentient.Results` namespace to `Zentient.Abstractions` namespace.
        * **Impact**: Consumers must update their `using Zentient.Results;` statement to `using Zentient.Abstractions;` for `ErrorCategory`.
        * **Rationale**: `ErrorCategory` is a fundamental, protocol-agnostic primitive intended for the core abstraction layer, not a specific result implementation. Its correct placement in `Zentient.Abstractions` aligns with the framework's design principles.

---

### 📘 Documentation

* No changes to existing wiki pages required, as they already reflect the intended namespace for `ErrorCategory`.

---

> 🔖 This release ensures the foundational `ErrorCategory` abstraction is correctly placed within `Zentient.Abstractions`, solidifying the framework's core design.

---

## 📦 [2.0.0] — 2025-07-17

💥 **Major Overhaul & API Refinement**

> This version introduces a significantly expanded and refined set of core abstractions, enhancing flexibility, consistency, and support for advanced patterns like hierarchical contexts, structured errors, and composable policies. It includes breaking changes to core envelope contracts to improve protocol-agnosticism.

---

### ✨ Added — Core Contracts & Factories

| Interface           | Description                                                                                             |
|---------------------|---------------------------------------------------------------------------------------------------------|
| `ICode`             | Universal, protocol-agnostic code for operation outcomes with symbolic name and optional numeric value. |
| `ICodeFactory`      | Factory for creating `ICode` instances.                                                                 |
| `IContextFactory`   | Factory for creating root `IContext` instances and managing ambient context.                            |
| `IErrorInfo`        | Detailed, immutable information about an error, including category, code, message, and nested errors.   |
| `IErrorInfoFactory` | Factory for creating `IErrorInfo` instances, including from exceptions.                                 |
| `IEnvelopeFactory`  | Factory for creating various `IEnvelope` types (generic, headered, streamable).                         |
| `IHeaderedEnvelope` | Base contract for envelopes supporting arbitrary key-value headers (protocol-agnostic).                 |
| `IHeaderedEnvelope<TValue>` | Strongly-typed headered envelope for carrying operation result payloads.                        |
| `IMetadataFactory`  | Factory for creating `IMetadata` instances.                                                             |
| `IPolicyFactory`    | Factory for creating common policy instances (retry, circuit breaker, fallback).                        |
| `IStreamableEnvelope<TStream>` | Base contract for envelopes whose payload can be streamed.                                      |
| `IStreamableEnvelope<TStream, TValue>` | Strongly-typed streamable envelope containing both a stream payload and a value.        |

---

### ♻️ Changed — Core Contracts & Refinements

* **`IContext`**:
    * Added `Id`, `Parent`, `CorrelationId` properties for enhanced traceability and hierarchy.
    * `Metadata` property changed from nullable (`IMetadata?`) to non-nullable (`IMetadata`).
    * Introduced `CreateChild`, `WithMetadata`, `WithType`, and `Merge` methods for immutable context manipulation.
* **`IEnvelope`**:
    * `Code` property type changed from `IEndpointCode?` to the more general `ICode?`.
    * `Messages` property changed from nullable (`IReadOnlyCollection<string>?`) to non-nullable (`IReadOnlyCollection<string>`).
    * `Metadata` property changed from nullable (`IMetadata?`) to non-nullable (`IMetadata`).
    * Added new `Errors` property (`IReadOnlyCollection<IErrorInfo>`) for structured error reporting.
* **`IEnvelopeFactory`**:
    * Removed `isSuccess` parameter from `CreateEnvelope` methods, as success is now implicitly determined by the absence of errors.
* **`IPolicy<T>`**:
    * Renamed the `With` method to `CombineWith` for clearer semantic meaning when chaining policies.
    * Added `Fallback` method for defining fallback execution paths.
* **`ErrorCategory`**:
    * Relocated from `Zentient.Results` to `Zentient.Abstractions` for broader applicability.
    * Updated XML documentation to remove specific references to `ErrorInfo` properties, maintaining abstraction.
* **`IEnvelope<out TValue>`**:
    * Renamed from `IEnvelope2<out TValue>` to simplify the interface name.

---

### 🗑️ Removed — Deprecated Contracts

* `IEndpointCode`: Replaced by the more general and flexible `ICode` interface.

---

### 🛠️ Build & CI/CD

* **Build Properties (`Directory.Build.props`)**:
    * Enabled documentation file generation conditionally for non-test projects.
    * Removed redundant analyzer and StyleCop configurations.
    * Cleaned up unnecessary comments and simplified `SolutionDir` definition.
* **Package Targets (`Directory.Pack.targets`)**:
    * Removed duplicate package metadata properties, centralizing configuration.
* **Project File (`Zentient.Abstractions.csproj`)**:
    * Configured inclusion of `README.md` in the NuGet package.
    * Corrected the path for `AssemblyOriginatorKeyFile`.
* **Strong-Name Key (`Zentient.snk`)**: Added the strong-name key file to the repository.
* **CI/CD Workflow (`.github/workflows/release.yml`)**:
    * Implemented a comprehensive GitHub Actions pipeline for automated build, pack, and release.
    * Includes semantic versioning via GitVersion, artifact management, and automated publishing to NuGet.org and GitHub Releases.
    * Features robust release notes extraction from `CHANGELOG.md`.

---

### 📘 Documentation

* Extensive updates and additions to XML documentation for all new and modified interfaces, properties, and methods, ensuring clarity and adherence to the Zentient Framework's documentation standards.

---

> 🔖 This major release significantly enhances the foundational abstraction layer of the Zentient ecosystem, providing more powerful, consistent, and protocol-agnostic building blocks for modern distributed applications.

---

## 📦 [1.0.0] — 2025-07-15

🎉 **Initial Public Release**

> This version introduces the foundational, protocol-agnostic abstractions that underpin the Zentient Framework’s execution, context, envelope, and policy models.

---

### ✨ Added — Core Contracts

| Interface        | Description                                                                 |
|------------------|-----------------------------------------------------------------------------|
| `IContext`       | Immutable hierarchical runtime context with identity, correlation, and metadata. |
| `IMetadata`      | Immutable, strongly-typed key-value container for contextual metadata.      |
| `IEnvelope`      | Base contract for operation outcome encapsulation (success, error, metadata). |
| `IEnvelope<T>`   | Strongly-typed envelope for carrying operation result payloads.             |
| `IEndpointCode`  | Protocol-aware symbolic outcome code with name, numeric value, and protocol. |
| `IFormatter<TIn, TOut>` | Transform abstraction for value formatting across layers and transports. |
| `IPolicy<T>`     | Composable policy abstraction for encapsulating cross-cutting operational logic (e.g., retry, fallback). |

---

### 🧱 Added — Supporting Types

- **`Unit`**  
  Functional unit type representing an intentional absence of value, suitable for generic APIs and void-like operations.

- **`UnitJsonConverter`**  
  Custom System.Text.Json converter for proper serialization and deserialization of `Unit`.

---

### 📘 Documentation

- Full XML documentation added for all public contracts, properties, and methods.
- Follows the Zentient Framework documentation structure and developer-first principles.

---

### 🛡 Licensing

Released under copyright © 2025  
**Zentient Framework Team**

---

> 🔖 This release establishes the foundational abstraction layer for the Zentient ecosystem.  
> Designed for maximum composability, immutability, protocol-agnosticism, and testability across distributed applications.
