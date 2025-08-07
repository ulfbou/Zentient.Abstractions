// <copyright file="IPolicyDescriptorRegistry.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace Zentient.Abstractions.Policies.Registries
{
    /// <summary>Registry for policy descriptors, supporting registration and lookup by name or ID.</summary>
    public interface IPolicyDescriptorRegistry
    {
        /// <summary>Registers a policy descriptor.</summary>
        /// <param name="descriptor">The policy descriptor to register.</param>
        void Register(IPolicyDescriptor descriptor);

        /// <summary>Gets all registered policy descriptors.</summary>
        /// <returns>A read-only collection of all policy descriptors.</returns>
        IReadOnlyCollection<IPolicyDescriptor> GetAll();

        /// <summary>Attempts to get a policy descriptor by name.</summary>
        /// <param name="name">The name of the policy descriptor.</param>
        /// <param name="descriptor">When this method returns, contains the descriptor if found; otherwise, null.</param>
        /// <returns>True if found; otherwise, false.</returns>
        bool TryGet(string name, [NotNullWhen(true)] out IPolicyDescriptor? descriptor);

        /// <summary>Gets a policy descriptor by name, or null if not found.</summary>
        /// <param name="name">The name of the policy descriptor.</param>
        /// <returns>The policy descriptor if found; otherwise, null.</returns>
        IPolicyDescriptor? GetDescriptor(string name);

        /// <summary>Attempts to get a policy descriptor by ID.</summary>
        /// <param name="id">The ID of the policy descriptor.</param>
        /// <param name="descriptor">When this method returns, contains the descriptor if found; otherwise, null.</param>
        /// <returns>True if found; otherwise, false.</returns>
        bool TryGetById(string id, [NotNullWhen(true)] out IPolicyDescriptor? descriptor);

        /// <summary>Gets a policy descriptor by ID, or null if not found.</summary>
        /// <param name="id">The ID of the policy descriptor.</param>
        /// <returns>The policy descriptor if found; otherwise, null.</returns>
        IPolicyDescriptor? GetById(string id);
    }
}
