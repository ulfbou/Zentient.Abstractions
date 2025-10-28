// <copyright file="IValidationContext.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Execution;
using Zentient.Abstractions.Validation.Definitions;

namespace Zentient.Abstractions.Validation
{
    /// <summary>
    /// Represents the contextual information and state for a single validation operation.
    /// </summary>
    /// <remarks>
    /// This context is typically pushed onto the stack of an <see cref="IExecutionScope"/>
    /// and holds validation options, metadata, and a reference to the active validator.
    /// It is a passive data container, but its lifecycle is managed by the execution scope.
    /// </remarks>
    public interface IValidationContext : IHasMetadata, IHasParent<IValidationContext>
    {
        /// <summary>
        /// Gets the type definition of the primary validator associated with this context.
        /// </summary>
        IValidationDefinition ValidatorType { get; }

        /// <summary>Gets the input object currently being validated.</summary>
        object? Input { get; }

        /// <summary>
        /// Gets a value indicating whether the validation is currently in a successful state.
        /// </summary>
        bool IsSuccessful { get; }
    }
}
