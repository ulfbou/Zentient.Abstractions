// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Errors
{
    /// <summary>
    /// Represents the definition of a specific type of error, inheriting from <see cref="ITypeDefinition"/>.
    /// </summary>
    /// <remarks>
    /// This interface categorizes and defines errors, providing intrinsic properties like severity,
    /// transient status, and user visibility that are integral to the nature of the error type.
    /// It stands as a distinct type definition, separate from general operational codes.
    /// </remarks>
    public interface IErrorType : ITypeDefinition
    {
        /// <summary>
        /// Gets a value indicating the severity level of this error type.
        /// </summary>
        ErrorSeverity Severity { get; }

        /// <summary>
        /// Gets a value indicating whether this error type is transient, implying a retry might succeed.
        /// </summary>
        bool IsTransient { get; }

        /// <summary>
        /// Gets a value indicating whether this error type's details are suitable for direct display to an end-user.
        /// </summary>
        bool IsUserFacing { get; }

        /// <summary>
        /// Gets the predefined "Not Found" error type.
        /// </summary>
        /// <remarks>Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType NotFound { get; }

        /// <summary>
        /// Gets the predefined "Invalid Argument" error type.
        /// </summary>
        /// <remarks>Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType InvalidArgument { get; }

        /// <summary>
        /// Gets the predefined "Unauthorized Access" error type.
        /// </summary>
        /// <remarks>Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType Unauthorized { get; }

        /// <summary>
        /// Gets the predefined "Forbidden Access" error type.
        /// </summary>
        /// <remarks>Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType Forbidden { get; }

        /// <summary>
        /// Gets the predefined "Bad Request" error type.
        /// </summary>
        /// <remarks>Represents client-side errors due to malformed request syntax, invalid request message framing, or deceptive request routing. Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType BadRequest { get; }

        /// <summary>
        /// Gets the predefined "Conflict" error type.
        /// </summary>
        /// <remarks>Indicates a request conflict with the current state of the target resource. Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType Conflict { get; }

        /// <summary>
        /// Gets the predefined "Unprocessable Entity" error type.
        /// </summary>
        /// <remarks>Means the server understands the content type of the request entity, and the syntax of the request entity is correct, but it was unable to process the contained instructions. Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType UnprocessableEntity { get; }

        /// <summary>
        /// Gets the predefined "Too Many Requests" error type.
        /// </summary>
        /// <remarks>The user has sent too many requests in a given amount of time ("rate limiting"). Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType TooManyRequests { get; }

        /// <summary>
        /// Gets the predefined "Internal Server Error" type.
        /// </summary>
        /// <remarks>Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType InternalError { get; }

        /// <summary>
        /// Gets the predefined "Service Unavailable" error type.
        /// </summary>
        /// <remarks>Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType ServiceUnavailable { get; }

        /// <summary>
        /// Gets the predefined "Gateway Timeout" error type.
        /// </summary>
        /// <remarks>Requires .NET 9.0+ for static abstract members.</remarks>
        static abstract IErrorType GatewayTimeout { get; }

        // Future: Additional common error types can be added here
    }
}