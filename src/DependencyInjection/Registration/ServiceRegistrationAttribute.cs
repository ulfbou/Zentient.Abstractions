// <copyright file="ServiceRegistrationAttribute.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection.Registration
{
    /// <summary>Marks a class as a service to be automatically registered.</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ServiceRegistrationAttribute : Attribute
    {
        public ServiceRegistrationAttribute(ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
        }

        public ServiceLifetime Lifetime { get; }
    }
}
