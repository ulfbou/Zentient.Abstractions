// <copyright file="ICode{out TCodeType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Common;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Codes
{
    /// <summary>
    /// Represents a strongly-typed operational code instance.
    /// </summary>
    /// <typeparam name="TCodeType">The specific <see cref="ICodeDefinition"/> that defines this code.</typeparam>
    /// <remarks>
    /// An <see cref="ICode{TCodeType}"/> instance represents a specific, categorized outcome or state
    /// within a domain. Its definition (<typeparamref name="TCodeType"/>) provides semantic meaning
    /// and core metadata about the code.
    /// </remarks>
    public interface ICode<out TCodeType> : IHasMetadata
        where TCodeType : ICodeDefinition
    {
        /// <summary>
        /// Gets the specific <see cref="ICodeDefinition"/> definition associated with this code instance.
        /// </summary>
        TCodeType Definition { get; }
    }
}
