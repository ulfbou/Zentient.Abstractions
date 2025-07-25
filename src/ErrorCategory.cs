// <copyright file="ErrorCategory.cs" company="Zentient Framework Team">
// Copyright Â© 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents semantic categories for errors, providing strong typing for common types of failures
    /// that occur within any domain or application layer. These categories are designed to be
    /// broadly applicable across various system architectures and transport mechanisms.
    /// This enum is strictly domain-centric and transport-agnostic.
    /// </summary>
    /// <remarks>
    /// Mapping to transport-specific codes (HTTP, gRPC, Messaging, etc.) should be handled externally.
    /// The ErrorInfo.Code and ErrorInfo.Detail properties should be used
    /// for more granular, specific error identification within these broader categories.
    /// </remarks>
    public enum ErrorCategory
    {
        /// <summary>No specific error category. Default for uninitialized or success scenarios.</summary>
        None = 0,

        // --- General / Unclassified Error ---

        /// <summary>A general, uncategorized error. Use when no other specific category applies.</summary>
        General,

        // --- Client / Input Related Errors ---

        /// <summary>Input data is malformed, missing, or fails basic structural validation rules.</summary>
        /// <remarks>This typically relates to the syntactical correctness and completeness of the provided data.</remarks>
        Validation,

        /// <summary>The client's request or operation is semantically incorrect, illogical for the current context, or cannot be processed due to a fundamental misunderstanding of the domain's expected state or sequence of operations.</summary>
        /// <remarks>This category covers issues where the request is "bad" beyond simple data validation, indicating a client-side semantic error.</remarks>
        BadRequest,

        /// <summary>Authentication failed, meaning the identity of the caller could not be established (e.g., missing, invalid, or expired credentials).</summary>
        Authentication,

        /// <summary>Authorization failed, meaning the authenticated caller lacks the necessary permissions to perform the requested operation on a specific resource.</summary>
        Authorization,

        // --- Domain / Business Logic Related Errors ---

        /// <summary>The requested resource or entity was not found in the system's data store or context.</summary>
        /// <remarks>This applies when a specific identified entity cannot be located.</remarks>
        NotFound,

        /// <summary>A conflict occurred during an operation, typically when attempting to create a resource that already exists, or when the current state of a resource prevents the operation (e.g., optimistic concurrency violation, unique constraint violation, resource locked).</summary>
        Conflict,

        /// <summary>A violation of core business rules, domain invariants, or application-specific constraints occurred.</summary>
        /// <remarks>This is distinct from 'Validation' (input format) and 'Conflict' (state conflicts), focusing on domain-specific policy violations.</remarks>
        BusinessRule,

        /// <summary>The requested operation or feature is conceptually valid within the domain but is not implemented or supported in the current version/configuration of the system.</summary>
        NotImplemented,

        // --- System / Infrastructure Related Errors ---

        /// <summary>An unexpected internal error occurred within the application's runtime or core infrastructure that is not directly attributable to client input or a specific business rule violation.</summary>
        /// <remarks>This typically signifies a bug, an unhandled infrastructure issue, or a critical system component failure.</remarks>
        InternalError,

        /// <summary>An error related to an external dependency or service failing, or an issue communicating with it.</summary>
        /// <remarks>This includes failures with databases, external APIs, message brokers, file storage, caches, etc.</remarks>
        ExternalDependency,

        /// <summary>A timeout occurred during an operation, indicating it did not complete within a specified time limit, typically due to a slow dependency or complex computation.</summary>
        Timeout,

        /// <summary>The system or a specific service is temporarily unavailable or operating under severe constraints (e.g., overloaded, undergoing maintenance, out of capacity).</summary>
        /// <remarks>This suggests a transient condition where retrying later might succeed.</remarks>
        ServiceUnavailable,

        /// <summary>A security violation detected beyond standard authentication/authorization failures, such as data tampering, policy breaches, or suspicious activity.</summary>
        SecurityViolation
    }
}
