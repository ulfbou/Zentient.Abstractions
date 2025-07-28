using Zentient.Abstractions.Endpoints.Relations;
using Zentient.Abstractions.Errors;

namespace Zentient.Abstractions.Relations.Builders
{
    /// <summary>Specialized builder for endpoint relations, exposing severity.</summary>
    /// <typeparam name="TRelationType">The specific type of endpoint relation.</typeparam>
    public interface IEndpointRelationTypeBuilder<out TRelationType>
        : IRelationTypeBuilder<TRelationType>
        where TRelationType : IEndpointRelationType
    {
        /// <summary>Sets the error‐severity associated with this endpoint relation.</summary>
        /// <param name="severity"> The severity level to assign.</param>
        /// <returns> The current builder instance for fluent chaining.</returns>
        IEndpointRelationTypeBuilder<TRelationType> WithSeverity(ErrorSeverity severity);
    }
}
