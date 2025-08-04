// <copyright file="IPolicyDescriptor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Metadata;
using Zentient.Abstractions.Metadata.Readers;

namespace Zentient.Abstractions.Policies
{
    /// <summary>
    /// Describes a policy, including its implementation type, category, and associated metadata.
    /// </summary>
    /// <remarks>
    /// Used for policy discovery, registration, and introspection.
    /// </remarks>
    public interface IPolicyDescriptor : IHasName, IIdentifiable
    {
        /// <summary>Gets the <see cref="Type"/> of the policy implementation.</summary>
        /// <value>The <see cref="Type"/> that implements the policy.</value>
        Type ImplementationType { get; }

        /// <summary>Gets the <see cref="Type"/> representing the policy category.</summary>
        /// <value>The <see cref="Type"/> that defines the policy category.</value>
        Type PolicyCategoryType { get; }

        /// <summary>Gets the metadata associated with the policy.</summary>
        /// <value>The metadata reader for the policy descriptor.</value>
        IMetadataReader Metadata { get; }
    }
}
