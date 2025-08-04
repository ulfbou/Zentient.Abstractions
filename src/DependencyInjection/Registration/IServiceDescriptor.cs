// <copyright file="IServiceDescriptor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.DependencyInjection.Definitions;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.DependencyInjection.Registration
{
    /// <summary>Describes a registered service in the dependency injection container.</summary>
    public interface IServiceDescriptor
    {
        /// <summary>Gets the type-safe definition for the service.</summary>
        IServiceDefinition Definition { get; }

        /// <summary>Gets the CLR type of the contract being registered.</summary>
        Type ServiceContract { get; }

        /// <summary>Gets the CLR type of the implementation being registered.</summary>
        Type ImplementationType { get; }

        /// <summary>
        /// Gets the asynchronous factory delegate used to create the service instance.
        /// </summary>
        Func<IServiceResolver, Task<object>> Factory { get; }

        /// <summary>Gets metadata associated with this service registration.</summary>
        IMetadata Metadata { get; }

        /// <summary>Gets the lifetime of the registered service.</summary>
        ServiceLifetime Lifetime { get; }
    }
}
