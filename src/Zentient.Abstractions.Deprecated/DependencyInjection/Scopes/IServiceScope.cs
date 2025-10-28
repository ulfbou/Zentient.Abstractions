// <copyright file="IServiceScope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection.Scopes
{
    /// <summary>
    /// Represents a service scope that provides a mechanism to resolve scoped services.
    /// </summary>
    /// <remarks>
    /// An instance of <see cref="IServiceScope"/> is a lightweight container that disposes of all
    /// services created within it, adhering to the <see cref="ServiceLifetime.Scoped"/> lifetime.
    /// It inherits from <see cref="IServiceResolver"/> to allow for service resolution within its
    /// scope.
    /// </remarks>
    public interface IServiceScope : IDisposable, IServiceResolver { }
}
