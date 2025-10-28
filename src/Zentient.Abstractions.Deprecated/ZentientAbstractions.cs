// <copyright file="ZentientAbstractions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

// This file provides type aliases in the root namespace for enhanced Developer Experience
// Developers can access core types through a single `using Zentient.Abstractions;` statement

namespace Zentient.Abstractions
{
    // Core Definition Types - The "What" pillar
    using ITypeDefinition = Common.Definitions.ITypeDefinition;
    using IIdentifiable = Common.IIdentifiable;
    using IHasName = Common.IHasName;
    using IHasVersion = Common.IHasVersion;
    using IHasDescription = Common.IHasDescription;
    using IHasCategory = Common.IHasCategory;
    using IHasMetadata = Common.IHasMetadata;
    
    // Zentient Core Interface - The unified framework entry point
    using IZentient = Common.IZentient;

    // Code and Error Types - Structured outcomes
    using ICodeDefinition = Codes.Definitions.ICodeDefinition;
    using IErrorDefinition = Errors.Definitions.IErrorDefinition;
    using ErrorSeverity = Errors.ErrorSeverity;

    // Core Context Types - Runtime execution context
    using IContextDefinition = Contexts.Definitions.IContextDefinition;

    // Metadata Management
    using IMetadata = Metadata.IMetadata;

    // Results Pattern
    using IResult = Results.IResult;
}

// Convenience namespace for commonly used builders - The "Wiring" pillar
namespace Zentient.Abstractions.Builders
{
    // DI Container Building - Non-generic interfaces only
    using IContainerBuilder = DependencyInjection.Builders.IContainerBuilder;
    
    // Note: Generic builder interfaces (IServiceRegistrationBuilder<T>, IEnvelopeBuilder<T,U>, ICodeBuilder<T>)
    // are available through their full namespace paths when specific type parameters are needed
}

// Convenience namespace for validation and diagnostics - The "Health" pillar
namespace Zentient.Abstractions.Health
{
    // Validation
    using IValidationContext = Validation.IValidationContext;
    using IValidationCodeDefinition = Validation.Definitions.IValidationCodeDefinition;
    using IValidationErrorDefinition = Validation.Definitions.IValidationErrorDefinition;
    
    // Diagnostics
    using IDiagnosticContext = Diagnostics.IDiagnosticContext;
    using IDiagnosticCheckDefinition = Diagnostics.Definitions.IDiagnosticCheckDefinition;
    using DiagnosticStatus = Diagnostics.DiagnosticStatus;
}
