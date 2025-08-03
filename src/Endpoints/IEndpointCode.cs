using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Endpoints.Definitions;

namespace Zentient.Abstractions.Endpoints
{
    /// <summary>
    /// Represents a canonical, symbolic code that describes the semantic meaning of an endpoint outcome
    /// to an API consumer, independent of transport-specific numeric codes (e.g., HTTP status codes).
    /// </summary>
    /// <remarks>
    /// This is a specialized <see cref="ICode{IEndpoinTCodeDefinition}"/>. This ensures strong typing
    /// and consistency within the Zentient code system.
    /// </remarks>
    public interface IEndpointCode : ICode<IEndpointCodeDefinition>
    { }
}
