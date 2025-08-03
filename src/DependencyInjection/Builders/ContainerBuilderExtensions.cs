// <copyright file="ContainerBuilderExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Options;
using Zentient.Abstractions.Options.Definitions;

namespace Zentient.Abstractions.DependencyInjection.Builders
{
    /// <summary>
    /// Provides fluent extension methods for <see cref="IContainerBuilder"/> to register services,
    /// particularly for Zentient.Abstractions.Options integration.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Registers a single instance of an options object as a singleton service.
        /// The options instance will be wrapped in an <see cref="IOptions{TDefinition, TValue}"/>
        /// and registered as a singleton, along with the raw options value type.
        /// </summary>
        /// <typeparam name="TDefinition">The type of the options definition.</typeparam>
        /// <typeparam name="TOptions">The concrete type of the options value.</typeparam>
        /// <param name="builder">The <see cref="IContainerBuilder"/> instance.</param>
        /// <param name="options">The options instance to register.</param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        public static IContainerBuilder AddOptions<TDefinition, TOptions>(this IContainerBuilder builder, TOptions options)
            where TDefinition : IOptionsDefinition
            where TOptions : class
        {
            // Implementation will create an IServiceDescriptor for IOptions<TDefinition, TOptions>
            // and TOptions, registering them as singletons with a factory returning 'options'.
            return builder;
        }

        /// <summary>
        /// Registers an options object using a factory delegate. The factory will be invoked
        /// to create the options value, which will then be wrapped in an
        /// <see cref="IOptions{TDefinition, TValue}"/> and registered. The lifetime of the options
        /// object is typically Singleton when registered this way.
        /// </summary>
        /// <typeparam name="TDefinition">The type of the options definition.</typeparam>
        /// <typeparam name="TOptions">The concrete type of the options value.</typeparam>
        /// <param name="builder">The <see cref="IContainerBuilder"/> instance.</param>
        /// <param name="factory">
        /// A factory that creates the options value using the service resolver.
        /// The result of this factory will be registered as a singleton.
        /// </param>
        /// <returns>The current builder instance for fluent chaining.</returns>
        public static IContainerBuilder AddOptions<TDefinition, TOptions>(this IContainerBuilder builder, Func<IServiceResolver, TOptions> factory)
            where TDefinition : IOptionsDefinition
            where TOptions : class
        {
            // Implementation will create an IServiceDescriptor for IOptions<TDefinition, TOptions>
            // and TOptions, registering them as singletons with the provided 'factory'.
            return builder;
        }
    }
}
