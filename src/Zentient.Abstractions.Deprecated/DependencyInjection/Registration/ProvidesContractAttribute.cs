// <copyright file="ProvidesContractAttribute.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection.Registration
{
    /// <summary>Specifies the contract that a service implementation provides.</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class ProvidesContractAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProvidesContractAttribute"/> class.
        /// </summary>
        /// <param name="contractType">
        /// The <see cref="Type"/> representing the contract that the service implementation provides.
        /// </param>
        public ProvidesContractAttribute(Type contractType)
        {
            ContractType = contractType;
        }

        /// <summary>Gets the contract <see cref="Type"/> that the service implementation provides.</summary>
        public Type ContractType { get; }
    }
}
