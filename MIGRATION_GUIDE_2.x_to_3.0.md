# 🚀 Migration Guide: Zentient.Abstractions 2.x → 3.0.0

> ⚠️ **CRITICAL**: This is a **COMPLETE REWRITE** with massive breaking changes. 
> This guide is essential for all existing 2.x users.

## 🚨 Breaking Changes Overview

Zentient.Abstractions 3.0.0 is a **ground-up rewrite** introducing:
- Complete namespace reorganization
- New type-safe definition-based architecture  
- Generic interfaces with type parameters
- Hierarchical file structure (20+ directories)
- 200+ new abstractions vs 21 in 2.x

## 📋 What Changed

### 1. **Namespace Structure** - BREAKING CHANGE

#### 2.x Structure
```csharp
using Zentient.Abstractions;

// All types in single namespace
IEnvelope envelope;
ICode code;
IContext context;
```

#### 3.0.0 Structure  
```csharp
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Envelopes.Builders;

// Types organized in hierarchical namespaces
IEnvelope<TCodeDefinition, TErrorDefinition> envelope;
ICode<TCodeDefinition> code;
IContext<TContextDefinition> context;
```

### 2. **File Organization** - BREAKING CHANGE

#### 2.x File Structure (21 files)
```
src/
├── IEnvelope.cs
├── ICode.cs  
├── IContext.cs
├── IErrorInfo.cs
└── ... (17 more files in root)
```

#### 3.0.0 File Structure (200+ files)
```
src/
├── Envelopes/
│   ├── IEnvelope.cs
│   ├── Builders/
│   └── Definitions/
├── Codes/
│   ├── ICode{out TCodeType}.cs
│   ├── Builders/
│   └── Definitions/
├── Contexts/
│   ├── IContext{out TContextDefinition}.cs
│   └── ... (20+ more directories)
```

### 3. **Interface Signatures** - BREAKING CHANGE

#### 2.x Simple Interfaces
```csharp
public interface IEnvelope
{
    bool IsSuccess { get; }
    ICode? Code { get; }
    IReadOnlyCollection<string> Messages { get; }
    IMetadata Metadata { get; }
    IReadOnlyCollection<IErrorInfo> Errors { get; }
}

public interface ICode
{
    string Value { get; }
    string? Description { get; }
}
```

#### 3.0.0 Generic Definition-Based Interfaces
```csharp
public interface IEnvelope<TCodeDefinition, TErrorDefinition>
    where TCodeDefinition : ICodeDefinition
    where TErrorDefinition : IErrorDefinition
{
    bool IsSuccess { get; }
    ICode<TCodeDefinition>? Code { get; }
    IReadOnlyCollection<string> Messages { get; }
    IMetadata Metadata { get; }
    IReadOnlyCollection<IError<TErrorDefinition>> Errors { get; }
}

public interface ICode<out TCodeType> : ICode
    where TCodeType : ICodeDefinition
{
    TCodeType Definition { get; }
}
```

## 🔄 Migration Steps

### Step 1: Update Using Statements

#### Before (2.x)
```csharp
using Zentient.Abstractions;
```

#### After (3.0.0)
```csharp
// Add specific namespace imports
using Zentient.Abstractions.Envelopes;
using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Errors;

// OR use global usings (recommended)
using global::Zentient.Abstractions;  // Includes all via GlobalUsings.cs
```

### Step 2: Update Interface Implementations

#### Before (2.x)
```csharp
public class MyEnvelope : IEnvelope
{
    public bool IsSuccess { get; set; }
    public ICode? Code { get; set; }
    public IReadOnlyCollection<string> Messages { get; set; }
    public IMetadata Metadata { get; set; }
    public IReadOnlyCollection<IErrorInfo> Errors { get; set; }
}
```

#### After (3.0.0)
```csharp
public class MyEnvelope<TCodeDefinition, TErrorDefinition> 
    : IEnvelope<TCodeDefinition, TErrorDefinition>
    where TCodeDefinition : ICodeDefinition
    where TErrorDefinition : IErrorDefinition
{
    public bool IsSuccess { get; set; }
    public ICode<TCodeDefinition>? Code { get; set; }
    public IReadOnlyCollection<string> Messages { get; set; }
    public IMetadata Metadata { get; set; }
    public IReadOnlyCollection<IError<TErrorDefinition>> Errors { get; set; }
}

// Or use the non-generic version that still exists
public class SimpleEnvelope : IEnvelope
{
    // Same signature as 2.x - this interface still exists!
}
```

### Step 3: Update Factory Usage

#### Before (2.x)
```csharp
var envelope = envelopeFactory.CreateSuccess("Operation completed");
var code = codeFactory.Create("SUCCESS", "Operation succeeded");
```

