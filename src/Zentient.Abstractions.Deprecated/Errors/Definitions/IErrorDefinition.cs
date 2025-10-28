// <copyright file="IErrorDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;

using Zentient.Abstractions.Common.Definitions; 

namespace Zentient.Abstractions.Errors.Definitions
{
    /// <summary>
    /// Represents the definition of a specific type of error, inheriting from <see cref="ITypeDefinition"/>.
    /// </summary>
    /// <remarks>
    /// This interface categorizes and defines errors, providing intrinsic properties like severity,
    /// transient status, and user visibility that are integral to the nature of the error type.
    /// It stands as a distinct type definition, separate from general operational codes.
    /// </remarks>
    public interface IErrorDefinition : ITypeDefinition
    {
        /// <summary>Gets a value indicating the severity level of this error type.</summary>
        ErrorSeverity Severity { get; }

        /// <summary>
        /// Gets a value indicating whether this error type is transient, implying a retry might succeed.
        /// </summary>
        bool IsTransient { get; }

        /// <summary>
        /// Gets a value indicating whether this error type's details are suitable for direct display to an end-user.
        /// </summary>
        bool IsUserFacing { get; }
    }
}
