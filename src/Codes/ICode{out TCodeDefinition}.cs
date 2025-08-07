// <copyright file="ICode{out TCodeDefinition}.cs" company="Zentient Framework Team">
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
    /// <typeparam name="TCodeDefinition">The specific <see cref="ICodeDefinition"/> that defines this code.</typeparam>
    /// <remarks>
    /// An <see cref="ICode{TCodeDefinition}"/> instance represents a specific, categorized outcome or state
    /// within a domain. Its definition (<typeparamref name="TCodeDefinition"/>) provides semantic meaning
    /// and core metadata about the code.
    /// </remarks>
    public interface ICode<out TCodeDefinition> : IHasMetadata
        where TCodeDefinition : ICodeDefinition
    {
        /// <summary>
        /// Gets the specific <see cref="ICodeDefinition"/> definition associated with this code instance.
        /// </summary>
        TCodeDefinition Definition { get; }
    }
}