#### After (3.0.0)
```csharp
// Using builders (new fluent API)
var envelope = new EnvelopeBuilder<MyCodeDefinition, MyErrorDefinition>()
    .WithSuccess()
    .WithMessage("Operation completed")
    .Build();

// Or using updated factories
var code = codeFactory.Create<MyCodeDefinition>("SUCCESS", "Operation succeeded");
```

## 🎯 Key Migration Strategies

### Strategy 1: **Gradual Migration** (Recommended)
1. Update using statements first
2. Keep using simple interfaces where possible
3. Gradually adopt generic interfaces for new code
4. Leverage `GlobalUsings.cs` for easier namespace management

### Strategy 2: **Full Rewrite** 
1. Adopt the complete definition-based architecture
2. Create custom definition types for your domain
3. Use fluent builders throughout
4. Take advantage of enhanced type safety

### Strategy 3: **Compatibility Layer**
1. Create extension methods that bridge 2.x patterns to 3.0
2. Maintain familiar APIs while using new underlying types
3. Gradually refactor over time

## 🛠️ Migration Tools

### Global Usings Helper
The new `GlobalUsings.cs` provides convenient access:
```csharp
// This file is automatically included in 3.0.0
global using Zentient.Abstractions;
global using Zentient.Abstractions.Envelopes;
global using Zentient.Abstractions.Codes;
global using Zentient.Abstractions.Contexts;
// ... all major namespaces
```

### Type Aliases
The `ZentientAbstractions.cs` provides helpful type aliases:
```csharp
// Convenient shortcuts for common patterns
using ZEnvelope = Zentient.Abstractions.Envelopes.IEnvelope;
using ZCode = Zentient.Abstractions.Codes.ICode;
```

## ⚠️ Common Migration Issues

### Issue 1: Compilation Errors
**Problem**: `CS0246` type not found errors
**Solution**: Add specific namespace using statements or use global usings

### Issue 2: Generic Type Parameter Requirements  
**Problem**: New interfaces require definition types
**Solution**: Use non-generic base interfaces for simple cases, or create definition types

### Issue 3: Builder Pattern Confusion
**Problem**: Factory methods no longer work the same way
**Solution**: Adopt fluent builder patterns or create compatibility extensions

## 📚 Migration Examples

### Complete Example: 2.x → 3.0.0

#### 2.x Implementation
```csharp
using Zentient.Abstractions;

public class UserService
{
    private readonly IEnvelopeFactory _envelopeFactory;
    
    public IEnvelope GetUser(int id)
    {
        try
        {
            var user = GetUserFromDatabase(id);
            return _envelopeFactory.CreateSuccess(user, "User found");
        }
        catch (Exception ex)
        {
            return _envelopeFactory.CreateError(ex.Message);
        }
    }
}
```

#### 3.0.0 Implementation (Option A: Simple)
```csharp
using Zentient.Abstractions;  // Global usings active

public class UserService
{
    private readonly IEnvelopeFactory _envelopeFactory;
    
    public IEnvelope GetUser(int id)
    {
        try
        {
            var user = GetUserFromDatabase(id);
            return _envelopeFactory.CreateSuccess(user, "User found");
        }
        catch (Exception ex)
        {
            return _envelopeFactory.CreateError(ex.Message);
        }
    }
}
```

#### 3.0.0 Implementation (Option B: Full Type Safety)
```csharp
using Zentient.Abstractions;
using Zentient.Abstractions.Envelopes.Builders;

public class UserService
{
    public IEnvelope<UserCodeDefinition, UserErrorDefinition> GetUser(int id)
    {
        try
        {
            var user = GetUserFromDatabase(id);
            return new EnvelopeBuilder<UserCodeDefinition, UserErrorDefinition>()
                .WithSuccess()
                .WithData(user)
                .WithMessage("User found")
                .Build();
        }
        catch (Exception ex)
        {
            return new EnvelopeBuilder<UserCodeDefinition, UserErrorDefinition>()
                .WithError(new UserError(ex.Message))
                .Build();
        }
    }
}
```

## 🎯 Recommended Migration Path

1. **Phase 1**: Update using statements and verify compilation
2. **Phase 2**: Replace factory usage with builders gradually  
3. **Phase 3**: Introduce definition types for enhanced type safety
4. **Phase 4**: Adopt full fluent patterns and advanced features

## 🆘 Getting Help

- **Documentation**: Check `docs/` directory for architectural guides
- **Examples**: See test projects for implementation patterns
- **Issues**: Report migration problems on GitHub
- **Community**: Join discussions for migration support

---

**Remember**: 3.0.0 is a **fundamental architectural shift**. Take time to understand the new patterns before migrating production code.
