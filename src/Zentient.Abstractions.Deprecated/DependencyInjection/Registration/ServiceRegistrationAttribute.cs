// <copyright file="ServiceRegistrationAttribute.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection.Registration
{
    /// <summary>
    /// Marks a class as a service to be automatically registered in the dependency injection container.
    /// </summary>
    /// <remarks>
    /// This attribute provides comprehensive configuration options for declarative service registration,
    /// supporting conditional registration, metadata assignment, and advanced patterns like decorators.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
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
        /// Initializes a new instance of the <see cref="ServiceRegistrationAttribute"/> class
        /// with the specified service contract and lifetime.
        /// </summary>
        /// <param name="serviceContract">The contract type that this service implements.</param>
        /// <param name="lifetime">The service lifetime.</param>
        public ServiceRegistrationAttribute(Type serviceContract, ServiceLifetime lifetime)
        {
            ServiceContract = serviceContract ?? throw new ArgumentNullException(nameof(serviceContract));
            Lifetime = lifetime;
        }

        /// <summary>
        /// Gets the <see cref="ServiceLifetime"/> for the registered service.
        /// </summary>
        public ServiceLifetime Lifetime { get; }

        /// <summary>
        /// Gets the service contract type that this service implements.
        /// </summary>
        /// <value>
        /// The contract type, or null to use all implemented interfaces and base types.
        /// </value>
        public Type? ServiceContract { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this service should replace existing registrations.
        /// </summary>
        /// <value>
        /// True to replace existing registrations for the same contract; otherwise, false.
        /// Default is false.
        /// </value>
        public bool Replace { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this service should be registered as a decorator.
        /// </summary>
        /// <value>
        /// True if this service decorates another implementation; otherwise, false.
        /// Default is false.
        /// </value>
        public bool IsDecorator { get; set; }

        /// <summary>
        /// Gets or sets the type being decorated when this service is a decorator.
        /// </summary>
        /// <value>
        /// The type being decorated, or null if this is not a decorator.
        /// </value>
        public Type? DecoratedType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this service should be registered as an interceptor.
        /// </summary>
        /// <value>
        /// True if this service intercepts method calls; otherwise, false.
        /// Default is false.
        /// </value>
        public bool IsInterceptor { get; set; }

        /// <summary>
        /// Gets or sets the type being intercepted when this service is an interceptor.
        /// </summary>
        /// <value>
        /// The type being intercepted, or null if this is not an interceptor.
        /// </value>
        public Type? InterceptedType { get; set; }

        /// <summary>
        /// Gets or sets the name of a static method that returns a condition for registration.
        /// </summary>
        /// <value>
        /// The name of a static method on the decorated class that returns bool and accepts IServiceRegistry.
        /// Null if no conditional registration is required.
        /// </value>
        public string? ConditionalMethodName { get; set; }

        /// <summary>
        /// Gets or sets metadata tags to associate with the service registration.
        /// </summary>
        /// <value>
        /// An array of metadata keys and values in alternating order (key1, value1, key2, value2, ...).
        /// Must have an even number of elements.
        /// </value>
        public object[]? MetadataTags { get; set; }

        /// <summary>
        /// Gets or sets the priority of this registration when multiple services implement the same contract.
        /// </summary>
        /// <value>
        /// Higher values indicate higher priority. Default is 0.
        /// </value>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this service should be eagerly initialized.
        /// </summary>
        /// <value>
        /// True to create the service instance immediately when the container is built;
        /// otherwise, false for lazy initialization. Default is false.
        /// Only applies to singleton services.
        /// </value>
        public bool EagerInitialization { get; set; }

        /// <summary>
        /// Gets or sets the factory method name for creating service instances.
        /// </summary>
        /// <value>
        /// The name of a static method on the decorated class that creates instances.
        /// Null to use constructor injection.
        /// </value>
        public string? FactoryMethodName { get; set; }

        /// <summary>
        /// Gets or sets additional configuration for complex registration scenarios.
        /// </summary>
        /// <value>
        /// A string containing configuration data that can be parsed by the registration system.
        /// Format is implementation-specific.
        /// </value>
        public string? Configuration { get; set; }
    }

    /// <summary>
    /// Marks a class as providing multiple service contracts.
    /// </summary>
    /// <remarks>
    /// This attribute allows a single implementation to be registered for multiple contracts
    /// with different configurations for each contract.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class MultiServiceRegistrationAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiServiceRegistrationAttribute"/> class.
        /// </summary>
        /// <param name="serviceContracts">The service contracts that this implementation provides.</param>
        public MultiServiceRegistrationAttribute(params Type[] serviceContracts)
        {
            ServiceContracts = serviceContracts ?? throw new ArgumentNullException(nameof(serviceContracts));
        }

        /// <summary>
        /// Gets the service contracts that this implementation provides.
        /// </summary>
        public Type[] ServiceContracts { get; }

        /// <summary>
        /// Gets or sets the default lifetime for all service contracts.
        /// </summary>
        /// <value>
        /// The default service lifetime. Individual contracts can override this.
        /// Default is <see cref="ServiceLifetime.Transient"/>.
        /// </value>
        public ServiceLifetime DefaultLifetime { get; set; } = ServiceLifetime.Transient;

        /// <summary>
        /// Gets or sets contract-specific lifetime overrides.
        /// </summary>
        /// <value>
        /// A string in the format "ContractType1:Lifetime1,ContractType2:Lifetime2"
        /// where lifetimes can be "Transient", "Scoped", or "Singleton".
        /// </value>
        public string? LifetimeOverrides { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to register for all implemented interfaces.
        /// </summary>
        /// <value>
        /// True to automatically register for all public interfaces implemented by the class;
        /// otherwise, false to only register for explicitly specified contracts.
        /// Default is false.
        /// </value>
        public bool IncludeAllInterfaces { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to register for base classes.
        /// </summary>
        /// <value>
        /// True to register for non-object base classes; otherwise, false.
        /// Default is false.
        /// </value>
        public bool IncludeBaseClasses { get; set; }
    }

    /// <summary>
    /// Marks a method as a conditional registration predicate.
    /// </summary>
    /// <remarks>
    /// The decorated method must be static, return bool, and accept IServiceRegistry as its only parameter.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class RegistrationConditionAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a description of what condition this method evaluates.
        /// </summary>
        /// <value>
        /// A human-readable description of the registration condition.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this condition should be evaluated asynchronously.
        /// </summary>
        /// <value>
        /// True if the method should be called asynchronously; otherwise, false.
        /// Default is false.
        /// </value>
        public bool IsAsync { get; set; }
    }

    /// <summary>
    /// Marks a method as a service factory.
    /// </summary>
    /// <remarks>
    /// The decorated method must be static and return the service instance.
    /// It can accept IServiceResolver and other registered services as parameters.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class ServiceFactoryAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a value indicating whether the factory method is asynchronous.
        /// </summary>
        /// <value>
        /// True if the method returns Task&lt;T&gt;; otherwise, false.
        /// Default is false.
        /// </value>
        public bool IsAsync { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to cache the factory delegate for performance.
        /// </summary>
        /// <value>
        /// True to compile and cache the factory delegate; otherwise, false.
        /// Default is true.
        /// </value>
        public bool CacheDelegate { get; set; } = true;
    }
}
