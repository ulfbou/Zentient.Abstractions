// <copyright file="ITypedConfiguration{out TOptionsDefinition, out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Options;
using Zentient.Abstractions.Options.Definitions;

namespace Zentient.Abstractions.Configuration
{
    /// <summary>
    /// Represents a strongly-typed configuration value and its definition.
    /// </summary>
    /// <typeparam name="TOptionsDefinition">
    /// The type of the options definition. Must implement <see cref="IOptionsDefinition"/>.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type of the configuration value.
    /// </typeparam>
    public interface ITypedConfiguration<out TOptionsDefinition, out TValue>
            : IOptions<TOptionsDefinition, TValue>, IHasVersion
            where TOptionsDefinition : IOptionsDefinition
    {
        /// <summary>
        /// Gets a token used to observe changes to the configuration value.
        /// </summary>
        Zentient.Abstractions.Configuration.IChangeToken ChangeToken { get; }
    }
}
