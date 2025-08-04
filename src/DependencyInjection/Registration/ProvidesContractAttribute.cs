// <copyright file="ProvidesContractAttribute.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.DependencyInjection.Registration
{
    /// <summary>Specifies the contract that a service implementation provides.</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class ProvidesContractAttribute : Attribute
    {
        public ProvidesContractAttribute(Type contractType)
        {
            ContractType = contractType;
        }

        public Type ContractType { get; }
    }
}
