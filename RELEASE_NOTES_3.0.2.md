# Zentient.Abstractions 3.0.2

🛠️ **Build System & Framework Compatibility Enhancements**

> A patch release focused on improving multi-targeting support, refining build organization, and ensuring full compatibility with legacy frameworks like `netstandard2.0`.

## 🧱 Added

- **📁 Solution Folder: Builds**  
  Introduced a new `Builds` folder in the solution to organize shared build assets (`Directory.Build.props`, `.targets`), improving project clarity.

- **🛡️ Guard.cs Utility**  
  Added `Guard.cs` in `src/Common` for concise argument validation (`AgainstNull`, `AgainstNullOrEmpty`, etc.), replacing verbose `ArgumentNullException.ThrowIfNull` calls.

- **📦 Netstandard2.0 Shims**  
  Added `Netstandard2_0Shims.cs` to polyfill modern features (`NotNullWhen`, `ValueTask`) for legacy compatibility.

- **🧩 Interface Extensions for Legacy Support**  
  Introduced `_Extensions.cs` files for interfaces (`IEndpointOutcome`, `IEvent`, `IMessageEnvelope`, `IMetadataReader`, `IResult`, `IValidatorRegistry`) to avoid DIMs and ensure full functionality on `netstandard2.0`.

## 🔧 Changed

- **⚙️ Conditional Compilation**  
  Updated `Directory.Build.props` to conditionally define `DefineConstants` per target framework, enabling framework-specific logic at compile time.

- **📄 Project File Update**  
  Modified `Zentient.Abstractions.csproj` to include `netstandard2.0` in `TargetFrameworks`, officially supporting older .NET environments.

## 🏗️ Framework Support

- ✅ .NET Standard 2.0  
- ✅ .NET 6.0  
- ✅ .NET 7.0  
- ✅ .NET 8.0  
- ✅ .NET 9.0  

## 📦 Installation

```bash
dotnet add package Zentient.Abstractions --version 3.0.2
```

Or via Package Manager:

```powershell
Install-Package Zentient.Abstractions -Version 3.0.2
```

## 🔗 Links

- 📚 [API Documentation](https://ulfbou.github.io/Zentient.Abstractions/)  
- 📝 [Full Changelog](https://github.com/ulfbou/Zentient.Abstractions/blob/main/CHANGELOG.md)  
- 🐛 [Report Issues](https://github.com/ulfbou/Zentient.Abstractions/issues)

---

**Full Changelog**: https://github.com/ulfbou/Zentient.Abstractions/compare/v3.0.1...v3.0.2
