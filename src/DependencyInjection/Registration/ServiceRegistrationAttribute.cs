// <copyright file="ServiceRegistrationAttribute.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection.Registration
{
    /// <summary>
    /// Marks a class as a service to be automatically registered in the dependency injection container.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ServiceRegistrationAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRegistrationAttribute"/> class
        /// with the specified <see cref="ServiceLifetime"/>.
        /// </summary>
        /// <param name="lifetime">
        /// The <see cref="ServiceLifetime"/> that determines how the service will be instantiated and managed.
        /// </param>
        public ServiceRegistrationAttribute(ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
        }

        /// <summary>
        /// Gets the <see cref="ServiceLifetime"/> for the registered service.
        /// </summary>
        public ServiceLifetime Lifetime { get; }
    }
}
