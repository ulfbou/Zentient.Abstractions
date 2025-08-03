// <copyright file="IConfigurationRoot.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;

namespace Zentient.Abstractions.Configuration.Options
{
    /// <summary>
    /// Represents the configuration options for a binding operation.
    /// </summary>
    /// <remarks>
    /// This abstraction is used to configure the behavior of a configuration binder,
    /// such as enabling validation or subscribing to change events.
    /// It is distinct from IOptions, which represents the final, bound options object.
    /// </remarks>
    public interface IBinderOptions
    {
        /// <summary>
        /// Gets a value indicating whether the binder should subscribe to reload events
        /// and automatically re-bind the configuration when it changes.
        /// </summary>
        bool ReloadOnChange { get; }

        /// <summary>
        /// Gets a value indicating whether the binder should perform validation
        /// on the bound object.
        /// </summary>
        bool ValidateOnBind { get; }

        /// <summary>
        /// Gets an optional list of fallback section keys to use if the primary key is not found.
        /// </summary>
        IEnumerable<string>? FallbackKeys { get; }
    }
}
