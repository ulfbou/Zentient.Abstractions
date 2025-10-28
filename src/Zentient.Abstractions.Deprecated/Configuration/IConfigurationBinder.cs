// <copyright file="IConfigurationBinder.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Configuration
{
    /// <summary>
    /// Provides methods to bind configuration data into strongly-typed objects.
    /// </summary>
    /// <remarks>
    /// Implementations of this interface allow binding configuration sections to objects,
    /// with optional validation support.
    /// </remarks>
    public interface IConfigurationBinder
    {
        /// <summary>
        /// Binds a section of configuration values into an instance of the specified type.
        /// </summary>
        /// <typeparam name="TResult">The target type to bind the configuration section into.</typeparam>
        /// <param name="config">The configuration root containing the data.</param>
        /// <param name="section">The root key of the section to bind.</param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/> if the section exists and is bindable;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        TResult Bind<TResult>(IConfigurationRoot config, string section);

        /// <summary>
        /// Binds a section of configuration values into an instance of the specified type,
        /// performing validation on the bound object.
        /// </summary>
        /// <typeparam name="TResult">The target type to bind and validate.</typeparam>
        /// <param name="config">The configuration root containing the data.</param>
        /// <param name="section">The root key of the section to bind.</param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/> if the section exists, is bindable,
        /// and passes validation; otherwise, <see langword="null"/>.
        /// </returns>
        TResult BindValidated<TResult>(IConfigurationRoot config, string section);
    }
}
