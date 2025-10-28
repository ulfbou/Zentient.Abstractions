// <copyright file="IDefinitionScanner.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Reflection;

using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.Registries;

namespace Zentient.Abstractions.Registration
{
    /// <summary>
    /// Discovers definition types and registers them into the appropriate registry or container.
    /// All scanning operations are now asynchronous by default.
    /// </summary>
    public interface IDefinitionScanner
    {
        /// <summary>Scans all loaded assemblies for IDefinition types.</summary>
        /// <returns>
        /// A task that represents the asynchronous operation, containing a read-only collection
        /// of types implementing <see cref="IDefinition"/>.
        /// </returns>
        Task<IReadOnlyCollection<Type>> ScanAll();

        /// <summary>Scans a specific assembly for IDefinition types.</summary>
        /// <param name="assembly">The assembly to scan.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing a read-only collection
        /// of types implementing <see cref="IDefinition"/>.
        /// </returns>
        Task<IReadOnlyCollection<Type>> ScanFromAssembly(Assembly assembly);

        /// <summary>
        /// Filters scanned types by a specialization interface (e.g., IServiceDefinition).
        /// </summary>
        /// <typeparam name="TDefinition">The definition type to filter by.</typeparam>
        /// <returns>
        /// A task that represents the asynchronous operation, containing a read-only collection
        /// of types implementing the specified definition type.
        /// </returns>
        Task<IReadOnlyCollection<Type>> ScanByType<TDefinition>()
            where TDefinition : IDefinition;

        /// <summary>Automatically registers discovered types into the given registry.</summary>
        /// <param name="registry">The registry to register definitions into.</param>
        /// <returns>
        /// A task that represents the asynchronous operation of registering definitions.
        /// </returns>
        Task RegisterInto(IIdentifiableDefinitionRegistry registry);
    }
}
