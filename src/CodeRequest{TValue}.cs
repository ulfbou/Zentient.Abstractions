// <copyright file="CodeRequest{TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// DTO for requesting creation of a code with strongly typed value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value associated with the code (e.g., int, string, Guid).</typeparam>
    public record CodeRequest<TValue>
    {
        /// <summary>
        /// Creates a new instance of <see cref="CodeRequest{TValue}"/>.
        /// This constructor is used to encapsulate the parameters needed to create a code.
        /// </summary>
        /// <param name="name">The symbolic name of the code (e.g., "NotFound", "ValidationError").</param>
        /// <param name="value">An optional strongly typed value associated with the code (e.g., 404, "Invalid input").</param>
        /// <param name="severity">Optional severity level for the code (e.g., Error, Warning, Info).</param>
        /// <param name="category">Optional error category for classification (e.g., Validation, NotFound).</param>
        /// <param name="description">Optional human-readable description of the code.</param>
        /// <param name="metadata">Optional extensible metadata for diagnostics or future use.</param>
        public CodeRequest(
            string name,
            TValue? value = default,
            ErrorSeverity? severity = null,
            ErrorCategory? category = null,
            string? description = null,
            IMetadata? metadata = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Code name cannot be null or whitespace.", nameof(name));
            }

            this.Name = name;
            this.Value = value;
            this.Severity = severity;
            this.Category = category;
            this.Description = description;
            this.Metadata = metadata;
        }

        /// <summary>Gets the symbolic name of the code.</summary>
        /// <value>The symbolic name of the code (e.g., "NotFound", "ValidationError").</value>
        public string Name { get; init; }

        /// <summary>Gets the optional strongly typed value associated with the code.</summary>
        /// <value>The optional value associated with the code (e.g., 404, "Invalid input").</value>
        public TValue? Value { get; init; }

        /// <summary>Gets the optional severity level for the code.</summary>
        /// <value>The severity level of the code (e.g., Error, Warning, Info).</value>
        public ErrorSeverity? Severity { get; init; }

        /// <summary>Gets the optional error category for classification.</summary>
        /// <value>The category of the error, providing additional context for diagnostics (e.g., Validation, NotFound).</value>
        public ErrorCategory? Category { get; init; }

        /// <summary>Gets the optional human-readable description of the code.</summary>
        /// <value>The description of the code, providing additional context or explanation.</value>
        public string? Description { get; init; }

        /// <summary>Gets the optional extensible metadata for diagnostics or future use.</summary>
        /// <value>
        /// The metadata associated with this code, which can include additional information such as 
        /// error codes, timestamps, or other relevant details.
        /// </value>
        public IMetadata? Metadata { get; init; }
    }
}
